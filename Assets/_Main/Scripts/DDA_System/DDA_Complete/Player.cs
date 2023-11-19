using UnityEngine;

public class Player : MonoBehaviour
{
    public DifficultyManagerNew difficultyManager;
    public MetricSO accuracyMetric;
    public MetricSO completionTimeMetric;
    public MetricSO playerHealthMetric;

    [SerializeField] private int playerHealth = 100;
    [SerializeField] private int enemyDamage = 5;

    private void Start()
    {
        accuracyMetric.RegisterUpdateAction(UpdateAccuracy);
        completionTimeMetric.RegisterUpdateAction(UpdateCompletionTime);
        playerHealthMetric.RegisterUpdateAction(UpdatePlayerHealth);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            difficultyManager.UpdateMetric(accuracyMetric.metricType, accuracyMetric.difficultyImpact);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            difficultyManager.UpdateMetric(accuracyMetric.metricType, -accuracyMetric.difficultyImpact);
        }

        if (Input.GetMouseButtonDown(0))
        {
            TakeDamage(enemyDamage);
            difficultyManager.UpdateMetric(playerHealthMetric.metricType, -playerHealthMetric.difficultyImpact * playerHealth);
        }


        if (Input.GetKeyDown(KeyCode.Q))
        {
            difficultyManager.UpdateMetric(completionTimeMetric.metricType, 0.1f);
        }
    }

    private void TakeDamage(int damage)
    {
        playerHealth -= damage;
    }

    private void UpdateAccuracy(float value)
    {

    }

    private void UpdateCompletionTime(float value)
    {

    }

    private void UpdatePlayerHealth(float value)
    {

    }
}
