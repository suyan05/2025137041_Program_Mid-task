using System.Collections.Generic;
using System.IO;
using UnityEngine;


[System.Serializable]
public class StagResult
{
    public string playerName;
    public int score;
    public int stage;
}

[System.Serializable]
public class StagResultList
{
    public List<StagResult> stagResults = new List<StagResult>();
}

public static class StageResultSaver
{
    private const string FILE = "stagResult.json";
    private const string PLYER_NAME = "PlayerName";
    private static string filePath = Path.Combine(Application.persistentDataPath, FILE);
    public static void SaveStage(int stage,int score)
    {
        StagResultList list = LodeInternal();
        string playerName = PlayerPrefs.GetString(PLYER_NAME, "");
        StagResult enty = new StagResult
        {
            playerName = playerName,
            stage = stage,
            score = score
        };

        list.stagResults.Add(enty);
        string json = JsonUtility.ToJson(list, true);
        File.WriteAllText(filePath, json);
    }

    public static StagResultList LoadRank()
    {
        return LodeInternal();
    }

    private static StagResultList LodeInternal()
    {
        if (!File.Exists(filePath))
        {
            return new StagResultList();
        }

        string json = File.ReadAllText(filePath);
        StagResultList list = JsonUtility.FromJson<StagResultList>(json);

        if(list == null)
        {
            return new StagResultList();
        }
        else
            return list;
    }


}
