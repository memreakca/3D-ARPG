using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemyTakeDamage : MonoBehaviour, IBurnable
{
    public float maxHp;
    public float currentHp;
    public Animator anim;
    public Image hpbar;
    public Transform player;
    public EnemyDropLoot droploot;
    public bool tookdamage;

    public EnemySpawner Spawner { get; set; }
    public SpawnerBlock SpawnerBlock { get; set; }

    private bool _IsBurning;
    public bool isBurning { get => _IsBurning; set => _IsBurning = value; }

    private Coroutine BurnCoroutine;

    public delegate void DamageTakenAction(GameObject damagedEnemy);
    public static event DamageTakenAction OnDamageTaken;

    private void Awake()
    {
        PlayerEvents.OnPlayerRespawn += HandlePlayerRespawn;
    }

    private void OnDestroy()
    {
        PlayerEvents.OnPlayerRespawn -= HandlePlayerRespawn;
    }

    private void Start()
    {
        currentHp = maxHp;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();
        hpbar = gameObject.GetComponentInChildren<Image>();
        droploot = GetComponent<EnemyDropLoot>();
    }

    private void Update()
    {
        if (hpbar != null)
        {
            hpbar.fillAmount = currentHp / maxHp;
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            TakeDamage(20);
        }
    }

    public void TakeDamage(float damage)
    {
        currentHp -= damage;
        if (currentHp <= 0)
        {
            currentHp = 0;
            StopBurning();
            droploot.SpawnLoot();
            SpawnerBlock?.OnEnemyDeath(gameObject);
            Spawner?.OnEnemyDeath();
            
        }
        OnDamageTaken?.Invoke(gameObject);
    }

    public void StartBurning(int damagePerSecond)
    {
        isBurning = true;
        if (BurnCoroutine != null)
        {
            StopCoroutine(BurnCoroutine);
        }
        BurnCoroutine = StartCoroutine(Burn(damagePerSecond));
    }

    private IEnumerator Burn(int DamagePerSecond)
    {
        float minTimeToDamage = 1f / DamagePerSecond;
        WaitForSeconds wait = new WaitForSeconds(minTimeToDamage);
        int damagePerTick = Mathf.FloorToInt(minTimeToDamage) + 1;

        TakeDamage(damagePerTick);
        while (isBurning)
        {
            yield return wait;
            TakeDamage(damagePerTick);
        }
    }

    public void StopBurning()
    {
        isBurning = false;
        if (BurnCoroutine != null && gameObject != null)
        {
            StopCoroutine(BurnCoroutine);
        }
    }

    private void HandlePlayerRespawn()
    {
        currentHp = maxHp;
        if (hpbar != null)
        {
            hpbar.fillAmount = currentHp / maxHp;
        }
    }
}
