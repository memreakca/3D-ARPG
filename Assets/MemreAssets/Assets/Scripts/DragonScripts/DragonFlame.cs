using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonFlame : MonoBehaviour
{
    public int burningDPS = 5;
    [SerializeField]
    private DragonFlameRadius attackRadius;

    private void Start()
    {
     
    }

    private void Awake()
    {
        attackRadius = GetComponent<DragonFlameRadius>();
        attackRadius.OnPlayerEnter += StartDamagingPlayer;
        attackRadius.OnPlayerExit += StopDamagingPlayer;
    }

    private IEnumerator ApplyDamageOverTime(Player player)
    {
        while (true)
        {
            player.TakeDamage(burningDPS);
            yield return new WaitForSeconds(1f); 
        }
    }

    private void StartDamagingPlayer(Player player)
    {
        if (player != null)
        {
            StartCoroutine(ApplyDamageOverTime(player));
        }
    }

    private void StopDamagingPlayer(Player player)
    {
        StopAllCoroutines(); 
    }
}
