using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damagable : MonoBehaviour
{
    [SerializeField] private float initialHealth;
    [SerializeField] private GameObject explosion;

    private float currentHealth;

    private void Awake()
    {
        currentHealth = initialHealth;
    }

    public void ApplyDamage(float damage)
    {
        if (currentHealth <= 0) return;

        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Destruct();
        }
    }

    private void Destruct()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
