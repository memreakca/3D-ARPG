using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class stone_enemy_patrol : MonoBehaviour
{
    public float patrolRadius = 5f;
    public float patrolInterval = 3f;  // Time interval to choose a new random destination
    public float attackRange = 1f;
    public float sightRange = 10f;
    public float attackDuration = 2.5f;
    public float timeBetweenAttacks = 1f;

    public stone_enemy_sc instance;
    [SerializeField] public Transform patrolPoint;
    private NavMeshAgent navMeshAgent;
    private float timer;
    private Transform player;
    private Animator animator;
    private bool isWaiting;
    private bool isAttacking;
    private SphereCollider handhitbox;
    public float doubledSightRange;
    public float normalSightRange;

    


    void Start()
    {
        
        normalSightRange = sightRange;
        doubledSightRange = sightRange * 2;
        handhitbox = GetComponentsInChildren<SphereCollider>()[0];
        handhitbox.enabled = false;
        instance = gameObject.GetComponent<stone_enemy_sc>(); 
        player = GameObject.FindGameObjectWithTag("Player").transform;
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        navMeshAgent.stoppingDistance = attackRange;
        timer = patrolInterval;
        SetRandomPatrolDestination(); 
        isWaiting = false;
        isAttacking = false;
        EnemyTakeDamage.OnDamageTaken += OnDamageTaken;
    }
   
    void Update()
    {
        
        timeBetweenAttacks -= Time.deltaTime;

        if (navMeshAgent != null)
        {
            if (isAttacking) return;
            if (timeBetweenAttacks > 0) return;

            if (CanSeePlayer())
            {
                MoveTowardsPlayer();
                CheckForAttack();
            }
            else
            {
                Patrol();
            }
        }
    }
    private void OnDestroy()
    {
        EnemyTakeDamage.OnDamageTaken -= OnDamageTaken;
    }

    void OnDamageTaken(GameObject damagedEnemy)
    {
        if (damagedEnemy == gameObject)
        {
            if (!CanSeePlayer())
                MoveTowardsPlayer();
        }
    }
    void MoveTowardsPlayer()
    {
        navMeshAgent.stoppingDistance = attackRange;
        sightRange = doubledSightRange;
        navMeshAgent.SetDestination(player.position);

        animator.SetBool("isMoving", true);


        navMeshAgent.isStopped = false;

        isAttacking = false;

        if (!CanSeePlayer())
        {
            navMeshAgent.isStopped = true;
            animator.SetBool("isMoving", false);
        }
    }
    bool CanSeePlayer()
    {
        return Vector3.Distance(transform.position, player.position) <= sightRange;
    }
    void Patrol()
    {
        navMeshAgent.stoppingDistance = 0f;
        sightRange = normalSightRange;

        if (isWaiting)
        {
            timer -= Time.deltaTime;

            if (timer <= 0f)
            {
                isWaiting = false;
                SetRandomPatrolDestination();
            }
        }
        else if (navMeshAgent.remainingDistance < 0.4f)
        {
            isWaiting = true;
            timer = patrolInterval;
        }
        animator.SetBool("isMoving", !isWaiting && !CanSeePlayer());
        animator.SetBool("isAttacking", false);


        if (!isAttacking)
        {
            navMeshAgent.isStopped = false;
        }
    }

  
    void SetRandomPatrolDestination()
    {
        NavMeshHit hit;
        Vector3 randomPoint = transform.position;

        for (int i = 0; i < 30; i++) 
        {
            Vector2 randomOffset = UnityEngine.Random.insideUnitCircle * patrolRadius;
            randomPoint = patrolPoint.position + new Vector3(randomOffset.x, 0f, randomOffset.y);

            if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
            {
                break; 
            }
        }

        navMeshAgent.SetDestination(randomPoint);
    }

    void CheckForAttack()
    {
        
        if (Vector3.Distance(transform.position, player.position) < attackRange)
        {
            AttackPlayer();
        }
        else
        {
            animator.SetBool("isMoving", true);
            animator.SetBool("isAttacking", false);
        }
        
        
    }
    void AttackPlayer()
    {
        transform.LookAt(player);
        animator.SetBool("isMoving", false);
        animator.SetBool("isAttacking", true);
        navMeshAgent.isStopped = true;

        if (!isAttacking)
        {
            isAttacking = true;

            Invoke("FinishAttack", attackDuration);
        
        }
    }
    void activateHandHitboxes()
    {
        handhitbox.enabled= true;
    }
    void deactivateHandHitboxes()
    {
        handhitbox.enabled = false;
        
    }
    void FinishAttack()
    {

        isAttacking= false;
        timeBetweenAttacks = 3;
        animator.SetBool("isAttacking", false);
        navMeshAgent.isStopped = false;
        bool damageapplied = GetComponentInChildren<ColliderApplyDamage>().damageApplied = false;
    }


    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(patrolPoint.position, patrolRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
