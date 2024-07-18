using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BarScripts : MonoBehaviour
{
    [SerializeField] GameObject[] MeleeSkills;
    [SerializeField] GameObject[] RangedSkills;

    public static BarScripts Instance;
    [SerializeField] public Image healthSlider;
    public TextMeshProUGUI healthText;
    [SerializeField] public Image manaSlider;
    public TextMeshProUGUI manaText;
    [SerializeField] public Image LevelSlider;
    public TextMeshProUGUI levelText;

    [SerializeField] public Image skill1; [SerializeField] public TextMeshProUGUI skill1cdtxt;
    [SerializeField] public Image skill2; [SerializeField] public TextMeshProUGUI skill2cdtxt;
    [SerializeField] public Image skill3; [SerializeField] public TextMeshProUGUI skill3cdtxt;
    [SerializeField] public Image rangedskill1; [SerializeField] public TextMeshProUGUI rangedskill1cdtxt;
    [SerializeField] public Image rangedskill2; [SerializeField] public TextMeshProUGUI rangedskill2cdtxt;
    [SerializeField] public Image rangedskill3; [SerializeField] public TextMeshProUGUI rangedskill3cdtxt;

    private void Update()
    {
        if (CharacterMovement.main.onMelee == true)
        {
            for(int i = 0; i < MeleeSkills.Length; i++)
            {
                RangedSkills[i].SetActive(false);
                MeleeSkills[i].SetActive(true);
            }
        }
        else
        {
            for (int i = 0; i < MeleeSkills.Length; i++)
            {
                RangedSkills[i].SetActive(true);
                MeleeSkills[i].SetActive(false);
            }
        }
    }
    private void Awake()
    {
        Instance = this;
    }
    public void SetLevel(float expamount, float maxexpamount)
    {
        LevelSlider.fillAmount = expamount / maxexpamount;
        levelText.text = $"{expamount:F0}/{maxexpamount:F0}";
    }

    public void SetHealth(float hp, float maxHp)
    {
        healthSlider.fillAmount = hp / maxHp;
        healthText.text = $"{hp:F0}/{maxHp:F0}";
    }

    public void SetMana(float sp, float maxSp) 
    { 
        manaSlider.fillAmount = sp / maxSp;
        manaText.text = $"{sp:F0}/{maxSp:F0}";
    }

    public void SetCooldownSkill1(Skill _skill)
    {
        skill1.fillAmount = _skill.cooldown / _skill.maxCooldown;
        skill1cdtxt.text = (_skill.cooldown == 0) ? $" " : $"{_skill.cooldown:F1} ";
    }
    public void SetCooldownSkill2(Skill _skill)
    {
        skill2.fillAmount = _skill.cooldown / _skill.maxCooldown;
        skill2cdtxt.text = (_skill.cooldown == 0) ? $" " : $"{_skill.cooldown:F1} ";
    }
    public void SetCooldownSkill3(Skill _skill)
    {
        skill3.fillAmount = _skill.cooldown / _skill.maxCooldown;
        skill3cdtxt.text = (_skill.cooldown == 0) ? $" " : $"{_skill.cooldown:F1} ";
    }

    public void SetCooldownRangedSkill1(Skill _skill)
    {
        rangedskill1.fillAmount = _skill.cooldown / _skill.maxCooldown;
        rangedskill1cdtxt.text = (_skill.cooldown == 0) ? " " : $"{_skill.cooldown:F1} ";
    }
    public void SetCooldownRangedSkill2(Skill _skill)
    {
        rangedskill2.fillAmount = _skill.cooldown / _skill.maxCooldown;
        rangedskill2cdtxt.text = (_skill.cooldown == 0) ? " " : $"{_skill.cooldown:F1} ";
    }
    public void SetCooldownRangedSkill3(Skill _skill)
    {
        rangedskill3.fillAmount = _skill.cooldown / _skill.maxCooldown;
        rangedskill3cdtxt.text = (_skill.cooldown == 0) ? " " : $"{_skill.cooldown:F1} ";
    }

}
