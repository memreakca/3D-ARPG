using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeCircleScript : MonoBehaviour
{
    public CapsuleCollider CapsCollider;
    public int damageAmount = 10; 
    private bool canDealDamage = false;

    void Start()
    {
        CapsCollider = GetComponent<CapsuleCollider>();
        CapsCollider.enabled = false;
        StartCoroutine(HandleDamageAndDestruction());
    }

    private IEnumerator HandleDamageAndDestruction()
    {
        yield return new WaitForSeconds(1.25f);
        CapsCollider.enabled = true;
        canDealDamage = true;

        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (canDealDamage && other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                player.TakeDamage(damageAmount);
            }
        }
    }
}
