using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillTheBear : Quest
{
    public override void Init()
    {
        base.Init();
        Debug.Log("Kill The Bear Assigned.");
        QuestName = "Kill The Bear";
        QuestDescription = "Kill 1 Bear";
        itemReward = Player.main.inventory.database.Items[10].data;
        ExperienceReward = 200;
        Goals = new List<Goal>
        {
            new KillGoal(this,4,QuestDescription, false, 0, 1)
        };

        Goals.ForEach(g => g.Init());
    }
}
