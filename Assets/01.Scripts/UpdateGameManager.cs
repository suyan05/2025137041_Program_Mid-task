using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UpdateGameManager : MonoBehaviour
{
    [Header("Rank")]
    public GameObject Level_1_Panel;
    public GameObject Level_2_Panel;
    public GameObject Level_3_Panel;
    public GameObject Level_4_Panel;
    public GameObject Level_5_Panel;

    public TMP_InputField inputField;
    public Button GameStartButton;

    private void Start()
    {
        GameStartButton.onClick.AddListener(OnGameStartButtonClicked);
    }

    private void Update()
    {
        
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
