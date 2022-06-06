using System.Collections;
using System.Collections.Generic;
using Maze_Game.Core;
using UnityEngine;
using UnityEngine.Playables;

namespace Maze_Game.Cinematics
{
    public class CinematicTrigger : MonoBehaviour
    {
        [SerializeField] float secondsToWait = 8f;
        bool alreadyTriggered = false;

        private void OnTriggerEnter(Collider other) 
        {
            if(!alreadyTriggered && other.tag == ("Player"))
            {
                StartCoroutine(PlayCinematicStartTimer());
            }
        }

        IEnumerator PlayCinematicStartTimer()
        {
            alreadyTriggered = true;
            GetComponent<PlayableDirector>().Play();

            yield return new WaitForSeconds(secondsToWait);

            TimerCountdown timerCountdown = FindObjectOfType<TimerCountdown>();
            timerCountdown.countDownTimer();           
        }
    }
}
