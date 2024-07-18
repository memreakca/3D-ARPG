using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueEvents : MonoBehaviour
{
    public delegate void NPCEventHandler(string npcName);
    public static event NPCEventHandler OnNPCSpokenTo;

    public static void NPCSpoken(string npcName)
    {
        OnNPCSpokenTo?.Invoke(npcName);
    }
}
