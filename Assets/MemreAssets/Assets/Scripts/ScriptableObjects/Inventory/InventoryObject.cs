using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEditor;
using JetBrains.Annotations;
using System.Runtime.Serialization;
using System;

public enum InterfaceType
{
    Inventory,
    Equipment,
    Chest
}
[CreateAssetMenu(fileName = "New Inventory",menuName ="Inventory System/Inventory")]
public class InventoryObject : ScriptableObject 
{
    public InterfaceType type;
    public string savePath;
    public ItemDatabaseObject database;
    public Inventory Container;
    public InventorySlot[] GetSlots { get {return Container.Items; } }

    public delegate void InventoryChanged();
    public event InventoryChanged OnInventoryChanged;

    public void AddItem(Item _item, int _amount)
    {
        for (int i = 0; i < Container.Items.Length; i++)
        {
            if (database.Items[_item.Id].stackable)
            {

                for (int j = 0; j < GetSlots.Length; j++)
                {

                    if (GetSlots[j].ItemID == _item.Id)
                    {
                        GetSlots[j].AddAmount(_amount);
                        OnInventoryChanged?.Invoke();
                        NotificationEvents.Notify("Eþya Eklendi = " + _item.Name + "  Adet = " + _amount, database.Items[_item.Id].uiDisplay);
                        return;
                    }

                }
            }

            if (GetSlots[i].ItemID <= -1)
            {
                GetSlots[i].UpdateSlot(_item.Id, _item, _amount);
                OnInventoryChanged?.Invoke();
                NotificationEvents.Notify("Eþya Eklendi = " + _item.Name + "  Adet = " + _amount, database.Items[_item.Id].uiDisplay);
                return;
            }


        }
        Debug.Log("Inventory Full");
    }
    public void UseConsumable(ItemObject consumableItem, int amount)
    {
        for (int i = 0; i < Container.Items.Length; i++)
        {
            if (Container.Items[i].ItemID == consumableItem.data.Id)
            {
                Container.Items[i].UseAmount(amount);
                RemoveAmountlessItem(); // Adjust as needed
                OnInventoryChanged?.Invoke();
                return;
            }
        }

        Debug.Log("Consumable not found in the inventory.");
    }
    public bool ContainsItem(Item _item, int _amount)
    {

        for (int i = 0; i < GetSlots.Length; i++)
        {
            if (GetSlots[i].ItemID == _item.Id && GetSlots[i].amount >= _amount)
            {
                return true;
            }
        }
        return false;
    }

    public int GetItemAmount(Item _item)
    {
        int totalAmount = 0;
        for (int i = 0; i < GetSlots.Length; i++)
        {
            if (GetSlots[i].ItemID == _item.Id)
            {
                totalAmount += GetSlots[i].amount;
            }
        }
        return totalAmount;
    }
    public bool HasItemType(Enum type)
    {
        
        for (int i = 0; i < GetSlots.Length; i++)
        {
            if (GetSlots[i].ItemObject == null) continue;
            if (GetSlots[i].ItemObject.type.Equals(type))   
            {
                return true;
            }
        }
        return false;
    }

    public void SwapItems(InventorySlot item1,InventorySlot item2)
    {
        if(item2.CanPlaceInSlot(item1.ItemObject) && item1.CanPlaceInSlot(item2.ItemObject))
        {
            InventorySlot temp = new InventorySlot(item2.ItemID,item2.item, item2.amount);
            item2.UpdateSlot(item1.ItemID, item1.item, item1.amount);
            item1.UpdateSlot(temp.ItemID, temp.item, temp.amount);
            OnInventoryChanged?.Invoke();
        } 
    }

