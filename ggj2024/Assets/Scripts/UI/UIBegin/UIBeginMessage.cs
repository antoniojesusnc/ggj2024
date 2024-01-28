using System;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIBeginMessage : MonoBehaviour
{
    [SerializeField] private UIBeginConfig _config;
    
    [SerializeField]
    public Image _counter;
    [SerializeField]
    public CanvasGroup _counterCanvas;

    public event Action Finished;

    private int _countdown;

    public void Init()
    {
        gameObject.SetActive(true);
        _counter.gameObject.SetActive(false);
        _countdown = _config.Countdown;
        
        DoNumberAnimation(_config.NumberImages.Count);
            AudioManager.Instance.PlaySound(AudioTypes.three_two_one_laught_para_el_juego);
    }

    private void DoNumberAnimation(int countDown)
    {
        _counter.gameObject.SetActive(true);
        _counter.transform.localScale = Vector3.zero;
        _counterCanvas.alpha = 1;

        _counter.sprite = _config.NumberImages[_config.NumberImages.Count - countDown];
        _counter.SetNativeSize();
        
        AudioManager.Instance.PlaySound(AudioTypes.sonido_de_comienzo);

        var sequence = DOTween.Sequence();
        sequence.Append(_counter.transform.DOScale(_config.NumberScale, _config.NumberTime));
        sequence.Insert(_config.TimeToBeginFadeOut,
                        _counterCanvas.DOFade(0, _config.NumberTime - _config.TimeToBeginFadeOut));
        sequence.onComplete += OnEndNumber;
    }

    private void OnEndNumber()
    {
        --_countdown;
        string text = _countdown.ToString();
        if (_countdown <= 0)
        {
            OnFinished();
            return;
        }

        DOVirtual.DelayedCall(_config.TimeBetweenNumbers, () => DoNumberAnimation(_countdown));
    }

    private void OnFinished()
    {
        AudioManager.Instance.PlaySound(AudioTypes.musica_go);
        AudioManager.Instance.PlaySound(AudioTypes.musica_in_game);

        Finished?.Invoke();
    }
}
