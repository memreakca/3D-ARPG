using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonLastDoor : MonoBehaviour , IInteractable
{
    [SerializeField] public GameObject[] spawners;
    public GameObject lastDoor;
    public void Interact()
    { 
        if (Player.main.inventory.ContainsItem(Player.main.inventory.database.Items[16].data, 1))
        {
            Player.main.inventory.RemoveAmount(Player.main.inventory.database.Items[16].data, 1);
            NotificationEvents.Notify("Yanl�� anahtar denendi t�m yuvalar tekrardan aktif!",null);
            var npc = gameObject.GetComponent<NPC>();
            npc.Interact();

            for (int i = 0;i< spawners.Length; i++)
            {
                spawners[i].SetActive(true);
            }
        }
        else
        {
            var npc = gameObject.GetComponent<NPC>();
            npc.Interact();
            NotificationEvents.Notify("Anahtara Sahip De�ilsin", null);
        }

        if (Player.main.inventory.ContainsItem(Player.main.inventory.database.Items[17].data, 1))
        {
            Player.main.inventory.RemoveAmount(Player.main.inventory.database.Items[17].data, 1);
            NotificationEvents.Notify("Kap� A��ld� Ormana ula�mak i�in Portaldan ge�", null);
            lastDoor.SetActive(false);
        }
    }
}
