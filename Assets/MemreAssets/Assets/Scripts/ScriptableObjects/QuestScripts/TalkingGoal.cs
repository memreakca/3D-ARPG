using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkingGoal : Goal
{
    private string npcName;

    public TalkingGoal(Quest quest, string npcName, string description, bool completed)
    {
        this.Quest = quest;
        this.npcName = npcName;
        this.Description = description;
        this.Completed = completed;
        this.CurrentAmount = 0;
        this.RequiredAmount = 1;
    }

    public override void Init()
    {
        base.Init();
        DialogueEvents.OnNPCSpokenTo += NPCSpokenTo;
    }

    void NPCSpokenTo(string npcName)
    {
        if (npcName == this.npcName && this.Completed == false)
        {
            CurrentAmount = 1;
            Evaluate();
            StartMidQuestDialogue();
        }
    }

    private void StartMidQuestDialogue()
    {
        if (Quest != null && Quest.midQuestDialogueLines != null && Quest.midQuestDialogueLines.Length > 0)
        {
            Dialogue.Instance.DialoguePanel.SetActive(true);
            Dialogue.Instance.lines = Quest.midQuestDialogueLines;
            Dialogue.Instance.StartDialogue(Quest.midQuestDialogueLines);
        }
    }
}
