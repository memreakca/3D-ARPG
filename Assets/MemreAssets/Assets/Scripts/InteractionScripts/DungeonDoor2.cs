using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonDoor2 : MonoBehaviour , IInteractable
{

    public void Interact()
    {
        
            if (Player.main.inventory.ContainsItem(Player.main.inventory.database.Items[14].data, 1))
            {
                gameObject.SetActive(false);
                Player.main.inventory.RemoveAmount(Player.main.inventory.database.Items[14].data, 1);
                NotificationEvents.Notify("Kapý açýldý , Çok Yaklaþma Canavarlar Uyanýcak!",null);
            }
            else
            {
                NotificationEvents.Notify("You dont have the Key", null);
            }
    }
}
