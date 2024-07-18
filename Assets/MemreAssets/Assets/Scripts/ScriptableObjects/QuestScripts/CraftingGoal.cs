using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingGoal : Goal
{
    public Item itemToCraft;

    public CraftingGoal(Quest quest, Item itemToCraft, string description, bool completed, int currentAmount, int requiredAmount)
    {
        this.Quest = quest;
        this.itemToCraft = itemToCraft;
        this.Description = description;
        this.Completed = completed;
        this.CurrentAmount = currentAmount;
        this.RequiredAmount = requiredAmount;
    }

    public override void Init()
    {
        base.Init();
        CraftingEvents.OnItemCrafted += ItemCrafted;
    }

    private void OnDisable()
    {
        CraftingEvents.OnItemCrafted -= ItemCrafted;
    }

    void ItemCrafted(Item item)
    {
        if (item.Id == itemToCraft.Id)
        {
            this.CurrentAmount++;
            Evaluate();
        }
        Debug.Log(item.Name);
    }
}