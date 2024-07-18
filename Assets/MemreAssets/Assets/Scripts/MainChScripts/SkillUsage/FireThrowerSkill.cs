    using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class FireThrowerSkill : MonoBehaviour
{

    public int BurningDPS = 5;
    [SerializeField]
    private FireThrowerRadius AttackRadius;

    private void Start()
    {
        BurningDPS = Mathf.RoundToInt(PlayerSkill.instance.rangedskill1.damage);
        
    }
    private void Awake()
    {
        AttackRadius = GetComponent<FireThrowerRadius>();
        AttackRadius.OnEnemyEnter += StartDamagingEnemy;
        AttackRadius.OnEnemyExit += StopDamagingEnemy;
    }

    private void StartDamagingEnemy(EnemyTakeDamage Enemy)
    {
        
        if (Enemy.TryGetComponent(out IBurnable burnable))
        {
            burnable.StartBurning(BurningDPS);

        }
    }
    
    private void StopDamagingEnemy(EnemyTakeDamage Enemy)
    {
        Enemy.StopBurning();
    }
}
