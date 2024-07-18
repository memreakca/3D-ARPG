using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[DisallowMultipleComponent]
public class FireThrowerRadius : MonoBehaviour
{
    public delegate void EnemyEnteredEvent(EnemyTakeDamage Enemy);
    public event EnemyEnteredEvent OnEnemyEnter;
    
    public delegate void EnemyExitedEvent(EnemyTakeDamage Enemy);
    public event EnemyEnteredEvent OnEnemyExit;

    private List<EnemyTakeDamage> EnemiesInRadius = new List<EnemyTakeDamage>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out EnemyTakeDamage enemy))
        {
            EnemiesInRadius.Add(enemy);
            OnEnemyEnter?.Invoke(enemy);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out EnemyTakeDamage enemy))
        {
            EnemiesInRadius.Remove(enemy);
            OnEnemyExit?.Invoke(enemy);
        }
    }

    private void OnDisable()
    {
        foreach (EnemyTakeDamage enemy in EnemiesInRadius)
        {
            OnEnemyExit?.Invoke(enemy);
        }

        EnemiesInRadius.Clear();
    }

}
