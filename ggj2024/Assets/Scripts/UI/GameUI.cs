using Trials;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    [SerializeField] private UIBeginMessage _uiBegin;
    [SerializeField] private UIEndLevel _uiEndLevel;
    [SerializeField] private UILevelTimer _uiLevelTimer;


    private BellySlap _bellySlap;
    public void Start()
    {
        _uiBegin.gameObject.SetActive(false);
        _uiEndLevel.gameObject.SetActive(false);
        _uiLevelTimer.gameObject.SetActive(false);
        
        
        _bellySlap = BellySlap.Instance as BellySlap;

        _bellySlap.OnLevelBegin += OnLevelBegin;
        _bellySlap.OnLevelFinish += OnFinishGameplay;
        
        Begin();
    }

    private void Begin()
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
