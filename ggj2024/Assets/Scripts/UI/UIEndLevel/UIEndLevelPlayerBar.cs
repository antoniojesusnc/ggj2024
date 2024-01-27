using System;
using DG.Tweening;
using Player;
using Trials.Data;
using UnityEngine;
using UnityEngine.UI;

public class UIEndLevelPlayerBar : MonoBehaviour
{
    [SerializeField] private UIEndLevelPlayerBarConfig _config;
    
    [SerializeField] private Image _image;
    
    private float _factor;
    
    public void Init(PlayerBellySlapData playersController, float factor)
    {
        _factor = factor;
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
}