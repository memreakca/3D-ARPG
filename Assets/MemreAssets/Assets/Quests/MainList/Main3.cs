using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Main3 : Quest
{
    public override void Init()
    {
        base.Init();
        assignmentDialogueLines = new string[]
        {
            "Foxy: Merhaba Duruk sana bu yapraklar� getirmemi s�yledi.",
            "Avare: HOHOHO �yle miii? Ne yap�cakm���m bu yapraklarla .",
            "Foxy: Senin bana ��retice�ini s�yledi ? ",
            "Avare: O zaman biraz sarg� bezi yapal�m hem �ok laz�m olucak sana anlars�n ya .",
            " ENVANTER'DEN CRAFT KISMINA GELEREK SARGI BEZ� �RET "
        };

        completionDialogueLines = new string[]
        {
            "Avare: Aferin , sana Yabanc�!",
            "Foxy: Bu arada benim ad�m Foxy",
            "Avare: Memnun oldum Foxy annen baban �ok yarat�c� bir isim bulmu�",
            "Foxy: Ben de memnun oldum Avare!",
            "Avare: Omeet Seni sordu onun yan�na bir u�ra."
        };

        QuestName = "Sarg� Bezi �ret";
        QuestDescription = "�retim ekran�n� kullanmay� ��ren";
        ExperienceReward = 200;
        Item itemToCraft = Player.main.inventory.database.Items[0].data;

        Goals = new List<Goal>
        {
            new CraftingGoal(this, itemToCraft, QuestDescription, false, 0, 1)
        };

        Goals.ForEach(g => g.Init());


    }
}
