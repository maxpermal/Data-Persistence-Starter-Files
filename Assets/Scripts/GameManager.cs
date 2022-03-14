using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

[System.Serializable]
public class ScoreEntry
{
    public int bestPoints;
    public string playerName;
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private int bestPoints = 0;
    [SerializeField] private string bestPlayerName = "";
    [SerializeField] private ScoreEntry scoreEntry;

    [SerializeField] private string playeName = "";
    public string PlayerName => playeName;

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
    }

    public void UpdateBestScore(int score)
    {
        if(bestPoints <score)
        {
            bestPoints = score;
            bestPlayerName = playeName;
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
        return $"Best Score : {bestPlayerName} : {bestPoints}";
    }

    public void SetPlayerName(string name)
    {
        playeName = name;
    }

    public bool SaveData()
    {
        return true;
    }

    public bool LoadData()
    {
        return true;
    }
}
