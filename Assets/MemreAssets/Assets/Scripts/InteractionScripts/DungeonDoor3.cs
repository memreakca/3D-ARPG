using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonDoor3 : MonoBehaviour , IInteractable
{

    public void Interact()
    {
        
            if (Player.main.inventory.ContainsItem(Player.main.inventory.database.Items[15].data, 1))
            {
                gameObject.SetActive(false);
                Player.main.inventory.RemoveAmount(Player.main.inventory.database.Items[15].data, 1);
                NotificationEvents.Notify("Kapý açýldý yuvayý yok et!",null);
            }
            else
            {
                NotificationEvents.Notify("You dont have the Key", null);
            }
    }
}
