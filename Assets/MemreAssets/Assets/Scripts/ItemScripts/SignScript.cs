using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SignScript : MonoBehaviour
{
    public Transform signTable;
    [SerializeField] public TextMeshProUGUI locationText;
    [SerializeField] public string text;

    private void Start()
    {
        signTable = GetComponent<Transform>();
        locationText = GetComponentInChildren<TextMeshProUGUI>();
        
    }

    void Update()
    {
        if (signTable != null && locationText != null)
        {
            locationText.text = text;
        }
    }
}
