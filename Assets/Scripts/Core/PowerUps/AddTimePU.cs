using System.Collections;
using System.Collections.Generic;
using Maze_Game.Core;
using UnityEngine;

namespace Maze_Game.Core
{
    public class AddTimePU : MonoBehaviour
    {
        [SerializeField] public GameObject _addTimePU;

        [SerializeField] TimerCountdown _timer;

        Player _player;

        

        // Start is called before the first frame update
        void Start()
        {
            _player = GetComponent<Player>();
            _timer = GetComponent<TimerCountdown>();
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        public void AddTime()
            {
                if(_player.isActivePowerUp)
                {
                    if(_timer.countDownStartValue > 0 && _addTimePU == true)
                    {
                        _player.isActivePowerUp = false;
                    }               
                }
            }

        void OnTriggerEnter(Collider other)
        {
            if(other.tag == "Player")
            {
                Player _player = other.transform.GetComponent<Player>();
                _player.isActivePowerUp = true;
                _timer.countDownStartValue += 10;
                _addTimePU.SetActive(false);
            }
        }
    }
}
