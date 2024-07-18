using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.UI;
public class stone_enemy_sc : MonoBehaviour , IEnemy
{
    public int EnemyID { get; set; }
    public int Experience { get; set; }
    public static stone_enemy_sc instance;
    public Animator animator;

    public float damage;
    public EnemyTakeDamage enemytakendmg;
    private NavMeshAgent navMeshAgent;
    public bool isdead = false;

    public UnityEvent OnEnemyDeath;

    private void Start()
    {
        enemytakendmg = GetComponent<EnemyTakeDamage>();

        navMeshAgent = GetComponent<NavMeshAgent>();
        EnemyID = 1;
        Experience = 250;
    }
    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (isdead) return;
        if (enemytakendmg.currentHp <= 0) Die();
    }

    public void Die()
    {
        CombatEvents.EnemyDied(this);
        OnEnemyDeath.Invoke();
        Invoke("DestroyGameObject", 1.75f);
        isdead = true;
        navMeshAgent.speed = 0;
        animator.SetTrigger("Die");
        animator.SetBool("isMoving", false);
        animator.SetBool("isAttacking", false);
    }
    void DestroyGameObject()
    {
        Destroy(gameObject);
    }

}
