using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    private static string playerDataPath = Application.persistentDataPath + "/playerdata.save";
    private static string skillsDataPath = Application.persistentDataPath + "/skillsdata.save";
    private static string levelDataPath = Application.persistentDataPath + "/leveldata.save";

    public static void SavePlayer(Player player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(playerDataPath, FileMode.Create);

        PlayerData data = new PlayerData(player);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadPlayer()
    {
        if (File.Exists(playerDataPath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(playerDataPath, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + playerDataPath);
            return null;
        }
    }

    public static void SaveSkills(PlayerSkill playerSkill)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(skillsDataPath, FileMode.Create);

        SkillData data = new SkillData(playerSkill);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static SkillData LoadSkills()
    {
        if (File.Exists(skillsDataPath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(skillsDataPath, FileMode.Open);

            SkillData data = formatter.Deserialize(stream) as SkillData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + skillsDataPath);
            return null;
        }
    }

    public static void SaveLevel(PlayerLevel playerLevel)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(levelDataPath, FileMode.Create);

        LevelData data = new LevelData(playerLevel);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static LevelData LoadLevel()
    {
        if (File.Exists(levelDataPath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(levelDataPath, FileMode.Open);

            LevelData data = formatter.Deserialize(stream) as LevelData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + levelDataPath);
            return null;
        }
    }
}
