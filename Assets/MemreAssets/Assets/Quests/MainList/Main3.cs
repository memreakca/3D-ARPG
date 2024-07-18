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
            "Foxy: Merhaba Duruk sana bu yapraklarý getirmemi söyledi.",
            "Avare: HOHOHO Öyle miii? Ne yapýcakmýþým bu yapraklarla .",
            "Foxy: Senin bana öðreticeðini söyledi ? ",
            "Avare: O zaman biraz sargý bezi yapalým hem çok lazým olucak sana anlarsýn ya .",
            " ENVANTER'DEN CRAFT KISMINA GELEREK SARGI BEZÝ ÜRET "
        };

        completionDialogueLines = new string[]
        {
            "Avare: Aferin , sana Yabancý!",
            "Foxy: Bu arada benim adým Foxy",
            "Avare: Memnun oldum Foxy annen baban çok yaratýcý bir isim bulmuþ",
            "Foxy: Ben de memnun oldum Avare!",
            "Avare: Omeet Seni sordu onun yanýna bir uðra."
        };

        QuestName = "Sargý Bezi Üret";
        QuestDescription = "Üretim ekranýný kullanmayý öðren";
        ExperienceReward = 200;
        Item itemToCraft = Player.main.inventory.database.Items[0].data;

        Goals = new List<Goal>
        {
            new CraftingGoal(this, itemToCraft, QuestDescription, false, 0, 1)
        };

        Goals.ForEach(g => g.Init());


    }
}
