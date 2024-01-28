using System;
using Trials;
using UnityEngine;

public class GameUI : Singleton<GameUI>
{
    [SerializeField] private UIBeginMessage _uiBegin;
    [SerializeField] private UIEndLevel _uiEndLevel;
    [SerializeField] private UILevelTimer _uiLevelTimer;
    
    [SerializeField] private GameObject _readyButton;
    [SerializeField] private GameObject _pressStartText;

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
        _bellySlap.OnPlayerConnected += OnPlayerConnected;
        _bellySlap.AllPlayersIn += OnAllPlayersIn;
        _bellySlap.OnLevelBegin += OnLevelBegin;
        _bellySlap.OnLevelFinish += OnFinishGameplay;
        _uiBegin.Finished += OnFinishedCountdown;
    }

    private void UnsubscribeEvents()
    {
        _bellySlap.OnPlayerConnected -= OnPlayerConnected;
        _bellySlap.AllPlayersIn -= OnAllPlayersIn;
        _bellySlap.OnLevelBegin -= OnLevelBegin;
        _bellySlap.OnLevelFinish -= OnFinishGameplay;
        _uiBegin.Finished -= OnFinishedCountdown;
    }

    private void OnAllPlayersIn()
    {
        HidePressStartMessage();
    }

    private void OnPlayerConnected()
    {
        _readyButton.gameObject.SetActive(true);
    }

    public void Begin()
    {
        HidePressStartMessage();
        AudioManager.Instance.DestroyAudioSourceAfter(AudioTypes.musica_character);
        _uiBegin.Init();
        _bellySlap.BeginCountDown();
    }

    private void HidePressStartMessage()
    {
        _pressStartText.SetActive(false);
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
