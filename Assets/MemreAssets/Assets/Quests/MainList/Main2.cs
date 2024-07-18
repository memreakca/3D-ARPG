using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main2 : Quest
{

    public override void Init()
    {
        base.Init();

        assignmentDialogueLines = new string[]
        {
            "Duruk: Tekrardan Hoþ geldin Yabancý",
            "Duruk: Biraz (4 Adet) yapraða ihtiyacým var köyün yakýnlarýndan toplayabilir misin?",
            "Foxy: Tabikide! ('I' tuþuna basarak Envanteri açabilrsin)",
            
        };

        completionDialogueLines = new string[]
        {
            "Duruk: Çok iyi iþ Yabancý , Bu arada adýn nedir ?",
            "Foxy: Adým 'Foxy' ",
            "Duruk: Memnun oldum Foxy þimdi bu yapraklarý Avareye götürür müsün hemen köyün giriþinde duruyor.O sana ne yapcaðýný öðretir"
        };

        QuestName = "Yaprak Topla";
        QuestDescription = "4 adet Yaprak Topla";
        ExperienceReward = 200;

        Item itemToGather = Player.main.inventory.database.Items[1].data;

        Goals = new List<Goal>
        {
            new GatherGoal(this, itemToGather, QuestDescription, false, 0, 4),
        };

        Goals.ForEach(g => g.Init());
    }


}