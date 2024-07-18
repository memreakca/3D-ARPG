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
            "Dude: Dostum Ben bir k�stebe�im !",
            "Dude: Ne kadar evrimle�ip g�zlerimiz olsa da! Biz yollar� kullanmay�z biliyorsun.",
            "Foxy: Ah do�ru ya unutmu�um! ",
            "Dude: Bu yolu takip edersen kar��na b�y�k bir alan ��kacak ",
            "Dude: [ORADA �STED���N KADAR SEV�YE KASAB�L�RS�N]",
            "Dude: Oradaki canavarlardan birka� �ey istiyorum sadece",
            "Dude: Benim i�in toplar m�s�n acaba?",
            "Foxy: Tabi ki dostum zaten bana engel olacaklard�!",

        };

        completionDialogueLines = new string[]
        {
            "Dude: �ok �Y�S�N FOXY!",
            "Foxy: Sormas� Ay�p bunlar� ne yap�caks�n Dude.",
            "Dude: Bunlar m�?",
            "Dude: �ocuklar�ma hediye olarak verice�im .",
            "Foxy: �ocuklar�na Selam�m� ilet",
            "Dude: Ha bu arada Bir sonraki d��man�na �a��rma :D"
        };

        QuestName = "Dude ��in Birka� �ey";
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