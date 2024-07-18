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
            "Trox: Selamlar ! Ben Trox bu k�y�n bek�isiyim .",
            "Trox: Tabi k�y demeye bin �ahit ister ",
            "Foxy: Selamlar Trox! Beni Muhtar Lloyd g�nderdi. Ad�m Foxy lanetli ta�� ar�yorum senin bir �eyler bildi�ini s�ylediler.",
            "Trox: Tabii biliyorum! ama ondan �nce ormanda 2 adet ay� g�r�lm��! Benim i�in onlar� yokedebilir misin? ",
            "Foxy: Tabii ki Trox Oldu Bil!",
            "Trox: Evrimle�medikleri i�in direkt sald�r�yorlar dikkat et! ",

        };

        completionDialogueLines = new string[]
        {
            "Trox: Tek bir �izik bile almam��s�n Foxy, VAY BE! Al bu hediyen ",
            "Foxy: Te�ekk�r Ederim Trox!",
            "Trox: Bu k�y� ge�ince bir ge�it kar��na ��k�cak i�erisi �r�mcek kayn�yor dikkat et!",
            "Trox: Ha bu arada Omeet da k�yde o sana daha detayl� bilgi verecektir.",
            "Foxy: Seni unutmayaca��m Trox , �yi n�betler!",
            "Trox: Bol �ans Foxy!"
        };


        QuestName = "Ormandaki Ay�lar� �ld�r";
        QuestDescription = "Ormanda 2 adet ay� g�r�lm�� git ve onlar� �ld�r!";
        itemReward = Player.main.inventory.database.Items[11].data;
        ExperienceReward = 400;
        Goals = new List<Goal>
        {
            new KillGoal(this, 4, QuestDescription, false, 0, 2)
        };

        Goals.ForEach(g => g.Init());
    }
}