    public void RemoveItem(Item _item)
    {
        for (int i = 0; i < GetSlots.Length; i++)
        {
            if (GetSlots[i].item == _item)
            {
                GetSlots[i].UpdateSlot(-1,null, 0);
                OnInventoryChanged?.Invoke();
            }
        }
    }
    public void RemoveAmount(Item _item , int _amount )
    {
        for (int i = 0; i < GetSlots.Length; i++)
        {
            if (GetSlots[i].ItemID == _item.Id)
            {
                GetSlots[i].UseAmount(_amount);
                RemoveAmountlessItem();
                OnInventoryChanged?.Invoke();
                return;
            }
        }

    }
    public void RemoveAmountlessItem()
    {
        for (int i = 0; i < GetSlots.Length; i++)
        {
            if (GetSlots[i].amount <= 0)
            {
                GetSlots[i].UpdateSlot(-1, null, 0);
                OnInventoryChanged?.Invoke();
            }
        }
    }
    public InventorySlot SetEmptySlot(Item _item , int _amount)
    {
        for (int i = 0;i < GetSlots.Length; i++)
        {
            if (GetSlots[i].ItemID <= -1)
            {
                GetSlots[i].UpdateSlot(-1, _item, _amount);
                OnInventoryChanged?.Invoke();
                return GetSlots[i];
            }
            
        }
        // when inventory full (fill here)
        return null;
    }
    [ContextMenu("Save")]
    public void Save()
    {
        //string saveData = JsonUtility.ToJson(this, true);
        //BinaryFormatter bf = new BinaryFormatter();
        //FileStream file = File.Create(string.Concat(Application.persistentDataPath, savePath));
        //bf.Serialize(file, saveData);
        //file.Close();
        IFormatter formatter = new BinaryFormatter();
        Stream stream = new FileStream(string.Concat(Application.persistentDataPath,savePath),FileMode.Create,FileAccess.Write);
        formatter.Serialize(stream, Container);
        stream.Close();
    }
    [ContextMenu("Load")]
    public void Load()
    {
        if (File.Exists(string.Concat(Application.persistentDataPath, savePath)))
        {
            //    BinaryFormatter bf = new BinaryFormatter();
            //    FileStream file = File.Open(string.Concat(Application.persistentDataPath, savePath), FileMode.Open);
            //    JsonUtility.FromJsonOverwrite(bf.Deserialize(file).ToString(),this);
            //    file.Close();
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(string.Concat(Application.persistentDataPath, savePath), FileMode.Open, FileAccess.Read);
            Inventory newContainer = (Inventory)formatter.Deserialize(stream);
            for (int i = 0; i < GetSlots.Length; i++)
            {
                GetSlots[i].UpdateSlot(newContainer.Items[i].ItemID ,newContainer.Items[i].item, newContainer.Items[i].amount);
            }
            stream.Close();
        }

    }
    [ContextMenu("Clear")]
    public void Clear()
    {
        Container.Clear();
    }
 
}
[System.Serializable]
public class Inventory
{
    public InventorySlot[] Items = new InventorySlot[30];
    public void Clear()
    {
        for (int i = 0; i < Items.Length; i++)
        {
            Items[i].RemoveItem();
        }
    }
}


public delegate void SlotUpdated(InventorySlot _slot);

[System.Serializable]
public class InventorySlot
{
    public int ItemID;
    public ItemType[] AllowedItems = new ItemType[0];

    [System.NonSerialized]
    public UserInterface parent;
    [System.NonSerialized]
    public GameObject slotDisplay;
    [System.NonSerialized]
    public SlotUpdated OnAfterUpdate;
    [System.NonSerialized]
    public SlotUpdated OnBeforeUpdate;

    public Item item = new Item();
    public int amount;

    public ItemObject ItemObject  
    {
        get
        {
            if (ItemID >= 0)
            {
                return parent.inventory.database.Items[item.Id];
            }
            return null;
        }
    }
    public InventorySlot()
    {
        UpdateSlot(-1, new Item(), 0);
    }

    public InventorySlot(int _id,Item _item, int _amount)
    {
        UpdateSlot(_id, _item, _amount);
    }
    public void UpdateSlot(int _id, Item _item, int _amount)
    {   
        if (OnBeforeUpdate != null) { OnBeforeUpdate.Invoke(this); }
        ItemID = _id;
        item = _item;
        amount = _amount;
        if (OnAfterUpdate != null) { OnAfterUpdate.Invoke(this); }
    }

    public void RemoveItem()
    {
        UpdateSlot(-1, new Item(), 0);
    }

    public void AddAmount(int value)
    {
        UpdateSlot(ItemID,item, amount += value);
    }

    public void UseAmount(int value)
    {
        if (amount >= value)
        {
            UpdateSlot(ItemID, item, amount -= value);
        }
        else
        {
            Debug.Log("not enough ingredients");
        }
        
    }
    
    public bool CanPlaceInSlot(ItemObject _itemObject)
    {
        if(AllowedItems.Length <= 0 || _itemObject == null || _itemObject.data.Id < 0)
        {
            return true;
        }
        for (int i = 0; i < AllowedItems.Length; i++)
        {
            if(_itemObject.type == AllowedItems[i])
            {
                return true;
            }
        }
        return false;
    }

}