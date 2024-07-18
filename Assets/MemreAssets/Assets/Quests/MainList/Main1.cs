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
            "Omeet: Selam , Ormanýmýza Hoþ geldin yabancý.",
            "Omeet: Yorgun görünüyorsun.",
            "Omeet: Benim Adým Omeet Tanýþtýðýma memnun oldum .",
            "Omeet: Burada nöbet tutmam gerekiyor köyde arkadaþým Duruk var suratýnda kocaman bir gözlüðü var .Ona benim selamýmý söyler misin ? .",
            "Omeet: Görüþürüz"
       };

        midQuestDialogueLines = new string[]
        {
            "Foxy: Selam Omeet selam söyledi" ,
            "Duruk: Hoþ geldin yabancý sana yardýmcý olmadan önce Omeete iletmem gereken bir mesaj var.",
            "Duruk: Orta Köy yakýnlarýnda örümcekler görülmeye baþlamýþ bunu ona iletir misin ?",
            "Foxy: Tabikide",
            "Duruk: Teþekkür ederim yabancý"
        };


        completionDialogueLines = new string[]
        {
            "Omeet: NASIL OLABÝLÝR BU!.",
            "Omeet: BUNUN ÇARESÝNE BAKACAÐIM",
            "Omeet: Duruk'un yanýna gitsen iyi olucak yabancý"
        };

        QuestName = "Duruk Ýle Konuþ";
        QuestDescription = "Duruk ile konuþ ve etrafý tanýmaya baþla";
        ExperienceReward = 200;

        string npcName = "Duruk";

        Goals = new List<Goal>
        {
            new TalkingGoal(this, npcName, QuestDescription, false)
        };

        Goals.ForEach(g => g.Init());
    }
}
