using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float enemyHealth = 100;
    public float enemySpeed = 5;
    public float spawnRate = .5f;

    [SerializeField] TMP_Text healthText;
    [SerializeField] TMP_Text speedText;
    [SerializeField] TMP_Text rateText;

    public void SetHealth(float health)
    {
        enemyHealth = health;
        healthText.text = "Health: " + enemyHealth.ToString();
    }

    public void SetSpeed(float speed)
    {
        enemySpeed = speed;
        speedText.text = "Speed: " + enemySpeed.ToString();
    }

    public void SetSpawnRate(float rate)
    {
        spawnRate = rate;
        rateText.text = "Rate: " + spawnRate.ToString();
    }


}
