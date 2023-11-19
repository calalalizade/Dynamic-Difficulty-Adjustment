using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetricTracker : MonoBehaviour
{
    public float overallAccuracy;
    public float playerHealth;
    public int score;
    public float totalDistance;
    public int totalReloads;
    public float sessionTime;
    public float headshotEnemyHitRatio;

    // Update overall accuracy based on player shots
    public void UpdateAccuracy(bool isHit)
    {
        // Update accuracy based on whether the shot was a hit
        if (isHit)
            overallAccuracy = (overallAccuracy * score + 1) / (score + 1);
        else
            overallAccuracy = (overallAccuracy * score) / (score + 1);
    }

    // Update player health
    public void UpdatePlayerHealth(float health)
    {
        playerHealth = health;
    }

    // Update score
    public void UpdateScore(int points)
    {
        score += points;
    }

    // Update total distance travelled
    public void UpdateTotalDistance(float distance)
    {
        totalDistance += distance;
    }

    // Update total number of reloads
    public void UpdateTotalReloads()
    {
        totalReloads++;
    }

    // Update session time
    public void UpdateSessionTime(float time)
    {
        sessionTime += time;
    }

    // Update headshot enemy hit ratio
    public void UpdateHeadshotEnemyHitRatio(bool isHeadshot)
    {
        if (isHeadshot)
            headshotEnemyHitRatio = (headshotEnemyHitRatio * score + 1) / (score + 1);
        else
            headshotEnemyHitRatio = (headshotEnemyHitRatio * score) / (score + 1);
    }
}
