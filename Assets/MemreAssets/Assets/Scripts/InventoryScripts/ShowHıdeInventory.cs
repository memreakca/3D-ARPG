using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHıdeInventory : MonoBehaviour
{
    [SerializeField] public GameObject CraftingUI;
    [SerializeField] public GameObject inventoryUI;
    [SerializeField] public GameObject EquipmentUI;
    
    public bool isInventoryVisible;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            ToggleInventory();
        }
    }


    public void ToggleInventory()
    {
        if(isInventoryVisible) { Time.timeScale = 1f; } else { Time.timeScale = 0f; }
        CraftingUI.SetActive(false);
        isInventoryVisible = !isInventoryVisible;
        inventoryUI.SetActive(isInventoryVisible);
        EquipmentUI.SetActive(isInventoryVisible);
        
    }
}
