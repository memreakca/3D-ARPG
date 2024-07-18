using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneSlayer : Quest
{
    public override void Init()
    {
        base.Init();
        Debug.Log("Stone Killer Assigned.");

        QuestName = "Stone Killer";
        QuestDescription = "Kill 1 Stone Golem";
        itemReward = Player.main.inventory.database.Items[2].data;
        ExperienceReward = 100;
        Goals = new List<Goal>
        {
            new KillGoal(this, 1, QuestDescription, false, 0, 1)
        };

        Goals.ForEach(g => g.Init());
    }
}
