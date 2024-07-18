using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class GroundItem : MonoBehaviour , IInteractable
{
    public static GroundItem Instance;
    public ItemObject item;
    public int lootamount;
    public GameObject lootPackage;
    public InventoryObject inventory;
    public TextMeshProUGUI nametext;
    public AudioClip pickUpClip;


    private void Start()
    {
        nametext = GetComponentInChildren<TextMeshProUGUI>();
        nametext.text = item.name + (lootamount > 1 ? " (" + lootamount + ")" : "");
    }
    private void Awake()
    {
        Instance = this;
    }
    public void Interact()
    {
        Item _item = new Item(item);
        inventory.AddItem(_item, lootamount);
        AudioManager.instance.PlayForOnce(pickUpClip);
        Destroy(gameObject);
    }

}
