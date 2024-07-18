using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonEntrance : MonoBehaviour, IInteractable
{
    public Transform playerTransform;
    [SerializeField] public Transform dungeonEntrancePoint;
    public GameObject Forest;
    public GameObject Dungeon;
    private void Start()
    {
        playerTransform = GameObject.FindGameObjectsWithTag("Player")[0].transform;
    }
    public void Interact()
    {
        if (playerTransform != null && dungeonEntrancePoint != null)
        {
            if (Player.main.inventory.ContainsItem(Player.main.inventory.database.Items[12].data, 1))
            {
                playerTransform.position = dungeonEntrancePoint.position;
                Player.main.AssignRespawnPoint();
                Player.main.SaveEverything();
                NotificationEvents.Notify("Oyun kaydedildi", null);
            }
            else
            {
                NotificationEvents.Notify("You dont have the Key", null);
            }
        }
        else
        {
            Debug.LogWarning("Player Transform or Dungeon Entrance Point is not set.");
        }
    }
}