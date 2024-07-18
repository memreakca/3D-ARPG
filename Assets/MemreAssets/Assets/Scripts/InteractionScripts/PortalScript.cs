using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalScript : MonoBehaviour , IInteractable
{
    public Transform playerTransform;
    [SerializeField] public Transform ForestEntrancePoint;
    
    private void Start()
    {
        playerTransform = Player.main.gameObject.transform;
    }

    public void Interact()
    {
        if (playerTransform != null && ForestEntrancePoint != null)
        {
            playerTransform.position = ForestEntrancePoint.position;
            Player.main.AssignRespawnPoint();
            Player.main.SaveEverything();
            NotificationEvents.Notify("Oyun kaydedildi", null);
        }
        else
        {
            Debug.LogWarning("Player Transform or Dungeon Entrance Point is not set.");
        }
    }
}
