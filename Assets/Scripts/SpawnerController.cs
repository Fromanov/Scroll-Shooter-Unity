using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{

    [SerializeField]
    private GameObject asteroid;
    [SerializeField]
    private GameObject enemy;
    [SerializeField]
    private GameObject heal;

    [SerializeField]
    private float spawnAsteroidTimer = 1.5f;
    [SerializeField]
    private float spawnEnemyTimer = 3f;
    [SerializeField]
    private float spawnHealTimer = 25f;
    [SerializeField]
    private float randomTimer;
    [SerializeField]
    private float start;
    [SerializeField]
    private float stop;

    void Update()
    {
        randomTimer = TimerRamdomizer(start, stop);

        spawnAsteroidTimer -= Time.deltaTime;
        spawnEnemyTimer -= Time.deltaTime;
        spawnHealTimer -= Time.deltaTime;
        randomTimer -= Time.deltaTime;

        if(randomTimer <= 0)
        {
            randomTimer = TimerRamdomizer(start, stop);
        }

        if (spawnAsteroidTimer <= 0)
        {
            spawnAsteroidTimer = 1.5f;
            Vector3 randomSpawnPosition = new Vector3(Random.Range(-25, 25),
                0, Random.Range(10, 12));
            Instantiate(asteroid, randomSpawnPosition, 
                asteroid.transform.rotation);
        }

        if (spawnEnemyTimer <= 0)
        {
            spawnEnemyTimer = 3f;
            Vector3 randomSpawnPosition = new Vector3(Random.Range(-25, 25),
                0, Random.Range(10, 12));
            Instantiate(enemy, randomSpawnPosition,
                enemy.transform.rotation);
        }

        if (spawnHealTimer <= 0)
        {
            spawnHealTimer = 25f;
            Vector3 randomSpawnPosition = new Vector3(Random.Range(-25, 25),
                0, Random.Range(10, 12));
            Instantiate(heal, randomSpawnPosition,
                heal.transform.rotation);
        }
    }

    private float TimerRamdomizer(float start, float stop)
    {
        return Random.Range(start, stop);
    }
}
