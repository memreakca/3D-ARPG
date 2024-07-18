using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main1 : Quest
{
    public override void Init()
    {
        base.Init();

        assignmentDialogueLines = new string[]
       {
            "Omeet: Selam , Orman�m�za Ho� geldin yabanc�.",
            "Omeet: Yorgun g�r�n�yorsun.",
            "Omeet: Benim Ad�m Omeet Tan��t���ma memnun oldum .",
            "Omeet: Burada n�bet tutmam gerekiyor k�yde arkada��m Duruk var surat�nda kocaman bir g�zl��� var .Ona benim selam�m� s�yler misin ? .",
            "Omeet: G�r���r�z"
       };

        midQuestDialogueLines = new string[]
        {
            "Foxy: Selam Omeet selam s�yledi" ,
            "Duruk: Ho� geldin yabanc� sana yard�mc� olmadan �nce Omeete iletmem gereken bir mesaj var.",
            "Duruk: Orta K�y yak�nlar�nda �r�mcekler g�r�lmeye ba�lam�� bunu ona iletir misin ?",
            "Foxy: Tabikide",
            "Duruk: Te�ekk�r ederim yabanc�"
        };


        completionDialogueLines = new string[]
        {
            "Omeet: NASIL OLAB�L�R BU!.",
            "Omeet: BUNUN �ARES�NE BAKACA�IM",
            "Omeet: Duruk'un yan�na gitsen iyi olucak yabanc�"
        };

        QuestName = "Duruk �le Konu�";
        QuestDescription = "Duruk ile konu� ve etraf� tan�maya ba�la";
        ExperienceReward = 200;

        string npcName = "Duruk";

        Goals = new List<Goal>
        {
            new TalkingGoal(this, npcName, QuestDescription, false)
        };

        Goals.ForEach(g => g.Init());
    }
}
