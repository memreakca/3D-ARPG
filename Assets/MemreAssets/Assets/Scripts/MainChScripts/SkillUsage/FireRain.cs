using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRain : MonoBehaviour
{
    [SerializeField]private GameObject parent;
    public int RainDPS = 5;
    [SerializeField]
    private FireThrowerRadius AttackRadius;

    private void Start()
    {
        RainDPS = Mathf.RoundToInt(PlayerSkill.instance.rangedskill2.damage);
        Invoke("destroyGameObject", 4);
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
            burnable.StartBurning(RainDPS);

        }
    }

    private void StopDamagingEnemy(EnemyTakeDamage Enemy)
    {
        Enemy.StopBurning();
    }

    private void destroyGameObject()
    {
        Destroy(parent);
    }
}
