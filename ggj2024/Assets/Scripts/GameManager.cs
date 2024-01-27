
using System.Collections.Generic;
using System.Linq;
using Player;
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
        SceneManager.LoadScene(0);
    }
    
    public void BeginGame()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
    
    public void InitGamePlay()
    {
        
    }

    public void SetPlayerModels(IEnumerable<PlayerModel> playerModels)
    {
        _joinedPlayerModels = playerModels.ToList();
    }
}