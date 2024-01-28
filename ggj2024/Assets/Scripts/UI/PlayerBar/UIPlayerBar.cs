using System;
using System.Timers;
using DG.Tweening;
using Player.PlayerInput;
using Trials;
using Trials.Data;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayerBar : MonoBehaviour
{
    [SerializeField] private UIPlayerBarConfig _config;
    
    [SerializeField] private Image _image;
    
    private float _factor;

    private float _fillValue;
    private BellySlap _bellySlap;
    private bool _deductValues;

    public PlayerBellySlapData PlayerBellySlapData { get; private set; }
    
    public void Init(PlayerBellySlapData playersController, float factor)
    {
        PlayerBellySlapData = playersController;
        
        _factor = factor;
        playersController.NewSlapCount += NewSlapCount;
        _image.fillAmount = 0;

        _bellySlap = (BellySlap.Instance as BellySlap);
        _bellySlap.OnLevelFinish += OnLevelFinish;

        _deductValues = true;
    }

    private void OnLevelFinish()
    {
        _deductValues = false;
    }

    private void NewSlapCount(IInputCapturing.InputTypes input)
    {
        _fillValue = _config.IncreasePerInput;
    }

    public void Animate(Action callback)
    {
        var audioSource = AudioManager.Instance.PlaySound(AudioTypes.tintineo_ascendente);
        audioSource.DOPitch(_factor * _config.MaxPitch, _config.FillSpeed);
        _image.DOFillAmount(_factor, _config.FillSpeed).SetEase(_config.Ease).onComplete += () => OnFinishBarAnimate(callback);
    }

    private void OnFinishBarAnimate(Action callback)
    {
        if (_factor <= 1)
        {
            AudioManager.Instance.PlaySound(AudioTypes.explosión);
        }
        callback?.Invoke();
    }

    void Update()
    {
        if (!_deductValues)
        {
            return;
        }
        
        _image.fillAmount -= _config.DownSpeed * Time.deltaTime;
        _image.fillAmount += _fillValue;

        _fillValue = 0;
    }
}