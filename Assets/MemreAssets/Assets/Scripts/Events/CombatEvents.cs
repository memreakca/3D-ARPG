using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatEvents : MonoBehaviour
{
    public delegate void EnemyEventHandler(IEnemy enemy);
    public static event EnemyEventHandler OnEnemyDeathC;

    public static void EnemyDied(IEnemy enemy)
    {
        if (OnEnemyDeathC != null)
            OnEnemyDeathC(enemy);
    }
}
