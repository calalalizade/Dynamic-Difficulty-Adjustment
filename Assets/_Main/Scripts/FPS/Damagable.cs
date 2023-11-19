using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Scripts.FPS
{
    public class Damagable : MonoBehaviour
    {
        [SerializeField] private enum BodyPart { HEAD, BODY }

        [SerializeField] private float initialHealth;
        [SerializeField] private GameObject blood;

        private GameManager gameManager;
        private float currentHealth;
        [SerializeField] BodyPart bodyPart = BodyPart.HEAD;

        private void Awake()
        {
            gameManager = GameManager.GetInstance();
            currentHealth = initialHealth;
        }

        public void ApplyDamage(float damage)
        {
            if (currentHealth <= 0) return;

            if (bodyPart == BodyPart.HEAD)
            {
                gameManager.UpdateHeadShots();
            }
            else if (bodyPart == BodyPart.BODY)
            {
                gameManager.UpdateBodyShots();
            }

            currentHealth -= damage;

            if (currentHealth <= 0)
            {
                Destruct();
            }
        }

        private void Destruct()
        {
            gameManager.UpdateScore(10);
            Instantiate(blood, transform.position, Quaternion.identity);
            Destroy(transform.root.gameObject);
        }
    }
}