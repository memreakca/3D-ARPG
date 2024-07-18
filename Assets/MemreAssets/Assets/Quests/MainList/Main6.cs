using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Main6 : Quest
{
    public override void Init()
    {
        base.Init();
        assignmentDialogueLines = new string[]
        {
            "Trox: Selamlar ! Ben Trox bu köyün bekçisiyim .",
            "Trox: Tabi köy demeye bin þahit ister ",
            "Foxy: Selamlar Trox! Beni Muhtar Lloyd gönderdi. Adým Foxy lanetli taþý arýyorum senin bir þeyler bildiðini söylediler.",
            "Trox: Tabii biliyorum! ama ondan önce ormanda 2 adet ayý görülmüþ! Benim için onlarý yokedebilir misin? ",
            "Foxy: Tabii ki Trox Oldu Bil!",
            "Trox: Evrimleþmedikleri için direkt saldýrýyorlar dikkat et! ",

        };

        completionDialogueLines = new string[]
        {
            "Trox: Tek bir çizik bile almamýþsýn Foxy, VAY BE! Al bu hediyen ",
            "Foxy: Teþekkür Ederim Trox!",
            "Trox: Bu köyü geçince bir geçit karþýna çýkýcak içerisi örümcek kaynýyor dikkat et!",
            "Trox: Ha bu arada Omeet da köyde o sana daha detaylý bilgi verecektir.",
            "Foxy: Seni unutmayacaðým Trox , Ýyi nöbetler!",
            "Trox: Bol Þans Foxy!"
        };


        QuestName = "Ormandaki Ayýlarý Öldür";
        QuestDescription = "Ormanda 2 adet ayý görülmüþ git ve onlarý öldür!";
        itemReward = Player.main.inventory.database.Items[11].data;
        ExperienceReward = 400;
        Goals = new List<Goal>
        {
            new KillGoal(this, 4, QuestDescription, false, 0, 2)
        };

        Goals.ForEach(g => g.Init());
    }
}
