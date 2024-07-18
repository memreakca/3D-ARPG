using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class needles_enemy_sc : MonoBehaviour, IEnemy
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
    private NavMeshAgent navMeshAgent;
    public bool isMoving = true;
    public EnemyTakeDamage enemytakendmg;
    void Start()
    {
        EnemyID = 12;
        Experience = 250;
        float dmg = GetComponentInChildren<ColliderApplyDamage>().damageAmount = damage;
        attackCd = timeBetweenAttacks;
        enemytakendmg = GetComponent<EnemyTakeDamage>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        attackHitbox = GetComponentInChildren<SphereCollider>();
        attackHitbox.enabled = false;
        navMeshAgent.stoppingDistance = attackRange;
    }

    void Update()
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
        bool damageapplied = GetComponentInChildren<ColliderApplyDamage>().damageApplied = false;
        attackHitbox.enabled = false;
    }

    public void Attack()
    {
        transform.LookAt(player);
        anim.SetTrigger("Attack");
        anim.SetBool("isMoving", false);
        isAttacking = true;
        isMoving = false;
        navMeshAgent.isStopped = true;
    }

    public void Die()
    {
        navMeshAgent.isStopped = true;
        isdead = true;
        CombatEvents.EnemyDied(this);
        anim.SetTrigger("Die");

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

            if (attackCd > 0) { anim.SetBool("isMoving", false); return; }
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

    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
