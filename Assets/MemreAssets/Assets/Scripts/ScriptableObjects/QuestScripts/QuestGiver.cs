using System.Collections;
using UnityEngine;

public class QuestGiver : MonoBehaviour, IInteractable
{
    public bool AssignedQuest;
    public bool Helped;
    [SerializeField] public string questType;

    public Quest questInstance;

    [SerializeField] public GameObject nextQuestGiverObject;
    [SerializeField] public string nextQuestType;
    [SerializeField] private Dialogue dialogue;

    private GameObject questsManager;

    private void Start()
    {
        dialogue = Dialogue.Instance;
        questsManager = QuestManager.Instance.gameObject;
    }

    public void Interact()
    {
        if (string.IsNullOrEmpty(questType))
        {
            Debug.Log("No quest assigned.");
            return;
        }

        if (!AssignedQuest && !Helped)
        {
            AssignQuest();
        }
        else if (AssignedQuest && !Helped)
        {
            CheckQuest();
        }
    }

    public void AssignQuest()
    {
        if (questsManager == null)
        {
            Debug.LogError("QuestManager GameObject reference is not set.");
            return;
        }

        AssignedQuest = true;
        questInstance = questsManager.AddComponent(System.Type.GetType(questType)) as Quest;
        if (questInstance != null)
        {
            questInstance.Init();
            QuestManager.Instance.AddQuest(questInstance);
            Debug.Log("Quest Assigned: " + questType);
            Player.main.AssignRespawnPoint();
            StartDialogue(questInstance.assignmentDialogueLines);
        }

    }

    public void CheckQuest()
    {
        if (questInstance == null)
        {
            Debug.LogError("No quest instance assigned.");
            return;
        }

        if (questInstance.Completed)
        {
            questInstance.GiveReward();
            Helped = true;
            AssignedQuest = false;
            Player.main.AssignRespawnPoint();
            AssignNextQuestGiver();
            QuestManager.Instance.CompleteQuest(questInstance);
            StartDialogue(questInstance.completionDialogueLines);
            RemoveQuestGiver();
        }
        else
        {
            Debug.Log("Quest is not completed yet.");
        }
    }

    private void AssignNextQuestGiver()
    {
        if (nextQuestGiverObject != null && !string.IsNullOrEmpty(nextQuestType))
        {
            QuestGiver questGiver = nextQuestGiverObject.GetComponent<QuestGiver>();
            if (questGiver != null)
            {
                questGiver.questType = nextQuestType;
                questGiver.AssignedQuest = false;
                questGiver.Helped = false;
                questGiver.questsManager = this.questsManager;
            }
            else
            {
                questGiver = nextQuestGiverObject.AddComponent<QuestGiver>();
                questGiver.questType = nextQuestType;
            }
        }
    }

    private void RemoveQuestGiver()
    {
        Destroy(this);
    }
    private void StartDialogue(string[] lines)
    {
        if (dialogue != null && lines != null && lines.Length > 0)
        {
            dialogue.DialoguePanel.SetActive(true);
            dialogue.StartDialogue(lines); 
        }
        else
        {
            Debug.Log("No dialogue lines found.");
        }
    }
}
