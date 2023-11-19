using System.Collections;
using UnityEngine;

namespace Scripts.FPS
{
    public class GameSessionTimer : MonoBehaviour
    {
        private GameManager gameManager;
        private float startTime;

        void Start()
        {
            gameManager = GameManager.GetInstance();
            startTime = Time.time;
            StartCoroutine(UpdateElapsedTime());
        }

        private IEnumerator UpdateElapsedTime()
        {
            while (true)
            {
                float elapsedTime = Time.time - startTime;

                // Convert elapsedTime to minutes and seconds
                int minutes = Mathf.FloorToInt(elapsedTime / 60f);
                int seconds = Mathf.FloorToInt(elapsedTime % 60f);

                // Update UI to display elapsed time
                gameManager.UpdateElapsedTime(elapsedTime, minutes, seconds);

                yield return null;
            }
        }
    }
}