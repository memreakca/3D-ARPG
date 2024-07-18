using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwordDamage : MonoBehaviour
{
    public float damageAmount;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out EnemyTakeDamage enm))
        {           
            enm.TakeDamage(damageAmount);
        }
    }
}
