using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIHandler : MonoBehaviour
{
    public TMP_InputField playerNameInput;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = GameManager.Instance.GetBestScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSetName()
    {
        GameManager.Instance.SetCurrentPlayerName(playerNameInput.text);
    }

    public void OnStartGame()
    {
        GameManager.Instance.StartGame();
    }

    public void OnQuit()
    {
        GameManager.Instance.QuitApp();
    }
}
