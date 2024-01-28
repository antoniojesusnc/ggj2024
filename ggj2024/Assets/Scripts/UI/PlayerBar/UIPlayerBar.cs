using System;
using System.Timers;
using DG.Tweening;
using Player.PlayerInput;
using Trials.Data;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayerBar : MonoBehaviour
{
    [SerializeField] private UIPlayerBarConfig _config;
    
    [SerializeField] private Image _image;
    
    private float _factor;

    private float _fillValue;
    
    public void Init(PlayerBellySlapData playersController, float factor)
    {
        _factor = factor;
        playersController.NewSlapCount += NewSlapCount;
        _image.fillAmount = 0;
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
        _image.fillAmount -= _config.DownSpeed * Time.deltaTime;
        _image.fillAmount += _fillValue;

        _fillValue = 0;
    }
}