using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private int bestPoints = 0;
    public int BestPoints { get { return bestPoints; } set { bestPoints = value; } }
    [SerializeField] private string bestplayername = "";
    public string BestPlayerName { get { return bestplayername; } set { bestplayername = value; } }

    [SerializeField] private string playername = "";
    public string PlayerName { get { return playername; } set { playername = value; } }

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
        if(BestPoints<score)
        {
            BestPoints = score;
            BestPlayerName = playername;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
        return $"Best Score : {BestPlayerName} : {BestPoints}";
    }

    public void SetCurrentPlayerName(string name)
    {
        playername = name;
    }
}
