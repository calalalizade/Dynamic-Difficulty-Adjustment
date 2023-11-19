using UnityEngine;
using System.Collections.Generic;

public class DifficultyManagerNew : MonoBehaviour
{
    public List<MetricSO> metrics = new List<MetricSO>();

    public float CalculateDifficulty()
    {
        float difficulty = 0f;
        float totalImpact = 0f;

        foreach (var metric in metrics)
        {
            difficulty += metric.weight * metric.value;
            totalImpact += metric.weight;
        }

        //  Adjusts the difficulty proportionally based on the impact of each metric
        if (totalImpact != 0)
        {
            difficulty /= totalImpact;
        }

        // Clamp the difficulty value between 0.1 and 1
        difficulty = Mathf.Clamp(difficulty, 0.1f, 1f);

        return difficulty;
    }

    public void UpdateMetric(MetricType metricType, float delta)
    {
        var metric = metrics.Find(m => m.metricType == metricType);

        if (metric != null)
        {
            metric.UpdateMetric(delta);
            float difficulty = CalculateDifficulty();
            AdjustGameElements(difficulty);
        }
    }

    public void AdjustGameElements(float difficulty)
    {
        // Adjust game elements based on difficulty
        // Example: Adjust enemy speed based on overall difficulty
        float enemySpeedMultiplier = 1.0f + (difficulty * 0.1f); // Adjust multiplier as needed

        Debug.Log("Final Difficulty: " + difficulty);
        // Debug.Log("enemySpeedMultiplier: " + enemySpeedMultiplier);
    }
}
