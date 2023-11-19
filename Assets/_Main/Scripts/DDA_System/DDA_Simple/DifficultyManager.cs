using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    public Enemy enemy;
    public MetricTracker metricTracker;

    // Parameters to be adjusted
    public float enemyHealth;
    public float enemySpeed;
    public float spawnRate;

    // Define weights for each metric
    public float accuracyWeight = 0.2f;
    public float playerHealthWeight = 0.007f;
    public float scoreWeight = 0.005f;
    public float totalDistanceWeight = 0.05f;
    public float totalReloadsWeight = 0.05f;
    public float sessionTimeWeight = 0.1f;
    public float headshotEnemyHitRatioWeight = 0.2f;


    // Update is called once per frame
    void Update()
    {
        // Update game parameters based on metrics
        UpdateParameters();

        // Apply updated parameters to game objects
        enemy.SetHealth(enemyHealth);
        enemy.SetSpeed(enemySpeed);
        enemy.SetSpawnRate(spawnRate);
    }

    // Update game parameters based on metrics
    void UpdateParameters()
    {
        // Calculate weighted sum of metrics
        float weightedSum = CalculateWeightedSum();

        // Adjust parameters based on the weighted sum
        enemyHealth = CalculateAdjustedEnemyHealth(weightedSum);
        enemySpeed = CalculateAdjustedEnemySpeed(weightedSum);
        spawnRate = CalculateAdjustedSpawnRate(weightedSum);
    }

    float CalculateWeightedSum()
    {
        // Calculate the weighted sum of metrics
        float weightedSum = 0f;

        // Adjust based on overall accuracy (higher accuracy increases difficulty)
        weightedSum += metricTracker.overallAccuracy * accuracyWeight;

        // Adjust based on player health (lower health decreases difficulty)
        weightedSum -= (100f - metricTracker.playerHealth) * playerHealthWeight;

        // Adjust based on score (higher score increases difficulty)
        weightedSum += metricTracker.score * scoreWeight;

        // Adjust based on total reloads (higher reloads decrease difficulty)
        weightedSum -= metricTracker.totalReloads * totalReloadsWeight;

        // Adjust based on total distance traveled (higher distance increases difficulty)
        weightedSum += metricTracker.totalDistance * totalDistanceWeight;

        // Adjust based on session time (higher session time decreases difficulty)
        weightedSum -= metricTracker.sessionTime * sessionTimeWeight;

        return weightedSum;
    }

    float CalculateAdjustedEnemyHealth(float weightedSum)
    {
        // Adjust enemy health based on the weighted sum and additional factors
        return 100 + weightedSum * 50;
    }

    float CalculateAdjustedEnemySpeed(float weightedSum)
    {
        // Adjust enemy speed based on the weighted sum and additional factors
        return 5 + weightedSum * 5;
    }

    float CalculateAdjustedSpawnRate(float weightedSum)
    {
        // Adjust spawn rate based on the weighted sum and additional factors
        return Mathf.Clamp(1.0f - weightedSum * 0.1f, 0.1f, 1.0f);
    }
}
