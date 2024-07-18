using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class plant_enemy_sc : MonoBehaviour , IEnemy
{
    public int EnemyID { get; set; }
    public int Experience { get; set; }

    public Animator animator;
    public float attackRange = 1f;
    public float biteDamage;

    public float timeBetweenAttacks ;
    public float attackCd = 5f;
    public EnemyTakeDamage enemytakendmg;
    public bool isdead = false;
    private NavMeshAgent navMeshAgent;
    private Transform player;
    private SphereCollider biteHitbox;
    void Start()
    {
        EnemyID = 9;
        Experience = 400;
        enemytakendmg = GetComponent<EnemyTakeDamage>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        biteHitbox = GetComponentInChildren<SphereCollider>();
        biteHitbox.enabled = false;
        float bitedamage = GetComponentInChildren<ColliderApplyDamage>().damageAmount = biteDamage;
    }

    void Update()
    {
        if (isdead) return;
        if (enemytakendmg.currentHp <= 0) Die();

        timeBetweenAttacks -= Time.deltaTime;
        if (navMeshAgent != null)
        {
            if (timeBetweenAttacks > 0) return;

            if (CanSeePlayer())
            {
                CheckForAttack();
            }
        }
    }
    public void Attack()
    {
        transform.LookAt(player);
        animator.SetTrigger("Attack");
        timeBetweenAttacks = attackCd;

    }
    public void FinishAtttack()
    {
        bool damageapplied = GetComponentInChildren<ColliderApplyDamage>().damageApplied = false;
    }
    void CheckForAttack()
    {

        if (Vector3.Distance(transform.position, player.position) < attackRange)
        {
            Attack();
        }
    }
    bool CanSeePlayer()
    {
        return Vector3.Distance(transform.position, player.position) <= attackRange;
    }
    public void Die()
    {
        CombatEvents.EnemyDied(this);
        isdead = true;
        animator.SetTrigger("Die");
    }
    private void enablebiteHitbox()
    {
        biteHitbox.enabled = true;
    }
    private void disablebiteHitbox()
    {
        biteHitbox.enabled = false;
    }
    public void DestroyGameObject()
    {
        Destroy(gameObject);
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
