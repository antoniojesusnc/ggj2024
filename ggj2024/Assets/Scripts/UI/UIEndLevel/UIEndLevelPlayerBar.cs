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
        _image.DOFillAmount(_factor, _config.FillSpeed).SetEase(_config.Ease).onComplete += () => callback?.Invoke();
    }
}