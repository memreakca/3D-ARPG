using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestEvents : MonoBehaviour
{
    public delegate void QuestEventHandler(Quest quest);
    public static event QuestEventHandler OnQuestCompleted;
    public static event QuestEventHandler OnQuestAssigned;

    public static void QuestCompleted(Quest quest)
    {
        OnQuestCompleted?.Invoke(quest);
    }

    public static void QuestAssigned(Quest quest)
    {
        OnQuestAssigned?.Invoke(quest);
    }
}
