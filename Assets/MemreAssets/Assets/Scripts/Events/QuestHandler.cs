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
        if (completedQuest.QuestName == "Sarg� Bezi �ret")
        {
            QuestGiver newQuestGiver = Omeet.AddComponent<QuestGiver>();
            newQuestGiver.questType = "Main4";
            newQuestGiver.nextQuestGiverObject = Lloyd;
            newQuestGiver.nextQuestType = "Main5";
        }
        if (completedQuest.QuestName == "Ormandaki Ay�lar� �ld�r")
        {
            OrtaKoyBlok.SetActive(false);
            Omeet2.SetActive(true);
        }
        if (completedQuest.QuestName == "Ta� Golemden Par�ay� Al")
        {
            StoneGolems.SetActive(true);
        }
        if (completedQuest.QuestName == "Dude ��in Birka� �ey")
        {
            Player.main.inventory.RemoveAmount(Player.main.inventory.database.Items[23].data, 7);
            Player.main.inventory.RemoveAmount(Player.main.inventory.database.Items[24].data, 7);
            BossBlok.SetActive(false);
        }
    }

    private void HandleQuestAssignment(Quest assignedQuest)
    {
        if (assignedQuest.QuestName == "�lk Bask�n")
        {
            Lloyd.SetActive(true);
            BaslangicBlok.SetActive(false);
            Spawner.SetActive(true);
        }
        if (assignedQuest.QuestName == "Ormandaki Ay�lar� �ld�r")
        {
            for (int i = 0;Bears.Length > i; i++)
            {
                Bears[i].SetActive(true);
            }
        }
    }
}
