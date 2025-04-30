using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI stage1;
    public TextMeshProUGUI stage2;
    public TextMeshProUGUI stage3;
    public TextMeshProUGUI stage4;
    public TextMeshProUGUI stage5;

    public GameObject ESC_Canvas;
    public GameObject To_Canvas;
    public GameObject Score_Canvas;
    
    public static bool ESC = false;
    public bool To = false;
    public bool Score = false;

    private void Awake()
    {
        SaveScore();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (ESC_Canvas != null && !ESC)
            {
                ESCOn();
            }
            else if(ESC_Canvas != null && !To)
            {
                NotGameEnd();
            }
            else if (Score == true)
            {
                ScoreOff();
            }
            else if (To == true)
            {
                TutorialOff();
            }
        }
    }

    private void SaveScore()
    {
        if (!stage1 == false) { stage1.text = "Stage 1: " + DataSave.Lode(1).ToString(); }
        if (!stage2 == false) { stage2.text = "Stage 2: " + DataSave.Lode(2).ToString(); }
        if (!stage3 == false) { stage3.text = "Stage 3: " + DataSave.Lode(3).ToString(); }
        if (!stage4 == false) { stage4.text = "Stage 4: " + DataSave.Lode(4).ToString(); }
        if (!stage5 == false) { stage5.text = "Stage 5: " + DataSave.Lode(5).ToString(); }
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
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void NotGameEnd()
    {
        ESC_Canvas.SetActive(false);
        Time.timeScale = 1f;

        ESC = false;
    }

    public void TutorialOn()
    {
        if (Score_Canvas != null && Score == true)
        {
            ScoreOff();
        }

        To_Canvas.SetActive(true);
        To = true;
    }
    
    public void TutorialOff()
    {
        To_Canvas.SetActive(false);
        To = false;
    }

    public void ScoreOn()
    {
        if(To == true)
        {
            TutorialOff();
        }

        Score_Canvas.SetActive(true);
        Score = true;
    }
    
    public void ScoreOff()
    {
        Score_Canvas.SetActive(false);
        Score = false;
    }
}
