using System;
using System.Timers;
using DG.Tweening;
using Player.PlayerInput;
using TMPro;
using Trials;
using Trials.Data;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayerBar : MonoBehaviour
{
    [SerializeField] private UIPlayerBarConfig _config;
    
    [SerializeField] private Image _image;
    [SerializeField] private GameObject _textObject;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private TextMeshProUGUI _textOutline;
    
    private float _factor;

    private float _fillValue;
    private BellySlap _bellySlap;
    private bool _deductValues;

    public PlayerBellySlapData PlayerBellySlapData { get; private set; }
    
    public void Init(PlayerBellySlapData playersController, float factor)
    {
        _textObject.gameObject.SetActive(false);
        PlayerBellySlapData = playersController;
        
        _factor = factor;
        playersController.NewSlapCount += NewSlapCount;
        _image.fillAmount = 0;

        _bellySlap = (BellySlap.Instance as BellySlap);
        _bellySlap.OnLevelFinish += OnLevelFinish;

        _deductValues = true;

        SetColor();
    }

    public void SetColor()
    {
        _image.color = PlayerBellySlapData.PlayerController.PlayerModel.Color;
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
        _textObject.gameObject.SetActive(true);
        
        _text.text = "0";
        _textOutline.text = "0";
        
        var audioSource = AudioManager.Instance.PlaySound(AudioTypes.tintineo_ascendente);
        audioSource.DOPitch(_factor * _config.MaxPitch, _config.FillSpeed).onComplete += CloseAudio;
        _image.DOFillAmount(_factor, _config.FillSpeed).SetEase(_config.Ease).onComplete += () => OnFinishBarAnimate(callback);

        DOVirtual.Float(0, PlayerBellySlapData.SlapCount, _config.FillSpeed,
                        (number) =>
                        {
                            _text.text = number.ToString("#");
                            _textOutline.text = number.ToString("#");
                        });
    }

    private void CloseAudio()
    {
        AudioManager.Instance.DestroyAudioSourceAfter(AudioTypes.tintineo_ascendente, 0.2f);
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