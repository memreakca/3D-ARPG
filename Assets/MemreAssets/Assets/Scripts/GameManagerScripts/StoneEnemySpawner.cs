using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class StoneEnemySpawner : MonoBehaviour
{
    public GameObject stoneEnemyPrefab;
    public float timeBetweenSpawns = 30f; 
    public bool isEnemyAlive;

    private void Start()
    {
        SpawnStoneEnemy();
    }

    void SpawnStoneEnemy()
    {
        if (!isEnemyAlive)
        {
            var stnEnemy = Instantiate(stoneEnemyPrefab, transform.position, Quaternion.identity);
            stnEnemy.GetComponent<stone_enemy_patrol>().patrolPoint = transform;
            isEnemyAlive = true;

            stone_enemy_sc stoneEnemySc = stnEnemy.GetComponent<stone_enemy_sc>();
            stoneEnemySc.OnEnemyDeath.AddListener(OnEnemyDeathCallback);
        }
    }

    void OnEnemyDeathCallback()
    {
        isEnemyAlive = false;
        StartCoroutine(SpawnStoneEnemyWithDelay());
    }

    IEnumerator SpawnStoneEnemyWithDelay()
    {
        yield return new WaitForSeconds(timeBetweenSpawns);
        SpawnStoneEnemy();
    }
}