using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Helmet, 
    Chest,
    Boots,
    Ring,
    Necklace,
    Quest,
    ConsumableHP,
    ConsumableSP,
    Default
}

public enum Attributes
{
    Defence, // Karakterin Defans de�eri
    Strength, // Karakterin yetenek veya basit sald�r�larla verdi�i Hasar� Artt�r�r
    Vitality, // Karakterin Hareket H�z�n� Artt�r�r
    Agility, // Karakterin Can De�erini (HP) Artt�r�r  1 Agility = 25 HP
    Intelligence, // Karakterin Mana De�erini (SP) Artt�r�r 1 Intelligence = 25 SP
    HP, // Consumable item value HP
    SP // Consumable item value SP
}
[CreateAssetMenu(fileName = "New Item", menuName = "Inventory System/Items/item")]
public class ItemObject : ScriptableObject
{

    public Sprite uiDisplay;
    public bool stackable;
    public ItemType type;
    [TextArea(15,20)]
    public string description;
    public Item data = new Item();

    public Item CreateItem()
    {
        Item newItem = new Item(this);
        return newItem;
    }
}

[System.Serializable]
public class Item
{
    public string Name;
    public int Id = -1;
    public ItemBuff[] buffs;
    public Item()
    {
        Name = "";
        Id = -1;
    }
    public Item(ItemObject item)
    {
        Name = item.name;
        Id = item.data.Id;
        buffs = new ItemBuff[item.data.buffs.Length];
        for (int i = 0; i < buffs.Length; i++)
        {

            buffs[i] = new ItemBuff(item.data.buffs[i].min, item.data.buffs[i].max)
            {
                attribute = item.data.buffs[i].attribute
            };
        }
    }
}

[System.Serializable]
public class ItemBuff : IModifiers
{
    public Attributes attribute;
    public int value;
    public int min;
    public int max;

    public ItemBuff(int _value)
    {
        value = _value;
    }
    public ItemBuff(int _min, int _max)
    {
        min = _min; max = _max; GenerateValue();
    }
    public void GenerateValue()
    {
        value = UnityEngine.Random.Range(min, max);
    }

    public void AddValue(ref int baseValue)
    {
        baseValue += value;
    }


}
