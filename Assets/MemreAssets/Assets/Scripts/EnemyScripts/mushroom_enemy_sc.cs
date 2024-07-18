using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class mushroom_enemy_sc : MonoBehaviour, IEnemy
{
    public int EnemyID { get ; set ; }
    public int Experience { get ; set ; }

    public Animator anim;


    public bool isdead;

    public float attackRange;
    public float damage;

    public GameObject ExplosionEffect;

    public bool isActivated = false;

    private NavMeshAgent navMeshAgent;
    public Transform player;
    
    public EnemyTakeDamage enemytakendmg;

    private void Start()
    {
        Experience = 200;
        EnemyID = 5;
        navMeshAgent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemytakendmg = GetComponent<EnemyTakeDamage>();
        anim = GetComponent<Animator>();
        EnemyTakeDamage.OnDamageTaken += OnDamageTaken;
    }

    private void OnDestroy()
    {
        EnemyTakeDamage.OnDamageTaken -= OnDamageTaken;
    }

    void OnDamageTaken(GameObject damagedEnemy)
    {
        if (damagedEnemy == gameObject)
        {
            GetComponentInParent<MushroomPack>().ActivateMushrooms();
        }
    }
    public void Attack()
    {
        navMeshAgent.SetDestination(player.position);
        anim.SetBool("isMoving", true);
       
    }

    private void Update()
    {
        if (isdead) return;
        if (enemytakendmg.currentHp <= 0) Die();
        CheckForExplosion();

        if (isActivated)
        {
            Attack();
            ExplosionEffect.SetActive(true);
        }
        

    }
    public void Die()
    {
        navMeshAgent.isStopped = true;
        isdead = true;
        CombatEvents.EnemyDied(this);
        anim.SetTrigger("Die");
        //int randomNumber = Random.Range(1, 101);
        //if (randomNumber < 6) { SpawnLoot(); }
    }

    public void Explode()
    {
        isdead = true; isActivated = false;
        navMeshAgent.isStopped = true;
        Player.main.TakeDamage(damage);
        DestoryGameObject();
        
    }

    void CheckForExplosion()
    {
        if (Vector3.Distance(transform.position, player.position) < attackRange)
        {
            Explode();
        }
    }
    public void DestoryGameObject()
    {
        Destroy(gameObject);
    }

}
