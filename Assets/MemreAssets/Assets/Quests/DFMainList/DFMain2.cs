using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DFMain2 : Quest
{
    public override void Init()
    {
        base.Init();

        assignmentDialogueLines = new string[]
        {
            "Foxy: DUDE!",
            "Foxy: SEN NASIL BURADASIN!",
            "Dude: Dostum Ben bir köstebeðim !",
            "Dude: Ne kadar evrimleþip gözlerimiz olsa da! Biz yollarý kullanmayýz biliyorsun.",
            "Foxy: Ah doðru ya unutmuþum! ",
            "Dude: Bu yolu takip edersen karþýna büyük bir alan çýkacak ",
            "Dude: [ORADA ÝSTEDÝÐÝN KADAR SEVÝYE KASABÝLÝRSÝN]",
            "Dude: Oradaki canavarlardan birkaç þey istiyorum sadece",
            "Dude: Benim için toplar mýsýn acaba?",
            "Foxy: Tabi ki dostum zaten bana engel olacaklardý!",

        };

        completionDialogueLines = new string[]
        {
            "Dude: Çok ÝYÝSÝN FOXY!",
            "Foxy: Sormasý Ayýp bunlarý ne yapýcaksýn Dude.",
            "Dude: Bunlar mý?",
            "Dude: Çocuklarýma hediye olarak vericeðim .",
            "Foxy: Çocuklarýna Selamýmý ilet",
            "Dude: Ha bu arada Bir sonraki düþmanýna þaþýrma :D"
        };

        QuestName = "Dude Ýçin Birkaç Þey";
        QuestDescription = "7 Adet Diamond , 7 Adet Gold Bar Topla";
        ExperienceReward = 10000;

        Item itemToGather1 = Player.main.inventory.database.Items[23].data;
        Item itemToGather2 = Player.main.inventory.database.Items[24].data;

        Goals = new List<Goal>
        {
            new GatherGoal(this, itemToGather1, QuestDescription, false, 0, 7),
            new GatherGoal(this, itemToGather2, QuestDescription, false, 0, 7),
        };

        Goals.ForEach(g => g.Init());
    }


}