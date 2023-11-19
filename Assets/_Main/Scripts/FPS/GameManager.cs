using UnityEngine;
using TMPro;

namespace Scripts.FPS
{
    public class GameManager : Singleton<GameManager>
    {
        private int overallAccuracy;
        private int headShotCount;
        private int bodyShotCount;
        private int totalShotsCount;
        private float totalDistanceTraveled;
        private float elapsedTime;
        private int score;

        // UI
        [SerializeField] private TMP_Text distanceText;
        [SerializeField] private TMP_Text totalShotsText;
        [SerializeField] private TMP_Text headBodyShotsText;
        [SerializeField] private TMP_Text overallAccuracyText;
        [SerializeField] private TMP_Text elapsedTimeText;
        [SerializeField] private TMP_Text scoreText;

        private float headShotWeight = 2.0f;
        private float bodyShotWeight = 1.0f;

        public void CalculateOverallAccuracy()
        {
            float accuracyPercentage = (float)(headShotCount * headShotWeight + bodyShotCount * bodyShotWeight) / totalShotsCount * 100;

            // Clamp the accuracy percentage between 0 and 100
            accuracyPercentage = Mathf.Clamp(accuracyPercentage, 0f, 100f);
            overallAccuracy = Mathf.RoundToInt(accuracyPercentage); // Round to the nearest integer

            overallAccuracyText.text = $"{overallAccuracy}%";
        }

        public void UpdateDistance(float distance)
        {
            totalDistanceTraveled += distance;
            distanceText.text = totalDistanceTraveled.ToString("F0");
        }

        public void UpdateElapsedTime(float elapsedTime, int minutes, int seconds)
        {
            this.elapsedTime = elapsedTime;
            elapsedTimeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }

        public void UpdateTotalShots()
        {
            totalShotsCount++;
            totalShotsText.text = totalShotsCount.ToString();
        }

        public void UpdateHeadShots()
        {
            headShotCount++;
            headBodyShotsText.text = $"{headShotCount}/{bodyShotCount}";
        }

        public void UpdateBodyShots()
        {
            bodyShotCount++;
            headBodyShotsText.text = $"{headShotCount}/{bodyShotCount}";
        }

        public void UpdateScore(int amount)
        {
            score += amount;
            scoreText.text = score.ToString();
        }
    }
}