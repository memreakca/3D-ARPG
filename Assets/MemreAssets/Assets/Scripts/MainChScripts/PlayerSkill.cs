using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSkill : MonoBehaviour
{
    public static PlayerSkill instance;
    public GameObject SkillUI;
    public SkillFunctionality skillFunctionality;

    public TextMeshProUGUI unusedSkillpointTXT;

    public TextMeshProUGUI skill1text;
    public TextMeshProUGUI skill2text;
    public TextMeshProUGUI skill3text;
    public TextMeshProUGUI RangedSkill1text;
    public TextMeshProUGUI RangedSkill2text;
    public TextMeshProUGUI RangedSkill3text;

    public Skill skill1;
    public Skill skill2;
    public Skill skill3;
    public Skill rangedskill1;
    public Skill rangedskill2;
    public Skill rangedskill3;

    public GameObject rangedSkill1Flame;
    public GameObject rangedSkill2Rain;
    public GameObject rangedSkill3Barrier;

    public int unusedSkillPoints = 1;

    private void Start()
    {
        unusedSkillPoints = 1;
        skill1.Text = skill1text;
        skill2.Text = skill2text;
        skill3.Text = skill3text;
        rangedskill1.Text = RangedSkill1text;
        rangedskill2.Text = RangedSkill2text;
        rangedskill3.Text = RangedSkill3text;

        skillFunctionality = GetComponent<SkillFunctionality>();
        skillFunctionality.SetPlayerSkill(this);
    }
    private void Update()
    {
        unusedSkillpointTXT.text = $"Kullanýlmamýþ Beceri Puaný = {unusedSkillPoints}";
        if (CharacterMovement.main.isEquipping || PlayerAttackCombo.main.isHitting || PlayerRangedAttack.main.isAttacking || Time.timeScale == 0) return;
        
        
        Skill1Button();
        Skill2Button();
        Skill3Button();
    }
    private void Awake()
    {
        instance = this;
    }
    public void UpgradeSkill1()
    {
        if (skill1.level < skill1.maxLevel && unusedSkillPoints >= 1)
        {
            unusedSkillPoints--;
            skill1.Upgrade();
        }
        else
        {
            Debug.Log("Cannot upgrade Skill 1. Max level reached or not enough skill points.");
        }

    }
    public void UpgradeSkill2() 
    {
        if (skill2.level < skill2.maxLevel && unusedSkillPoints >= 1)
        {
            unusedSkillPoints--;
            skill2.Upgrade();
        }
        else
        {
            Debug.Log("Cannot upgrade Skill 2. Max level reached or not enough skill points.");
        }

    }
    public void UpgradeSkill3() 
    {
        if (skill3.level < skill3.maxLevel && unusedSkillPoints >= 1)
        {
            unusedSkillPoints--;
            skill3.Upgrade();
        }
        else
        {
            Debug.Log("Cannot upgrade Skill 3. Max level reached or not enough skill points.");
        }
    }
    public void UpgradeRangedSkill1() 
    {
        if (rangedskill1.level < rangedskill1.maxLevel && unusedSkillPoints >= 1)
        {
            unusedSkillPoints--;
            rangedskill1.Upgrade();
        }
        else
        {
            Debug.Log("Cannot upgrade .");
        }
    }

    public void UpgradeRangedSkill2()
    {
        if (rangedskill2.level < rangedskill2.maxLevel && unusedSkillPoints >= 1)
        {
            unusedSkillPoints--;
            rangedskill2.Upgrade();
        }
        else
        {
            Debug.Log("Cannot upgrade ");
        }
    }
    public void UpgradeRangedSkill3()
    {
        if (rangedskill3.level < rangedskill3.maxLevel && unusedSkillPoints >= 1)
        {
            unusedSkillPoints--;
            rangedskill3.Upgrade();
        }
        else
        {
            Debug.Log("Cannot upgrade");
        }
    }

    public void SetSkillFunctionality(PlayerSkill skill)
    {
        skillFunctionality.SetPlayerSkill(skill);
    }

    public void Skill1Button()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (CharacterMovement.main.onMelee == true)
            {
                skillFunctionality.UseSkill1();
            }
            if (CharacterMovement.main.onMelee == false)
            {
                skillFunctionality.UseRangedSkill1();
            }

        }
    }
    public void Skill2Button()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (CharacterMovement.main.onMelee == true)
            {
                skillFunctionality.UseSkill2();
            }
            if (CharacterMovement.main.onMelee == false)
            {
                skillFunctionality.UseRangedSkill2();
            }
        }
    }
    public void Skill3Button()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (CharacterMovement.main.onMelee == true)
            {
                skillFunctionality.UseSkill3();
            }
            if (CharacterMovement.main.onMelee == false)
            {
                skillFunctionality.UseRangedSkill3();
            }
        }
    }
    public void SaveSkills()
    {
        SaveSystem.SaveSkills(this);
    }

    public void LoadSkills()
    {
        SkillData data = SaveSystem.LoadSkills();

        skill1.level = data.skill1Level;
        skill2.level = data.skill2Level;
        skill3.level = data.skill3Level;
        rangedskill1.level = data.rangedSkill1Level;
        rangedskill2.level = data.rangedSkill2Level;
        rangedskill3.level = data.rangedSkill3Level;

        unusedSkillPoints = data.unusedSkillPoints;

    }

}
[System.Serializable]
public class Skill
{
    public string name;
    public float maxCooldown;
    public float baseDamage;
    public float damage;
    public float cooldown;
    public float manacost;
    public int level;
    public int maxLevel = 4;
    public TextMeshProUGUI Text;

    public void Upgrade()
    {
        if (level < maxLevel)
        {
            level++;
            Text.text = (level == maxLevel) ? $"Seviye = MAX" : $"Seviye = {level}";
        }
        else
        {
            Debug.Log("Max LEVEL");
        }
    }
    public void SetCooldown()
    {
        cooldown = maxCooldown - level;
    }
}