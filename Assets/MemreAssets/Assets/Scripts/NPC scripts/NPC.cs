using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour, IInteractable
{
    public string npcName;
    public string[] NPCDialogue;

    public TextMeshProUGUI nametext;
    public Image iconImage;

    public Sprite HasQuest;
    public Sprite MidQuest;
    public Sprite FinishedQuest;
    private void Start()
    {
        iconImage = gameObject.GetComponentInChildren<Image>();
        if (npcName != "BossDragon")
        {
            nametext = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        }
        if (nametext != null) nametext.text = npcName;
    }

    private void Update()
    {
        QuestGiver questGiver = gameObject.GetComponent<QuestGiver>();
        if (questGiver != null && questGiver.questType != string.Empty)
        {
            if (iconImage != null)
            {
                iconImage.enabled = true;
                if (!questGiver.AssignedQuest)
                {
                    iconImage.sprite = HasQuest;
                }
                else if (questGiver.AssignedQuest && !questGiver.questInstance.Completed)
                {
                    iconImage.sprite = MidQuest;
                }
                else
                {
                    iconImage.sprite = FinishedQuest;
                }
            }

        }
        else
        {
            if (iconImage != null)
            {
                iconImage.enabled = false;
                return;

            }
        }
    }
    public void Interact()
    {
        Player.main.AssignRespawnPoint();
        QuestGiver questGiver = GetComponent<QuestGiver>();

        if (questGiver != null && questGiver.questType != string.Empty)
        {
            questGiver.Interact();
            return;
        }

        if (NPCDialogue != null && NPCDialogue.Length > 0)
        {
            Dialogue.Instance.StartDialogue(NPCDialogue);
        }
        DialogueEvents.NPCSpoken(npcName);

    }
}