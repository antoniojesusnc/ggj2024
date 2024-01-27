using Trials;
using UnityEngine;

public class GameUI : Singleton<GameUI>
{
    [SerializeField] private UIBeginMessage _uiBegin;
    [SerializeField] private UIEndLevel _uiEndLevel;
    [SerializeField] private UILevelTimer _uiLevelTimer;

    [field:SerializeField]
    public Transform PlayerContainer { get; private set; }


    private BellySlap _bellySlap;
    public void Start()
    {
        _uiBegin.gameObject.SetActive(false);
        _uiEndLevel.gameObject.SetActive(false);
        _uiLevelTimer.gameObject.SetActive(false);
        
        _bellySlap = BellySlap.Instance as BellySlap;

        SubscribeEvents();

        //Begin();
    }

    private void SubscribeEvents()
    {
        _bellySlap.OnLevelBegin += OnLevelBegin;
        _bellySlap.OnLevelFinish += OnFinishGameplay;
    }

    private void UnsubscribeEvents()
    {
        _bellySlap.OnLevelBegin -= OnLevelBegin;
        _bellySlap.OnLevelFinish -= OnFinishGameplay;
    }

    public void Begin()
    {
        _uiBegin.Init();
        _uiBegin.Finished += FinishedCountDown;
    }
    
    private void OnLevelBegin()
    {
        _uiBegin.gameObject.SetActive(false);
        _uiLevelTimer.Init();
    }

    private void FinishedCountDown()
    {
        _bellySlap.InitLevel();
    }

    private void OnFinishGameplay()
    {
        _uiEndLevel.Init();
        _uiLevelTimer.gameObject.SetActive(false);
    }
}
