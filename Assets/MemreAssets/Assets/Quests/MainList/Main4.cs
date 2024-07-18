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
            "Omeet: Maceraya Haz�r M�s�n Foxy?",
            "Omeet: O da ne �yle Yolun Ortas�nda Bir �r�mcek Yuvas� ��km�� Onu Y�k�p Gel Sonra seni biriyle tan��t�raca��m.",
            "Foxy: Oldu Bil Emoot! ",
        };

        completionDialogueLines = new string[]
        {
            "Omeet: Ger�ekten Yeteneklisin Foxy. Etkilendim",
            "Foxy: Te�ekk�r Ederim Emoot",
            "Omeet: Uzun S�redir B�y�l� birisi buralara u�ramam��t� bu i�i ba�araca��na ad�m gibi Eminim Foxy",
            "Omeet: K�ye D�n Orada K�y�m�z�n Muhtar� Seni Bekliyor!",
            "Omeet: Birde Al bu Y�z��� Laz�m Olur",
            "Foxy: Te�ekk�r Ederim Omeet"
        };


        QuestName = "�lk Bask�n";
        QuestDescription = "Yak�nlarda Ortaya ��kan �r�mcek Yuvas�n� Y�k";
        itemReward = Player.main.inventory.database.Items[10].data;
        ExperienceReward = 500;
        Goals = new List<Goal>
        {
            new KillGoal(this, 14, QuestDescription, false, 0, 1)
        };

        Goals.ForEach(g => g.Init());
    }
}
