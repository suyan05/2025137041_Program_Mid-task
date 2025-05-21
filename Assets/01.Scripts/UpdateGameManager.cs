using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UpdateGameManager : MonoBehaviour
{
    [Header("Rank")]
    public GameObject[] rankList;
    public int rankStage = 0;

    public TMP_InputField inputField;
    public Button GameStartButton;

    private void Start()
    {
        GameStartButton.onClick.AddListener(OnGameStartButtonClicked);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.D))
        {
            if (rankStage >= rankList.Length)
            {
                rankStage = 0;
            }
            else
            rankStage++;
        }

        if(Input.GetKeyDown(KeyCode.A))
        {
            if (rankStage <= 0)
            {
                rankStage = 4;
            }
            else
            rankStage--;
        }

        for (int i = 0; i < rankList.Length; i++)
        {
            if (i == rankStage)
            {
                rankList[i].SetActive(true);
            }
            else
            {
                rankList[i].SetActive(false);
            }
        }
    }

    private void OnGameStartButtonClicked()
    {
        string playerName = inputField.text;
        if (string.IsNullOrEmpty(playerName))
        {
            Debug.Log("플레이어 이름을 입력하세요.");
            return;
        }

        PlayerPrefs.SetString("PlayerName", playerName);
        PlayerPrefs.Save();

        Debug.Log("플레이어 이름 저장: " + playerName);

        SceneManager.LoadScene("01.Stage_1");
    }
}
