using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance;
    public Sprite Completionsprite;
    public AudioClip questComplete;
    public TextMeshProUGUI QuestText;
    public GameObject QuestPanel;
    private List<Quest> quests = new List<Quest>();
    private void Awake()
    {
        Instance = this;
    }

    public void AddQuest(Quest quest)
    {
        quests.Add(quest);
        QuestEvents.QuestAssigned(quest);
        QuestText.text = quest.QuestDescription;
        
    }

    public void CompleteQuest(Quest quest)
    {
        QuestEvents.QuestCompleted(quest);
        QuestText.text = string.Empty;
        quests.Remove(quest);
    }

    public void ClearQuests()
    {
        quests.Clear();
    }

    private void Update()
    {
        if (quests.Count <= 0)
        {
            QuestPanel.SetActive(false);
        }
        else { QuestPanel.SetActive(true); }
    }
}
