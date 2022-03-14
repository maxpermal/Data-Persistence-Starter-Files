using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
#if UNITY_EDITOR
using UnityEditor;
#endif

[System.Serializable]
public struct ScoreEntry
{
    public int bestPoints;
    public string bestPlayerName;
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private ScoreEntry scoreEntry;
    [SerializeField] private string playeName = "";

    public string PlayerName => playeName;

    [SerializeField] string filenameCfg = "/saveDataBreaker.json";

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        // end of new code
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadData();
    }

    public void UpdateBestScore(int score)
    {
        if(scoreEntry.bestPoints <score)
        {
            scoreEntry.bestPoints = score;
            scoreEntry.bestPlayerName = playeName;
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    public void QuitApp()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }

    public string GetBestScore()
    {
        return $"Best Score : {scoreEntry.bestPlayerName} : {scoreEntry.bestPoints}";
    }

    public void SetPlayerName(string name)
    {
        playeName = name;
    }

    public void SaveData()
    {
        ScoreEntry data = scoreEntry;
        string json = JsonUtility.ToJson(data);
        string path = Application.persistentDataPath + filenameCfg;
        File.WriteAllText(path, json);
    }

    public bool LoadData()
    {
        string path = Application.persistentDataPath + filenameCfg;
        Debug.Log(path);
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            scoreEntry = JsonUtility.FromJson<ScoreEntry>(json);
            return true;
        }
        return false;
    }
}
