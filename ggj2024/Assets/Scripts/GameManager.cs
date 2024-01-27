
using System.Collections.Generic;
using System.Linq;
using Player;
using Trials;
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
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        if (arg0.buildIndex == 1)
        {
            ((BellySlap)BellySlap.Instance).JoinPlayers(_joinedPlayerModels);
        }
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

    public void SetPlayerModels(IEnumerable<PlayerModel> playerModels)
    {
        _joinedPlayerModels = playerModels.ToList();
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}