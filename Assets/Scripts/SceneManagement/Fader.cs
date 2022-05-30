using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

namespace Maze_Game.SceneManagement
{
    public class Fader : MonoBehaviour
    {
        [SerializeField] float fadeInTime = 1f;

        CanvasGroup canvasGroup;

        private void Awake() 
        {
            canvasGroup = GetComponent<CanvasGroup>();
            canvasGroup.alpha = 1;

            StartCoroutine(FadeIn(fadeInTime));
        }

        public IEnumerator FadeOut(float time)
        {
            while (canvasGroup.alpha < 1)
            {
                canvasGroup.alpha += Time.deltaTime / time;
                yield return null;
            }
        }

        public IEnumerator FadeIn(float time)
        {
            while (canvasGroup.alpha > 0)
            {
                canvasGroup.alpha -= Time.deltaTime / time;
                yield return null;
            }
        }
    }
}