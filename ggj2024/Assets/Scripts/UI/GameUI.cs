using System;
using Trials;
using UnityEngine;

public class GameUI : Singleton<GameUI>
{
    [SerializeField] private UIBeginMessage _uiBegin;
    [SerializeField] private UIEndLevel _uiEndLevel;
    [SerializeField] private UILevelTimer _uiLevelTimer;
    
    [SerializeField] private GameObject _readyButton;

    [field:SerializeField]
    public Transform PlayerContainer { get; private set; }
    
    public event Action FinishedCountdown;


    private BellySlap _bellySlap;
    public void Start()
    {
        _uiBegin.gameObject.SetActive(false);
        _uiEndLevel.gameObject.SetActive(false);
        _uiLevelTimer.gameObject.SetActive(false);
        
        _bellySlap = BellySlap.Instance as BellySlap;

        SubscribeEvents();

        AudioManager.Instance.PlaySound(AudioTypes.musica_character);
    }

    private void SubscribeEvents()
    {
        _bellySlap.OnLevelBegin += OnLevelBegin;
        _bellySlap.OnLevelFinish += OnFinishGameplay;
        _uiBegin.Finished += OnFinishedCountdown;

        _bellySlap.OnPlayerConnected += OnPlayerConnected;
    }

    private void OnPlayerConnected()
    {
        _readyButton.gameObject.SetActive(true);
    }

    private void UnsubscribeEvents()
    {
        _bellySlap.OnLevelBegin -= OnLevelBegin;
        _bellySlap.OnLevelFinish -= OnFinishGameplay;
        _uiBegin.Finished -= OnFinishedCountdown;
    }

    public void Begin()
    {
        AudioManager.Instance.DestroyAudioSourceAfter(AudioTypes.musica_character);
        _uiBegin.Init();
        _bellySlap.BeginCountDown();
    }
    
    private void OnLevelBegin()
    {
        _uiBegin.gameObject.SetActive(false);
        _uiLevelTimer.Init();
    }

    private void OnFinishedCountdown()
    {
        _bellySlap.InitLevel();
        FinishedCountdown?.Invoke();
    }

    private void OnFinishGameplay()
    {
        _uiEndLevel.Init();
        _uiLevelTimer.gameObject.SetActive(false);
    }
}
