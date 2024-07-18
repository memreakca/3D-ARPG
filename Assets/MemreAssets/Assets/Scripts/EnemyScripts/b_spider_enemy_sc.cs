using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class b_spider_enemy_sc : MonoBehaviour , IEnemy
{
    public int EnemyID { get; set; }
    public int Experience { get; set; }

    public Animator anim;


    public float timeBetweenAttacks = 2f;
    public float attackCd;
    private SphereCollider attackHitbox;
    public Transform player;
    [SerializeField] public float damage = 30f;
    public float attackRange;
    public bool isAttacking;
    public bool isdead = false;
    public float hp;
    public int maxHp;
    private NavMeshAgent navMeshAgent;
    public EnemyTakeDamage enemytakendmg;
    public bool isMoving = true;
    private SpawnerNest spawnerNest;
    private void Start()
    {
        float dmg = GetComponentInChildren<ColliderApplyDamage>().damageAmount = damage;
        attackCd = timeBetweenAttacks;
        Experience = 250;
        EnemyID = 3;
        hp = maxHp;
        enemytakendmg = GetComponent<EnemyTakeDamage>();
        enemytakendmg.maxHp = maxHp;
        enemytakendmg.currentHp = hp;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        attackHitbox = GetComponentInChildren<SphereCollider>();
        spawnerNest = GetComponentInParent<SpawnerNest>();

    }
    private void Update()
    {
        if (isdead) return;
        if (enemytakendmg.currentHp <= 0) Die();

        attackCd -= Time.deltaTime;

        MoveTowardsPlayer();
        CheckForAttack();

    }

    public void EnableHitbox()
    {
        attackHitbox.enabled = true;
    }

    public void DisableHitbox()
    {
        attackHitbox.enabled = false;
    }
    public void Attack()
    {
        transform.LookAt(player);
        anim.SetBool("isMoving", false);
        isMoving = false;
        navMeshAgent.isStopped = true;

        Attack1();
       

    }

    private void Attack1()
    {
        isAttacking = true;
        anim.SetTrigger("Attack1");
    }
    private void Attack2()
    {
        transform.LookAt(player);
        anim.SetBool("isMoving", false);
        isMoving = false;
        navMeshAgent.isStopped = true;
        isAttacking = true;
        anim.SetTrigger("Attack2");
    }
    public void Die()
    {
        if (spawnerNest != null)
        {
            spawnerNest.EnemyDied();
        }
        navMeshAgent.isStopped = true;
        isdead = true;
        CombatEvents.EnemyDied(this);
        anim.SetTrigger("Die");

    }

    public void RollForRangedAttack()
    {
        if (isdead || isAttacking) { return; }
        float randomvalue = Random.value;
        if (randomvalue < 0.1) 
        {
            Attack2();
        }
    }
    public void MoveTowardsPlayer()
    {
        if (isdead || isAttacking) { return; }

        navMeshAgent.SetDestination(player.position);
        anim.SetBool("isMoving", true);
    }
    void CheckForAttack()
    {
        if (isAttacking) { return; }
        if (Vector3.Distance(transform.position, player.position) < attackRange)
        {

            if (attackCd > 0) 
            { 
                anim.SetBool("isMoving", false);
                return;
            }
            Attack();
        }
    }

    public void DestoryGameObject()
    {
        Destroy(gameObject);
    }

    public void FinishAtttack()
    {
        navMeshAgent.isStopped = false;
        attackCd = timeBetweenAttacks;
        isMoving = true;
        isAttacking = false;
        anim.SetBool("isMoving", true);
        bool damageapplied = GetComponentInChildren<ColliderApplyDamage>().damageApplied = false;

    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
