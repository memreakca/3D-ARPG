using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bear_enemy_sc : MonoBehaviour , IEnemy
{
    public int EnemyID { get ; set; }
    public int Experience { get ; set ; }

    public Animator animator;

    public float handdamage;
    public float doubleHandDamage;


    public bool isAttacking;
    public bool isRunning;
    public bool isMoving;
    public bool isWaiting;

    public float patrolRadius = 5f;
    public float patrolInterval = 3f;  
    public float attackRange = 1f;
    public float sightRange = 10f;
    public float attackDuration = 1f;
    public float timeBetweenAttacks = 1f;

    public float speed;
    public float runSpeed;

    [SerializeField] public Transform patrolPoint;
    private NavMeshAgent navMeshAgent;
    private float timer;
    private Transform player;
    private SphereCollider handhitbox;
    private SphereCollider doublehandhitbox;
    public float doubledSightRange;
    public float normalSightRange;
    public EnemyTakeDamage enemytakendmg;
    public bool isdead = false;
    public void Start()
    {
        EnemyID = 4;
        Experience = 500;
        enemytakendmg = GetComponent<EnemyTakeDamage>();
        float hnddmg = GetComponentsInChildren<ColliderApplyDamage>()[1].damageAmount = handdamage;
        float dbhnddmg = GetComponentsInChildren<ColliderApplyDamage>()[0].damageAmount = doubleHandDamage;
        normalSightRange = sightRange;
        doubledSightRange = sightRange * 2;
        handhitbox = GetComponentsInChildren<SphereCollider>()[1];
        doublehandhitbox = GetComponentsInChildren<SphereCollider>()[0];
        handhitbox.enabled = false;
        doublehandhitbox.enabled = false;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        navMeshAgent.stoppingDistance = attackRange;
        EnemyTakeDamage.OnDamageTaken += OnDamageTaken;
    }
     void Update()
    {
        if (isdead) return;
        if (enemytakendmg.currentHp <= 0) Die();

        timeBetweenAttacks -= Time.deltaTime;
        if (navMeshAgent != null)
        {
            if (isAttacking) return;
            if (timeBetweenAttacks > 0) return;

            if (CanSeePlayer())
            {
                navMeshAgent.speed = runSpeed;
                MoveTowardsPlayer();
                CheckForAttack();
            }
            else
            {
                navMeshAgent.speed = speed;
                Patrol();
            }
        }
        
    }
    public void Attack()
    {
        
        navMeshAgent.isStopped = true;
        float randomValue = Random.value;
        isAttacking = true;
        transform.LookAt(player);
        animator.SetBool("isMoving", false);
        animator.SetBool("isRunning", false);
        if (randomValue < 0.5f)
        {
            Attack1();
        }
        else
        {
            Attack2();
        }

     
    }

    private void Attack1()
    {
        animator.SetTrigger("Attack1");
    }
    private void Attack2()
    {
        animator.SetTrigger("Attack2");
    }
    public void Die()
    {
        CombatEvents.EnemyDied(this);
        navMeshAgent.speed = 0;
        isdead = true;
        animator.SetTrigger("Die");
        animator.SetBool("isRunning", false);
        animator.SetBool("isMoving", false);

    }


    void MoveTowardsPlayer()
    {
        
        navMeshAgent.stoppingDistance = attackRange;
        sightRange = doubledSightRange;
        navMeshAgent.SetDestination(player.position);

            if (navMeshAgent.pathStatus == NavMeshPathStatus.PathPartial || navMeshAgent.pathStatus == NavMeshPathStatus.PathInvalid)
            {
                Debug.LogWarning("Path is invalid or incomplete.");
                navMeshAgent.isStopped = true;
                return;
            }

        animator.SetBool("isMoving", false);
        animator.SetBool("isRunning", true);
            

        navMeshAgent.isStopped = false;

        isAttacking = false;
        
            if(!CanSeePlayer())
            {
                navMeshAgent.isStopped = true;
                animator.SetBool("isRunning", false);
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
        else if (navMeshAgent.remainingDistance < 1f)
        {
            
            isWaiting = true;
            timer = patrolInterval;
            animator.SetBool("isMoving", false);
            animator.SetBool("isRunning", false);
        }
        
        animator.SetBool("isMoving", !isWaiting && !CanSeePlayer());
        animator.SetBool("isRunning", false);
        if (!isAttacking)
        {
            navMeshAgent.isStopped = false;
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
            if(!CanSeePlayer()) 
            MoveTowardsPlayer();
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
            Attack();
        }
        else
        {
            animator.SetBool("isRunning", true);
        }


    }
    private void enableHandHitbox()
    {
        handhitbox.enabled = true;
    }

    private void enableDoubleHandHitbox()
    {
        doublehandhitbox.enabled =true;
    }
    private void disableHandHitbox()
    {
        handhitbox.enabled = false;
    }

    private void disableDoubleHandHitbox()
    {
        doublehandhitbox.enabled = false;
    }

    private void resetAttack()
    {

        bool damageapplied0 = GetComponentsInChildren<ColliderApplyDamage>()[0].damageApplied = false;
        bool damageapplied1 = GetComponentsInChildren<ColliderApplyDamage>()[1].damageApplied = false;
        timeBetweenAttacks = attackDuration;
        isAttacking = false;
        animator.SetBool("Attack2", false);
        animator.SetBool("Attack1", false);
    }
    public void DestroyGameObject()
    {
        Destroy(gameObject);
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
