using System.Collections;
using System.Collections.Generic;
using Maze_Game.Core;
using UnityEngine;

namespace Maze_Game.Core
{
    public class PowerUp : MonoBehaviour
    {
        [SerializeField] private int powerupID;
        [SerializeField] AudioSource _audio;

        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        void OnTriggerEnter(Collider other)
        {
            if(other.tag == "Player")
            {
                Player player = other.transform.GetComponent<Player>();
                TimerCountdown _timer = other.transform.gameObject.GetComponent<TimerCountdown>();
                if(player != null)
                {
                    if(powerupID == 0)
                    {
                        player.isActivePowerUp = true;
                        _audio.Play();
                        player._speed = 8.0f;
                    }
                    else if(powerupID == 1)
                    {
                        player.isActivePowerUp = true;
                        _audio.Play();
                        player._speed = 1.0f;
                    }
                    else if(powerupID == 2)
                    {
                        player.isActivePowerUp = true;
                        _timer.AddTime();
                    }
                    StartCoroutine(DestroyObject());
                }
                
            }
        }

        IEnumerator DestroyObject()
        {
            
            yield return new WaitForSeconds(1);
            Destroy(this.gameObject);
        }
    }
}