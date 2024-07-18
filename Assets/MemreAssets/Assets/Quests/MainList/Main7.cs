using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Main7 : Quest
{
    public override void Init()
    {
        base.Init();
        assignmentDialogueLines = new string[]
        {
            "Omeet: Tekrardan Selam Foxy! .",
            "Omeet: Bu yolun sonunda bir ta� golemi var onda kap�y� a�acak olan anahtar�n Par�as� var onu bana getir sana anahtar� vereyim! ",
            "Foxy: Ta� Golem mi? O da ne!",
            "Omeet: G�r�nce ��renirsin dikkat et sa�lam vurur!"

        };

        completionDialogueLines = new string[]
        {
            "Omeet: Hay�r Golemleri K�zd�rd�k, Al bu anahtar� ve golemleri alt et ve ma�araya gir! ",
        };


        QuestName = "Ta� Golemden Par�ay� Al";
        QuestDescription = "Ta� Golemden Par�ay� al";
        itemReward = Player.main.inventory.database.Items[12].data;
        ExperienceReward = 1000;
        Goals = new List<Goal>
        {
            new KillGoal(this, 1 , QuestDescription, false, 0, 1)
        };

        Goals.ForEach(g => g.Init());
    }
}
