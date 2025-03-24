using System;
using System.IO;
using UnityEngine;

public class PlayerDataManager : MonoBehaviour
{
    public static PlayerDataManager Instance { get; private set; }
    public string CurrentPlayerName;
    public int BestScore;
    public string ScoreHolder;

    string path;

    private void Awake()
    {
        if (Instance == null)
        {
            path = Application.persistentDataPath + "/savefile.json";
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadBestScore();
            return;
        }
        Destroy(gameObject);
    }

    [Serializable]
    public class PlayerData
    {
        public string Name;
        public int Score;
    }

    public void SaveBestScore(int score)
    {
        ScoreHolder = CurrentPlayerName;
        BestScore = score;

        PlayerData playerData = new() { Name = CurrentPlayerName, Score = score };
        string json = JsonUtility.ToJson(playerData);
        Debug.Log(json);
        File.WriteAllText(path, json);
    }

    public void LoadBestScore()
    {
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            PlayerData playerData = JsonUtility.FromJson<PlayerData>(json);
            BestScore = playerData.Score;
            ScoreHolder = playerData.Name;
        }
    }
}
