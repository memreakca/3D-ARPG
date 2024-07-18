using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour, IInteractable
{
    public ItemObject item;
    public int amount;
    public InventoryObject inventory;
    [SerializeField]public AudioClip pickupSound;
    private void Start()
    {

    }
    public void Interact()
    {
        Debug.Log("interacted wtih player");
        Item _item = new Item(item);
        AudioManager.instance.PlayForOnce(pickupSound);
        inventory.AddItem(_item, amount);
        Destroy(gameObject);
    }
}