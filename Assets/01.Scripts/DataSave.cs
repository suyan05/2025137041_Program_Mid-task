using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataSave
{
    private const string KEY = "HightScore";

    public static int Lode(int stage)
    {
        return PlayerPrefs.GetInt(KEY + "_" + stage, 0);
    }

    public static void TrySet(int stage, int newScore)
    {
        if (newScore <= Lode(stage)) { return; }

        PlayerPrefs.SetInt(KEY + "_" + stage, newScore);
        PlayerPrefs.Save();
    }
}
