using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderApplyDamage : MonoBehaviour
{
    public float damageAmount;
    public bool damageApplied = false;
  
    private void OnTriggerEnter(Collider other)
    {
        if (!damageApplied && other.TryGetComponent(out Player player))
        {
            player.TakeDamage(damageAmount);
            damageApplied = true;
        }
    }
}
