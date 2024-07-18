using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main2 : Quest
{

    public override void Init()
    {
        base.Init();

        assignmentDialogueLines = new string[]
        {
            "Duruk: Tekrardan Ho� geldin Yabanc�",
            "Duruk: Biraz (4 Adet) yapra�a ihtiyac�m var k�y�n yak�nlar�ndan toplayabilir misin?",
            "Foxy: Tabikide! ('I' tu�una basarak Envanteri a�abilrsin)",
            
        };

        completionDialogueLines = new string[]
        {
            "Duruk: �ok iyi i� Yabanc� , Bu arada ad�n nedir ?",
            "Foxy: Ad�m 'Foxy' ",
            "Duruk: Memnun oldum Foxy �imdi bu yapraklar� Avareye g�t�r�r m�s�n hemen k�y�n giri�inde duruyor.O sana ne yapca��n� ��retir"
        };

        QuestName = "Yaprak Topla";
        QuestDescription = "4 adet Yaprak Topla";
        ExperienceReward = 200;

        Item itemToGather = Player.main.inventory.database.Items[1].data;

        Goals = new List<Goal>
        {
            new GatherGoal(this, itemToGather, QuestDescription, false, 0, 4),
        };

        Goals.ForEach(g => g.Init());
    }


}