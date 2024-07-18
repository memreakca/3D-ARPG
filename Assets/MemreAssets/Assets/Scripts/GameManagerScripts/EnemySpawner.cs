using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Spawner Settings")]
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float respawnDelay = 30f;

    private GameObject currentEnemy;

    private void Start()
    {
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        if (enemyPrefab != null)
        {
            currentEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            currentEnemy.transform.SetParent(transform);
            currentEnemy.GetComponent<EnemyTakeDamage>().Spawner = this;
        }
        else
        {
            Debug.LogWarning("Enemy prefab is not assigned!");
        }
    }

    public void OnEnemyDeath()
    {
        StartCoroutine(RespawnEnemy());
    }

    private IEnumerator RespawnEnemy()
    {
        yield return new WaitForSeconds(respawnDelay);
        SpawnEnemy();
    }
}
