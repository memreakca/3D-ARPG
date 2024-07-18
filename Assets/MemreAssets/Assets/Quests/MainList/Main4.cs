using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Main4 : Quest
{
    public override void Init()
    {
        base.Init();
        assignmentDialogueLines = new string[]
        {
            "Omeet: Maceraya Hazýr Mýsýn Foxy?",
            "Omeet: O da ne Öyle Yolun Ortasýnda Bir Örümcek Yuvasý Çýkmýþ Onu Yýkýp Gel Sonra seni biriyle tanýþtýracaðým.",
            "Foxy: Oldu Bil Emoot! ",
        };

        completionDialogueLines = new string[]
        {
            "Omeet: Gerçekten Yeteneklisin Foxy. Etkilendim",
            "Foxy: Teþekkür Ederim Emoot",
            "Omeet: Uzun Süredir Büyülü birisi buralara uðramamýþtý bu iþi baþaracaðýna adým gibi Eminim Foxy",
            "Omeet: Köye Dön Orada Köyümüzün Muhtarý Seni Bekliyor!",
            "Omeet: Birde Al bu Yüzüðü Lazým Olur",
            "Foxy: Teþekkür Ederim Omeet"
        };


        QuestName = "Ýlk Baskýn";
        QuestDescription = "Yakýnlarda Ortaya Çýkan Örümcek Yuvasýný Yýk";
        itemReward = Player.main.inventory.database.Items[10].data;
        ExperienceReward = 500;
        Goals = new List<Goal>
        {
            new KillGoal(this, 14, QuestDescription, false, 0, 1)
        };

        Goals.ForEach(g => g.Init());
    }
}
