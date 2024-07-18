using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatsOnInventory : MonoBehaviour
{
    public static StatsOnInventory Instance;

    [SerializeField] public TextMeshProUGUI HPtext;
    [SerializeField] public TextMeshProUGUI SPtext;
    [SerializeField] public TextMeshProUGUI DEFtext;
    [SerializeField] public TextMeshProUGUI INTtext;
    [SerializeField] public TextMeshProUGUI STRtext;
    [SerializeField] public TextMeshProUGUI VITtext;
    [SerializeField] public TextMeshProUGUI AGLtext;
    [SerializeField] public TextMeshProUGUI HPREGtext;
    [SerializeField] public TextMeshProUGUI SPREGtext;

    private void Awake()
    {
        Instance = this;
    }

    public void UpdateTexts()
    {
        HPtext.text = Player.main.maxHP.ToString();
        SPtext.text = Player.main.maxSP.ToString(); 
        DEFtext.text = Player.main.DEF.ToString();
        INTtext.text = Player.main.INT.ToString();
        STRtext.text = Player.main.STR.ToString();
        VITtext.text = Player.main.VIT.ToString();
        AGLtext.text = Player.main.AGL.ToString();
        HPREGtext.text = Player.main.hpRegen.ToString();
        SPREGtext.text = Player.main.spRegen.ToString();
    }
}
