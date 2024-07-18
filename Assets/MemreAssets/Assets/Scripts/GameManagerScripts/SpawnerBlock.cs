using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBlock : MonoBehaviour, IInteractable
{
    [Header("Spawner Settings")]
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private float spawnRadius = 10f;
    [SerializeField] private float spawnInterval = 1f; 
    [SerializeField] private int maxEnemiesPerWave = 10;

    private bool isSpawning = false;
    private List<GameObject> spawnedEnemies = new List<GameObject>();

    public void Interact()
    {
       
        if (!isSpawning)
        {
            StartWave();
        }
    }

    private void StartWave()
    {
        isSpawning = true;
        StartCoroutine(SpawnWave());
    }

    private IEnumerator SpawnWave()
    {
        int enemiesSpawned = 0;

        while (enemiesSpawned < maxEnemiesPerWave)
        {
            if (spawnedEnemies.Count < maxEnemiesPerWave)
            {
                SpawnEnemy();
                enemiesSpawned++;
            }
            yield return new WaitForSeconds(spawnInterval);
        }

        yield return new WaitUntil(() => spawnedEnemies.Count == 0);

        EndWave();
    }

    private void EndWave()
    {
        isSpawning = false;
        NotificationEvents.Notify("Dalga Temizlendi Spawn Ýþlemi Durduruldu", null);
    }

    private void SpawnEnemy()
    {
        Vector3 randomPosition = GetRandomSpawnPosition();
        GameObject enemyPrefab = GetRandomEnemyPrefab();  
        GameObject spawnedEnemy = Instantiate(enemyPrefab, randomPosition, Quaternion.identity);
        spawnedEnemy.transform.SetParent(transform); 
        spawnedEnemies.Add(spawnedEnemy);

        var enemyTakeDamage = spawnedEnemy.GetComponent<EnemyTakeDamage>();
        if (enemyTakeDamage != null)
        {
            enemyTakeDamage.SpawnerBlock = this;
        }
    }
    private GameObject GetRandomEnemyPrefab()
    {
        int randomIndex = Random.Range(0, enemyPrefabs.Length);
        return enemyPrefabs[randomIndex];
    }

    private Vector3 GetRandomSpawnPosition()
    {
        Vector2 randomCircle = Random.insideUnitCircle * spawnRadius;
        Vector3 spawnPosition = new Vector3(randomCircle.x, 0, randomCircle.y) + transform.position;
        return spawnPosition;
    }

    public void OnEnemyDeath(GameObject enemy)
    {
        spawnedEnemies.Remove(enemy);
    }

    public void ResetSpawner()
    {
        StopAllCoroutines();
        isSpawning = false;
        foreach (var enemy in spawnedEnemies)
        {
            if (enemy != null)
            {
                Destroy(enemy);
            }
        }
        spawnedEnemies.Clear();
        Debug.Log("Spawner reset.");
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }
}
