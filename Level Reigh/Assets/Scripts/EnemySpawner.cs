using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public List<Transform> spawnPoints;

    [Header("Spawn Settings")]
    public int enemiesPerWave = 8;
    public float timeBetweenWaves = 5f;

    private int currentWave = 0;
    private bool spawning = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnWave());
    }

    IEnumerator SpawnWave()
    {
        spawning = true;
        currentWave++;

        for (int i = 0; i < enemiesPerWave; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }

        spawning = false;

        yield return new WaitForSeconds(timeBetweenWaves);
        StartCoroutine(SpawnWave());
    }

    void SpawnEnemy()
    {
        if (spawnPoints.Count == 0) return;

        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count)];
        Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
    }
}
