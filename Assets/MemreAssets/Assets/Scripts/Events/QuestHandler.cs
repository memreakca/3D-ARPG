using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestHandler : MonoBehaviour
{
    public GameObject BaslangicBlok;
    public GameObject OrtaKoyBlok;
    public GameObject BossBlok;
    public GameObject Omeet;
    public GameObject Omeet2;
    public GameObject Spawner;
    public GameObject Trox;
    public GameObject Duruk;
    public GameObject Lloyd;
    public GameObject[] Bears;
    public GameObject StoneGolems;
    private void OnEnable()
    {
        QuestEvents.OnQuestCompleted += HandleQuestCompletion;
        QuestEvents.OnQuestAssigned += HandleQuestAssignment;
    }

    private void OnDisable()
    {
        QuestEvents.OnQuestCompleted -= HandleQuestCompletion;
        QuestEvents.OnQuestAssigned -= HandleQuestAssignment;
    }

    private void HandleQuestCompletion(Quest completedQuest)
    {
        if (completedQuest.QuestName == "Sargý Bezi Üret")
        {
            QuestGiver newQuestGiver = Omeet.AddComponent<QuestGiver>();
            newQuestGiver.questType = "Main4";
            newQuestGiver.nextQuestGiverObject = Lloyd;
            newQuestGiver.nextQuestType = "Main5";
        }
        if (completedQuest.QuestName == "Ormandaki Ayýlarý Öldür")
        {
            OrtaKoyBlok.SetActive(false);
            Omeet2.SetActive(true);
        }
        if (completedQuest.QuestName == "Taþ Golemden Parçayý Al")
        {
            StoneGolems.SetActive(true);
        }
        if (completedQuest.QuestName == "Dude Ýçin Birkaç Þey")
        {
            Player.main.inventory.RemoveAmount(Player.main.inventory.database.Items[23].data, 7);
            Player.main.inventory.RemoveAmount(Player.main.inventory.database.Items[24].data, 7);
            BossBlok.SetActive(false);
        }
    }

    private void HandleQuestAssignment(Quest assignedQuest)
    {
        if (assignedQuest.QuestName == "Ýlk Baskýn")
        {
            Lloyd.SetActive(true);
            BaslangicBlok.SetActive(false);
            Spawner.SetActive(true);
        }
        if (assignedQuest.QuestName == "Ormandaki Ayýlarý Öldür")
        {
            for (int i = 0;Bears.Length > i; i++)
            {
                Bears[i].SetActive(true);
            }
        }
    }
}
