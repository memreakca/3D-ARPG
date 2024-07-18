using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEvents : MonoBehaviour
{
    public static PlayerEvents instance;

    public delegate void PlayerDeathEventHandler();
    public static event PlayerDeathEventHandler OnPlayerDeath;

    public delegate void PlayerRespawnEventHandler();
    public static event PlayerRespawnEventHandler OnPlayerRespawn;

    [SerializeField] public Transform respawnPoint;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void TriggerPlayerDeath()
    {
        OnPlayerDeath?.Invoke();
    }

    public void TriggerPlayerRespawn()
    {
        OnPlayerRespawn?.Invoke();
    }
}
