using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DFMain1 : Quest
{
    public override void Init()
    {
        base.Init();

        assignmentDialogueLines = new string[]
        {
            "Dude: Selam K�s... Bu da Ne!",
            "Dude: Sen K�stebek De�ilsin!",
            "Dude: Bir Tilki , �u anda Ka�mal� m�y�m bilemedim",
            "Foxy: Sakin ol benden zarar gelmez! Benim Ad�m Foxy ben buray� Muhtar Lloyd sayesinde buldum",
            "Dude: Bizim Lloyd Muhtar m� olmu�",
            "Dude: Uzun s�re buralara gelmemesinden belliydi zaten ",
            "Dude: Ben Dude , ben bu ge�itin bek�isiyim . Buraya gelen K�stebeklere geri d�nmelerini s�ylerim",
            "Foxy: Memnun oldum Dude!",
            "Dude: Haz�r gelmi�ken biraz Mantar toplar m�s�n �u ilerde birka� tane olacakt�",
            "Dude: Dikkat et patlamas�nlar!",
            "Foxy: Nas�l yani",
            "Dude: G�r�nce Anlars�n"

        };

        completionDialogueLines = new string[]
        {
            "Dude: OHHH Uzun s�redir yememi�tim �ok g�zel geldi tad�!",
            "Foxy: Afiyet olsun , ben de yan�ma ald�m ihtiyac�m olucak.",
            "Dude: Tabii tabii hem de �ok ihtiyac�n olcak",
            "Dude: E�er ta�� ar�yorsan bu yolun sonunda demir kap� var onu a�man gerekicek! G�r��mek �zere.",
            "Dude: Ha bu arada bo�una ba�ka k�stebek arama buralarda benden ba�ka kimse yok"
        };

        QuestName = "Mantar Topla";
        QuestDescription = "10 adet Mantar Topla";
        ExperienceReward = 1000;

        Item itemToGather = Player.main.inventory.database.Items[18].data;

        Goals = new List<Goal>
        {
            new GatherGoal(this, itemToGather, QuestDescription, false, 0, 10),
        };

        Goals.ForEach(g => g.Init());
    }


}
