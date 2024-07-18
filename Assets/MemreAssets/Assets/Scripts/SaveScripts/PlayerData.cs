using System;

[Serializable]
public class PlayerData
{
    public float[] position;
    public float hp;
    public float sp;
    public float hpRegen;
    public float spRegen;
    public int maxHP;
    public int maxSP;
    public int defense;
    public int strength;
    public int agility;
    public int vitality;
    public int intelligence;
    public int baseDefense;
    public int baseHP;
    public int baseSP;
    public int baseStrength;
    public int baseAgility;
    public int baseVitality;
    public int baseIntelligence;
    public int mdfDefense;
    public int mdfHP;
    public int mdfSP;
    public int mdfStrength;
    public int mdfAgility;
    public int mdfVitality;
    public int mdfIntelligence;
    public int skill1Level;
    public int skill2Level;
    public int skill3Level;
    public int rangedSkill1Level;
    public int rangedSkill2Level;
    public int rangedSkill3Level;
    public int unusedSkillPoints;
    public float currentExp;
    public int currentLevel;
    public float neededLvlExp;
    public float holdExp;

    public PlayerData(Player player)
    {
        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;

        hp = player.HP;
        sp = player.SP;
        hpRegen = player.hpRegen;
        spRegen = player.spRegen;
        maxHP = player.maxHP;
        maxSP = player.maxSP;
        defense = player.DEF;
        strength = player.STR;
        agility = player.AGL;
        vitality = player.VIT;
        intelligence = player.INT;
        baseDefense = player.baseDefense;
        baseHP = player.baseHP;
        baseSP = player.baseSP;
        baseStrength = player.basestrength;
        baseAgility = player.baseagility;
        baseVitality = player.basevitality;
        baseIntelligence = player.baseintelligence;
        mdfDefense = player.mdfDefense;
        mdfHP = player.mdfHP;
        mdfSP = player.mdfSP;
        mdfStrength = player.mdfstrength;
        mdfAgility = player.mdfagility;
        mdfVitality = player.mdfvitality;
        mdfIntelligence = player.mdfintelligence;
    }
}

[Serializable]
public class LevelData
{
    public float currentExp;
    public int currentLevel;
    public float neededLvlExp;
    public float holdExp;

    public LevelData(PlayerLevel playerLevel)
    {
        currentExp = playerLevel.currentExp;
        currentLevel = playerLevel.currentLevel;
        neededLvlExp = playerLevel.neededLvlExp;
        holdExp = playerLevel.holdExp;
    }
}

[Serializable]
public class SkillData
{
    public int skill1Level;
    public int skill2Level;
    public int skill3Level;
    public int rangedSkill1Level;
    public int rangedSkill2Level;
    public int rangedSkill3Level;
    public int unusedSkillPoints;

    public SkillData(PlayerSkill playerSkill)
    {
        skill1Level = playerSkill.skill1.level;
        skill2Level = playerSkill.skill2.level;
        skill3Level = playerSkill.skill3.level;
        rangedSkill1Level = playerSkill.rangedskill1.level;
        rangedSkill2Level = playerSkill.rangedskill2.level;
        rangedSkill3Level = playerSkill.rangedskill3.level;
        unusedSkillPoints = playerSkill.unusedSkillPoints;
    }
}