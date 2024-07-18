using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[DisallowMultipleComponent]
public class DragonFlameRadius : MonoBehaviour
{
    public delegate void PlayerEnteredEvent(Player player);
    public event PlayerEnteredEvent OnPlayerEnter;

    public delegate void PlayerExitedEvent(Player player);
    public event PlayerExitedEvent OnPlayerExit;

    private List<Player> playersInRadius = new List<Player>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            playersInRadius.Add(player);
            OnPlayerEnter?.Invoke(player);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            playersInRadius.Remove(player);
            OnPlayerExit?.Invoke(player);
        }
    }

    private void OnDisable()
    {
        foreach (Player player in playersInRadius)
        {
            OnPlayerExit?.Invoke(player);
        }

        playersInRadius.Clear();
    }

}