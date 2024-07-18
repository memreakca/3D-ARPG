using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerNest : MonoBehaviour, IInteractable, IEnemy
{
    public static SpawnerNest Instance;
    [Header("Refs")]
    [SerializeField] private GameObject[] spiderPrefab;
    public int numberOfEnemiesToSpawn = 10;

    [Header("Attributes")]
    [SerializeField] public float startEnemy = 8;
    [SerializeField] public float difficultyScalingFactor = 0.25f;
    [SerializeField] public float BaseWaveTime = 30;

    public float spawnRange;
    public float antiSpawnRange;
    public float waveTime;
    public float maxEnemyPerSec = 4.5f;
    public float timeSinceLastSpawn;

    public int currentWave = 1;
    public int maxWave = 5;

    public int enemiesAlive;
    public bool isSpawning;
    public float enemyPerSec = 1;

    [SerializeField] public int EnemyID { get; set; }
    [SerializeField] public int Experience { get; set; }

    private void Awake()
    {
        Instance = this;
    }

    private void OnEnable()
    {
        PlayerEvents.OnPlayerRespawn += ResetSpawner;
    }

    private void OnDisable()
    {
        PlayerEvents.OnPlayerRespawn -= ResetSpawner;
    }

    public void Interact()
    {
        EnemyID = 14;
        Experience = 300;
        if (!isSpawning)
        {
            StartWave();
        }
    }

    private void Update()
    {
        if (currentWave > maxWave)
        {
            CombatEvents.EnemyDied(this);
            if (gameObject.GetComponent<EnemyDropLoot>() != null)
            {
                gameObject.GetComponent<EnemyDropLoot>().SpawnLoot();
            }
            Destroy(gameObject);
        }

        if (!isSpawning) return;
        timeSinceLastSpawn += Time.deltaTime;

        if (waveTime > 0)
        {
            waveTime -= Time.deltaTime;
        }

        if (timeSinceLastSpawn >= (1f / enemyPerSec) && waveTime > 0)
        {
            SpawnEnemy();
            timeSinceLastSpawn = 0f;
        }

        if (enemiesAlive == 0 && waveTime <= 0)
        {
            EndWave();
        }
    }

    private void SpawnEnemy()
    {
        enemiesAlive++;
        int ix;
        int ex;

        ix = UnityEngine.Random.Range(0, 3);
        if (ix < 2) { ex = 0; } else ex = 1;

        GameObject prefabToSpawn = spiderPrefab[ex];
        Vector3 spawnPosition = GetRandomSpawnPosition();
        GameObject spawnedEnemy = Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
        spawnedEnemy.transform.SetParent(gameObject.transform);
    }

    Vector3 GetRandomSpawnPosition()
    {
        Vector2 randomCircle = UnityEngine.Random.insideUnitCircle * spawnRange;
        return new Vector3(randomCircle.x + transform.position.x, transform.position.y, randomCircle.y + transform.position.z);
    }

    public void EnemyDied()
    {
        enemiesAlive--;
    }

    private void StartWave()
    {
        isSpawning = true;
        enemyPerSec = EnemiesPerSec();
        waveTime = WaveTime();
    }

    private void EndWave()
    {
        NotificationEvents.Notify("Dalga Temizlendi!", null);
        currentWave++;
        isSpawning = false;
        timeSinceLastSpawn = 0f;
        Invoke("StartWave", 5);
    }

    private int WaveTime()
    {
        return Mathf.RoundToInt(BaseWaveTime * Mathf.Pow(currentWave, difficultyScalingFactor));
    }

    private float EnemiesPerSec()
    {
        return Mathf.Clamp(enemyPerSec * Mathf.Pow(currentWave, difficultyScalingFactor), 0f, maxEnemyPerSec);
    }

    private void ResetSpawner()
    {
        currentWave = 1;
        enemiesAlive = 0;
        isSpawning = false;
        timeSinceLastSpawn = 0f;
        waveTime = 0f;
        enemyPerSec = 1;

        EnemyTakeDamage[] enemies = GetComponentsInChildren<EnemyTakeDamage>();
        foreach (EnemyTakeDamage enemy in enemies)
        {
            Destroy(enemy.gameObject);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, spawnRange);
    }
}