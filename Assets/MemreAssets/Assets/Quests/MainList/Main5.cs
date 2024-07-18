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
            "Lloyd: Selam , K�y�m�ze Ho� geldin Foxy.",
            "Lloyd: Duydu�uma g�re gelir gelmez �r�mceklerin can�na okumu�sun!.",
            "Foxy: Ben her zaman iyinin yan�nday�md�r Muhtar Lloyd!",
            "Lloyd: O lanet ta� ortaya ��kal�dan beri k�y�m�ze sald�r�lar bitmiyor.",
            "Foxy: Ben de o ta� y�z�nden buraday�m Muhtar . Yerini biliyor musunuz?",
            "Lloyd: Evet biliyorum ama �ok uzaklarda",
            "Foxy: Ne kadar uzakta olursa olsun benim gayem o ta�� yoketmek",
            "Lloyd: Sana yard�mc� olaca��m Foxy merak etme ama �nce Krem'in yan�na gidip i�inin ba��na d�nmesini s�yler misin?",
            "Lloyd: Beyaz b�y�kl� �ocuk g�r�nce tan�rs�n :D",
            "Foxy: Oldu Bil!"
       };

        midQuestDialogueLines = new string[]
        {
            "Foxy: Selam Krem B�y���n G�zelmi�" ,
            "Krem: Te�ekk�r ederim yabanc�! Hangi r�zgar att� seni buralara",
            "Foxy: Ormanlar�m�z� mahveden canavarlar y�z�nden ta�� aramaya ��kt�m.",
            "Foxy: Ta��n buralarda oldu�unu ��rendim ve sizin k�y�n�ze rast geldim.",
            "Krem: NE! Kafay� m� yedin sen git hayat�n� ya�a o ta�tan kimseye iyilik gelmez!",
            "Foxy: ��te ben de bu y�zden buraday�m Krem , Bu arada benim ad�m Foxy , memnun oldum.",
            "Krem: Ben de memnun oldum Foxy. Maceranda bol �ans diliyorum",
            "Foxy: Bu arada Muhtar i�inin ba��na d�nmeni s�yledi",
            "Krem: O adam ya�land�k�a hi� �ekilmez oluyor."

        };


        completionDialogueLines = new string[]
        {
            "Foxy: Krem'in b�y��� cidden komik duruyor, Muhtar Lloyd",
            "Lloyd: Bence de �yle ama inad� y�z�nden �yle dola��yor",
            "Lloyd: Demek ta�� ar�yorsun Yolun sonunda Bek�i Trox bekliyor o sana yard�mc� olacakt�r",
            "Foxy: Te�ekk�r ederim Muhtar Lloyd",
            "Lloyd: Zorlu bir yoldas�n Foxy yolun a��k olsun birdaha g�r��mek �zere! Bol �ans!",
            "Foxy: G�r���r�z Muhtar Lloyd!"
        };

        QuestName = "Muhtar Lloyd �le Konu�";
        QuestDescription = "Muhtar Lloyd ile konu� ve ta� hakk�nda bilgi al";
        ExperienceReward = 300;

        string npcName = "Krem";

        Goals = new List<Goal>
        {
            new TalkingGoal(this, npcName, QuestDescription, false)
        };

        Goals.ForEach(g => g.Init());
    }
}
