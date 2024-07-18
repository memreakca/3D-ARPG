using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkForestGate : MonoBehaviour, IInteractable
{
    public GameObject lastDoor;
    public void Interact()
    {
        
        if (Player.main.inventory.ContainsItem(Player.main.inventory.database.Items[19].data, 1))
        {
            Player.main.inventory.RemoveAmount(Player.main.inventory.database.Items[19].data, 1);
            NotificationEvents.Notify("Geçit Açýldý Acaba Seni Ne bekliyor", null);
            lastDoor.SetActive(false);
        }
        else
        {
            var npc = gameObject.GetComponent<NPC>();
            npc.Interact();
        }
    }
}