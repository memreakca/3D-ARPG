using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal
{
    public Quest Quest;
    public string Description;
    public bool Completed;
    public int CurrentAmount;
    public int RequiredAmount;

    public virtual void Init()
    {

    }
    public void Evaluate()
    {
        if (Completed) return;
        Debug.Log(CurrentAmount);
        if (CurrentAmount >= RequiredAmount)
        {
            Complete();
        }
    }

    public void Complete()
    {
        Completed = true;
        this.Quest.CheckGoals();
    }
}