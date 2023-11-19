using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scritps.FPS
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] enum SpawnState { SPAWNING, WAITING, COUNTING }

        [System.Serializable]
        public class Wave
        {
            public string name;
            public Transform enemy;
            public int count;
            public float spawnRate;
        }

        [SerializeField] private Transform[] spawnPoints;
        [SerializeField] private Wave[] waves;
        private int nextWave = 0;

        [SerializeField] float timeBetweenWaves = 5.0f;
        [SerializeField] float waveCountDown;

        private float searchCountdown = 1.0f;

        private SpawnState state = SpawnState.COUNTING;

        private void Start()
        {
            waveCountDown = timeBetweenWaves;
        }

        private void Update()
        {
            if (state == SpawnState.WAITING)
            {
                if (!EnemyIsAlive())
                {
                    WaveCompleted();
                }
                else
                {
                    return;
                }
            }

            if (waveCountDown <= 0)
            {
                if (state != SpawnState.SPAWNING)
                {
                    StartCoroutine(SpawnWave(waves[nextWave]));
                }
            }
            else
            {
                waveCountDown -= Time.deltaTime;
            }
        }

        private void WaveCompleted()
        {
            Debug.Log("Wave Completed!");

            state = SpawnState.COUNTING;
            waveCountDown = timeBetweenWaves;

            if (nextWave + 1 > waves.Length - 1)
            {
                nextWave = 0;
                Debug.Log("All waves completed! Starting Again...");
            }
            else
            {
                nextWave++;
            }

        }

        private bool EnemyIsAlive()
        {
            searchCountdown -= Time.deltaTime;
            if (searchCountdown <= 0.0f)
            {
                searchCountdown = 1f;
                if (GameObject.FindGameObjectWithTag("Enemy") == null)
                {
                    return false;
                }
            }

            return true;
        }

        private IEnumerator SpawnWave(Wave _wave)
        {
            Debug.Log("Spawning Wave: " + _wave.name);
            state = SpawnState.SPAWNING;

            for (int i = 0; i < _wave.count; i++)
            {
                GenerateEnemy(_wave.enemy);
                yield return new WaitForSeconds(1f / _wave.spawnRate);
            }

            state = SpawnState.WAITING;

            yield break;
        }

        private void GenerateEnemy(Transform _enemy)
        {
            Debug.Log("Spawning enemy: " + _enemy.name);
            Transform _spawnPoint = spawnPoints[generateRandomNumber(0, spawnPoints.Length)];
            Instantiate(_enemy, _spawnPoint.position, Quaternion.identity);
        }

        #region Generate Unique Random
        private static int lastRandomNumber;
        public static int generateRandomNumber(int min, int max)
        {
            int result = Random.Range(min, max);

            if (result == lastRandomNumber)
            {
                return generateRandomNumber(min, max);
            }

            lastRandomNumber = result;
            return result;
        }
        #endregion
    }

}
