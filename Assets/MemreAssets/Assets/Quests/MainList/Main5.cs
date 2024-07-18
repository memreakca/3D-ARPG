using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main5 : Quest
{
    public override void Init()
    {
        base.Init();

        assignmentDialogueLines = new string[]
       {
            "Lloyd: Selam , Köyümüze Hoþ geldin Foxy.",
            "Lloyd: Duyduðuma göre gelir gelmez örümceklerin canýna okumuþsun!.",
            "Foxy: Ben her zaman iyinin yanýndayýmdýr Muhtar Lloyd!",
            "Lloyd: O lanet taþ ortaya çýkalýdan beri köyümüze saldýrýlar bitmiyor.",
            "Foxy: Ben de o taþ yüzünden buradayým Muhtar . Yerini biliyor musunuz?",
            "Lloyd: Evet biliyorum ama çok uzaklarda",
            "Foxy: Ne kadar uzakta olursa olsun benim gayem o taþý yoketmek",
            "Lloyd: Sana yardýmcý olacaðým Foxy merak etme ama önce Krem'in yanýna gidip iþinin baþýna dönmesini söyler misin?",
            "Lloyd: Beyaz býyýklý çocuk görünce tanýrsýn :D",
            "Foxy: Oldu Bil!"
       };

        midQuestDialogueLines = new string[]
        {
            "Foxy: Selam Krem Býyýðýn Güzelmiþ" ,
            "Krem: Teþekkür ederim yabancý! Hangi rüzgar attý seni buralara",
            "Foxy: Ormanlarýmýzý mahveden canavarlar yüzünden taþý aramaya çýktým.",
            "Foxy: Taþýn buralarda olduðunu öðrendim ve sizin köyünüze rast geldim.",
            "Krem: NE! Kafayý mý yedin sen git hayatýný yaþa o taþtan kimseye iyilik gelmez!",
            "Foxy: Ýþte ben de bu yüzden buradayým Krem , Bu arada benim adým Foxy , memnun oldum.",
            "Krem: Ben de memnun oldum Foxy. Maceranda bol þans diliyorum",
            "Foxy: Bu arada Muhtar iþinin baþýna dönmeni söyledi",
            "Krem: O adam yaþlandýkça hiç çekilmez oluyor."

        };


        completionDialogueLines = new string[]
        {
            "Foxy: Krem'in býyýðý cidden komik duruyor, Muhtar Lloyd",
            "Lloyd: Bence de öyle ama inadý yüzünden öyle dolaþýyor",
            "Lloyd: Demek taþý arýyorsun Yolun sonunda Bekçi Trox bekliyor o sana yardýmcý olacaktýr",
            "Foxy: Teþekkür ederim Muhtar Lloyd",
            "Lloyd: Zorlu bir yoldasýn Foxy yolun açýk olsun birdaha görüþmek üzere! Bol Þans!",
            "Foxy: Görüþürüz Muhtar Lloyd!"
        };

        QuestName = "Muhtar Lloyd Ýle Konuþ";
        QuestDescription = "Muhtar Lloyd ile konuþ ve taþ hakkýnda bilgi al";
        ExperienceReward = 300;

        string npcName = "Krem";

        Goals = new List<Goal>
        {
            new TalkingGoal(this, npcName, QuestDescription, false)
        };

        Goals.ForEach(g => g.Init());
    }
}
