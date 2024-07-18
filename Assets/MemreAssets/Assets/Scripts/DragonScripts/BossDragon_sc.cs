using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class BossDragon_sc : MonoBehaviour, IEnemy
{
    public static BossDragon_sc main;
    public TextMeshProUGUI healthtext;
    public Image healthbar;
    public int EnemyID { get; set; }
    public int Experience { get; set; }

    public float attackInterval = 5f;
    public float hpThreshold = 50f;
    public float spellInterval = 8f;

    private EnemyTakeDamage enemyTakeDamage;
    private Animator animator;
    public Transform player;
    public NavMeshAgent navMeshAgent;

    public GameObject DragonFlame;
    public GameObject freezingCirclePrefab;

    private Coroutine attackCoroutine;
    private delegate void AttackDelegate();
    private List<AttackDelegate> attacks;

    private SphereCollider BiteCollider;
    public float BiteDamage;

    private BoxCollider WingCollider;
    public float WingDamage;

    private float nextStunThreshold;
    private bool isStunned = false;
    public float stunDuration = 5f;
    private bool isDead;

    public string[] dialogueLines;
    public string[] deathdialogueLines;

    public bool isStarted;
    
    private void Awake()
    {
        main = this;
    }
    void Start()
    {
        BiteCollider = GetComponentInChildren<SphereCollider>();
        GetComponentsInChildren<ColliderApplyDamage>()[0].damageAmount = BiteDamage;

        WingCollider = GetComponentsInChildren<BoxCollider>()[1];
        GetComponentsInChildren<ColliderApplyDamage>()[1].damageAmount = WingDamage;

        enemyTakeDamage = GetComponent<EnemyTakeDamage>();
        nextStunThreshold = enemyTakeDamage.maxHp * 0.75f;
        animator = GetComponent<Animator>();
        EnemyID = 99;
        Experience = 25000;
        navMeshAgent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        transform.LookAt(player);
        attacks = new List<AttackDelegate> { Attack1, Attack2, Attack3, SpellCast };
        EnemyTakeDamage.OnDamageTaken += OnDamageTaken;
        Dialogue.Instance.StartDialogue(dialogueLines);
    }

    private void OnDestroy()
    {
        EnemyTakeDamage.OnDamageTaken -= OnDamageTaken;
    }

    void OnDamageTaken(GameObject damagedEnemy)
    {
        
        if (isStunned)
        {
            
            float randomValue = Random.value;
            if (randomValue < 0.5f)
            {
                animator.SetTrigger("StunHit1");
            }
            else
            {
                animator.SetTrigger("StunHit2");
            }
        }
        if (!isStarted) { StartCoroutine(AttackRoutine()); }
        isStarted = true;

    }

    private IEnumerator AttackRoutine()
    {
        while (true)
        {
            if (isStunned)
            {
                yield return null;
                continue;
            }

            GetComponentsInChildren<ColliderApplyDamage>()[0].damageApplied = false;
            GetComponentsInChildren<ColliderApplyDamage>()[1].damageApplied = false;

            int maxIndex = enemyTakeDamage.currentHp <= (enemyTakeDamage.maxHp * hpThreshold / 100) ? 4 : 3;

            int randomAttackIndex = Random.Range(0, maxIndex);
            attacks[randomAttackIndex]();

            if (randomAttackIndex == 2 || randomAttackIndex == 3)
            {
                yield return new WaitForSeconds(15f);
            }
            else
            {
                yield return new WaitForSeconds(9f);
            }
        }
    }

    private void Update()
    {
        if (isDead) return;
        if (enemyTakeDamage.currentHp <= 0)
        {
            StopAllCoroutines();
            Die();
        }
        
        healthbar.fillAmount = enemyTakeDamage.currentHp / enemyTakeDamage.maxHp;
        healthtext.text = $" {enemyTakeDamage.currentHp} / {enemyTakeDamage.maxHp}";

        if (enemyTakeDamage.currentHp <= nextStunThreshold)
        {
            StartCoroutine(Stun());
            nextStunThreshold -= enemyTakeDamage.maxHp * 0.25f;
        }
    }

    public void Die()
    {
        CombatEvents.EnemyDied(this);
        navMeshAgent.speed = 0;
        isStunned = false;
        isDead = true;
        animator.SetBool("isStunned", false);
        Dialogue.Instance.StartDialogue(deathdialogueLines);
        animator.SetTrigger("Die");
        Destroy(gameObject);
    }

    private IEnumerator Stun()
    {
        isStunned = true;
        navMeshAgent.isStopped = true;
        animator.SetBool("isStunned", true);
        animator.SetTrigger("Stun");
        DeactivateFlame();
        deactivateBiteCollider();
        deactivateWingCollider();
        StopCoroutine(CastFreezingCircles());
        yield return new WaitForSeconds(stunDuration);
        animator.SetBool("isStunned", false);
        navMeshAgent.isStopped = false;
        isStunned = false;
    }

    private void Attack1()
    {
        transform.LookAt(player);
        animator.SetTrigger("Attack1");
    }

    private void Attack2()
    {
        transform.LookAt(player);
        animator.SetTrigger("Attack2");
    }

    private void Attack3()
    {
        transform.LookAt(player);
        animator.SetTrigger("Attack3");
    }

    private void SpellCast()
    {
        transform.LookAt(player);
        animator.SetTrigger("Cast");
        StartCoroutine(CastFreezingCircles());
    }

    private IEnumerator CastFreezingCircles()
    {
        for (int i = 0; i < 5; i++)
        {
            Instantiate(freezingCirclePrefab, player.position, Quaternion.identity);
            yield return new WaitForSeconds(2.5f);
        }
    }

    public void ActivateFlame()
    {
        DragonFlame.SetActive(true);
    }

    public void DeactivateFlame()
    {
        DragonFlame.SetActive(false);
    }

    public void activateBiteCollider()
    {
        BiteCollider.enabled = true;
    }

    public void deactivateBiteCollider()
    {
        BiteCollider.enabled = false;
    }

    public void activateWingCollider()
    {
        WingCollider.enabled = true;
    }

    public void deactivateWingCollider()
    {
        WingCollider.enabled = false;
    }

}
