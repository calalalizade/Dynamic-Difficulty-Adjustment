using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "New Metric", menuName = "Metrics/Metric")]
public class MetricSO : ScriptableObject
{
    public MetricType metricType;
    public float weight;
    public float difficultyImpact;
    public float value;  // Added value field to track metric value

    // Actions to be invoked when updating the metric
    private List<System.Action<float>> updateActions = new List<System.Action<float>>();

    public void RegisterUpdateAction(System.Action<float> action)
    {
        updateActions.Add(action);
    }

    public void UpdateMetric(float delta)
    {
        value += delta;
        foreach (var action in updateActions)
        {
            action(value);
        }
    }

    public void ResetToDefault()
    {
        // value = defaultValue;
    }
}