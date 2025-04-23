using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static bool ESC = false;
    public bool To = false;
    public GameObject ESC_Canvas;
    public GameObject To_Canvas;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (ESC_Canvas != null && !ESC)
            {
                ESCOn();
            }
            else if(!To)
            {
                NotGameEnd();
            }
            else
            {
                TutorialOff();
            }
        }
    }

    private void ESCOn()
    {
        Time.timeScale = 0f;
        ESC_Canvas.SetActive(true);
        ESC = true;
    }

    public void MainScene()
    {
        SceneManager.LoadScene("01.Stage_1");
    }
    
    public void StageScene()
    {
        SceneManager.LoadScene("MainManu");
        Time.timeScale = 1f;
    }

    public void GameEnd()
    {
        Application.Quit();
    }

    public void NotGameEnd()
    {
        ESC_Canvas.SetActive(false);
        Time.timeScale = 1f;

        ESC = false;
    }

    public void TutorialOn()
    {
        To_Canvas.SetActive(true);
        To = true;
    }
    
    public void TutorialOff()
    {
        To_Canvas.SetActive(false);
        To = false;
    }
}
