using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public int NumberOfPlayers { get; private set; }
    
    void Start()
    {
        //SceneManager.sceneLoaded
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

    public void SetPlayerNumbers(int numberOfPlayers)
    {
        NumberOfPlayers = numberOfPlayers;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    
    public void BeginGame()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
}