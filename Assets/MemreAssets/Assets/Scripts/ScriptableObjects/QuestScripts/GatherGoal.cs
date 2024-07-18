using UnityEngine;

public class GatherGoal : Goal
{
    public Item itemToGather;

    public GatherGoal(Quest quest, Item itemToGather, string description, bool completed, int currentAmount, int requiredAmount)
    {
        this.Quest = quest;
        this.itemToGather = itemToGather;
        this.Description = description;
        this.Completed = completed;
        this.CurrentAmount = currentAmount;
        this.RequiredAmount = requiredAmount;
    }

    public override void Init()
    {
        base.Init();
        Player.main.inventory.OnInventoryChanged += CheckInventory;
        CheckInventory();
    }

    void CheckInventory()
    {
        CurrentAmount = Player.main.inventory.GetItemAmount(itemToGather);
        Evaluate();
    }


    private void OnDisable()
    {
        Player.main.inventory.OnInventoryChanged -= CheckInventory;
    }
}
