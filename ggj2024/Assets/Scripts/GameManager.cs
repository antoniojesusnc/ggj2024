using System.Collections.Generic;
using Player;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public int NumberOfPlayers => _joinedPlayerModels.Count;

    private List<PlayerModel> _joinedPlayerModels = new();

    void Start()
    {
        Init();
    }

    private void Init()
    {
        HighScoreService.Instance.LoadHighScores();

        SubscribeToUI();
    }

    private void SubscribeToUI()
    {
        
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
    
    public void BeginGame()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    public void CloseGame()
    {
        Application.Quit();
    }

    public void ShowHighScore()
    {
        SceneManager.LoadScene(2, LoadSceneMode.Single);
    }
}