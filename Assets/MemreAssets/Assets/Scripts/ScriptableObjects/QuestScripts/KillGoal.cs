using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillGoal : Goal
{
    public int enemyID;

    public KillGoal(Quest quest,int enemyID,string Description,bool completed,int currentAmount,int requiredAmount)
    {
        this.Quest = quest;
        this.enemyID = enemyID;
        this.Description = Description;
        this.Completed = completed;
        this.CurrentAmount = currentAmount;
        this.RequiredAmount = requiredAmount;
    }

    public override void Init()
    {
        base.Init();
        CombatEvents.OnEnemyDeathC += EnemyDied;
    }
    
    void EnemyDied(IEnemy enemy)
    {
        if (enemy.EnemyID == enemyID) 
        {
            this.CurrentAmount++;
            Evaluate();
        }
    }
}
