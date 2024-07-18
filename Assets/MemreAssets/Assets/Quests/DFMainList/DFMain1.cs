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
            "Dude: Selam Kös... Bu da Ne!",
            "Dude: Sen Köstebek Deðilsin!",
            "Dude: Bir Tilki , Þu anda Kaçmalý mýyým bilemedim",
            "Foxy: Sakin ol benden zarar gelmez! Benim Adým Foxy ben burayý Muhtar Lloyd sayesinde buldum",
            "Dude: Bizim Lloyd Muhtar mý olmuþ",
            "Dude: Uzun süre buralara gelmemesinden belliydi zaten ",
            "Dude: Ben Dude , ben bu geçitin bekçisiyim . Buraya gelen Köstebeklere geri dönmelerini söylerim",
            "Foxy: Memnun oldum Dude!",
            "Dude: Hazýr gelmiþken biraz Mantar toplar mýsýn þu ilerde birkaç tane olacaktý",
            "Dude: Dikkat et patlamasýnlar!",
            "Foxy: Nasýl yani",
            "Dude: Görünce Anlarsýn"

        };

        completionDialogueLines = new string[]
        {
            "Dude: OHHH Uzun süredir yememiþtim çok güzel geldi tadý!",
            "Foxy: Afiyet olsun , ben de yanýma aldým ihtiyacým olucak.",
            "Dude: Tabii tabii hem de çok ihtiyacýn olcak",
            "Dude: Eðer taþý arýyorsan bu yolun sonunda demir kapý var onu açman gerekicek! Görüþmek üzere.",
            "Dude: Ha bu arada boþuna baþka köstebek arama buralarda benden baþka kimse yok"
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
