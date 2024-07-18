using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Main7 : Quest
{
    public override void Init()
    {
        base.Init();
        assignmentDialogueLines = new string[]
        {
            "Omeet: Tekrardan Selam Foxy! .",
            "Omeet: Bu yolun sonunda bir taþ golemi var onda kapýyý açacak olan anahtarýn Parçasý var onu bana getir sana anahtarý vereyim! ",
            "Foxy: Taþ Golem mi? O da ne!",
            "Omeet: Görünce Öðrenirsin dikkat et saðlam vurur!"

        };

        completionDialogueLines = new string[]
        {
            "Omeet: Hayýr Golemleri Kýzdýrdýk, Al bu anahtarý ve golemleri alt et ve maðaraya gir! ",
        };


        QuestName = "Taþ Golemden Parçayý Al";
        QuestDescription = "Taþ Golemden Parçayý al";
        itemReward = Player.main.inventory.database.Items[12].data;
        ExperienceReward = 1000;
        Goals = new List<Goal>
        {
            new KillGoal(this, 1 , QuestDescription, false, 0, 1)
        };

        Goals.ForEach(g => g.Init());
    }
}
