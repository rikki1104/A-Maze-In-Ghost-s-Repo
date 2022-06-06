using System;
using System.Collections;
using System.Collections.Generic;
using Maze_Game.Core;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Maze_Game.Core
{
    public class TimerCountdown : MonoBehaviour
    {
        public static TimerCountdown instance;
        public int countDownStartValue = 120;

        [SerializeField] int countDownLowWarningValue = 20;
        [SerializeField] Text timerUI;
        [SerializeField] GameObject timerText;

        Text textColor;
        
        void Awake()
        {
            instance = this;
        }

        void Update()
        {
            AddTime();
        }

        IEnumerator CountDown()
        {
            yield return new WaitForSeconds (3); 
            timerText.SetActive(false);
            SceneManager.LoadScene(1);                       
        }

        public void countDownTimer()
        {
            if(countDownStartValue > 0)
            {
                timerText.SetActive(true);
                TimeSpan spanTime = TimeSpan.FromSeconds(countDownStartValue);
                
                if(countDownStartValue < 60)
                {
                    timerUI.text =  spanTime.Seconds + " ";
                }
                else
                {
                    timerUI.text =  spanTime.Minutes + ":" + spanTime.Seconds + " ";
                }

                if(countDownStartValue <= countDownLowWarningValue)
                {
                    timerUI.color = Color.red;
                }
                
                countDownStartValue--;

                Invoke("countDownTimer", 1.0f);
                }
                else
                {
                    timerUI.text = "Maze Failed!";
                    if(countDownStartValue == 0)
                {
                    StartCoroutine(CountDown());
                    
                    ResetTimer(); 
                }
                
            }       
        }

        public void AddTime()
        {
            Player player = GetComponent<Player>();
            if(player != null)
            {
                if(player.isActivePowerUp)
                {
                    player._boostTimer += Time.deltaTime;
                    if(player._boostTimer >= 3)
                    {
                        player.isActivePowerUp = false;
                        player._boostTimer = 0f;
                    }
                }
                else if(!player.isActivePowerUp)
                {
                    countDownStartValue += 10;
                }
            }
                
        }

        public void ResetTimer()
        {
            if (countDownStartValue == 0)
            {
                countDownStartValue = 5;
            }
        }
    }
}
