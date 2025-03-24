using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public TextMeshProUGUI bestScoreText;
    public TMP_InputField playerName;

    void Start()
    {
        string scoreHolder = PlayerDataManager.Instance.ScoreHolder;
        int bestScore = PlayerDataManager.Instance.BestScore;
        bestScoreText.text = $"Best Score : {scoreHolder} : {bestScore}";
    }

    public void OnPlayerNameChange()
    {
        PlayerDataManager.Instance.CurrentPlayerName = playerName.text;
    }

    public void OnStartClick()
    {
        Debug.Log($"current player : {PlayerDataManager.Instance.CurrentPlayerName}");
        SceneManager.LoadScene(1);
    }

    public void OnQuitClick()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
