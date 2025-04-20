using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelObj : MonoBehaviour
{
    public string nextLevel;

    public void MoveToNext()
    {
        SceneManager.LoadScene(nextLevel);
    }
}
