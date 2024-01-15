using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

//static makes it available everywhere
public static class SaveData
{
    private static string filePath = Application.persistentDataPath + "/scores.json";
    
    public static void Save(Scores scoreData)
    {
        string data = JsonUtility.ToJson(scoreData);
        File.WriteAllText(filePath,data);
    }

    public static Scores Load()
    {
        //the file doesn't exist, so we stop here!
        if (!File.Exists(filePath))
        {
            return new Scores();
        }

        string data = File.ReadAllText(filePath);
        Scores scoreData = JsonUtility.FromJson<Scores>(data);

        return scoreData;
    }
}
