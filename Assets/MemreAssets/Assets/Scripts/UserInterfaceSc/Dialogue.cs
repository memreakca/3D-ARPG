using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public static Dialogue Instance { get; set; }

    public GameObject DialoguePanel;
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;

    private int index;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        textComponent.text = string.Empty;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && DialoguePanel.activeSelf)
        {
            if(textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    public void NextLine()
    {
        if (index < lines.Length - 1) 
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            lines = null;
            Time.timeScale = 1;
            textComponent.text = string.Empty;
            DialoguePanel.SetActive(false);
        }
    }
    public void StartDialogue(string[] lines)
    {
        DialoguePanel.SetActive(true);
        this.lines = lines; 
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine(){
        foreach(char c in lines[index].ToCharArray()) 
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
}
