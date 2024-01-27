using System;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class UIBeginMessage : MonoBehaviour
{
    [SerializeField] private UIBeginConfig _config;
    
    [SerializeField]
    private CanvasGroup _counter;
    [SerializeField]
    private TextMeshProUGUI _counterText;

    public event Action Finished;

    private int _countDown;

    public void Init()
    {
        gameObject.SetActive(true);
        _counter.gameObject.SetActive(false);
        _countDown = _config.CountDown;
        
        DoNumberAnimation(_config.InitialText);
    }

    private void DoNumberAnimation(string text)
    {
        _counter.gameObject.SetActive(true);
        _counter.transform.localScale = Vector3.zero;
        _counter.alpha = 1;
        
        AudioManager.Instance.PlaySound(AudioTypes.sonido_de_comienzo);
        
        _counterText.text = text;
        var sequence = DOTween.Sequence();
        sequence.Append(_counter.transform.DOScale(_config.NumberScale, _config.NumberTime));
        sequence.Insert(_config.TimeToBeginFadeOut,
                        _counter.DOFade(0, _config.NumberTime - _config.TimeToBeginFadeOut));
        sequence.onComplete += OnEndNumber;
    }

    private void OnEndNumber()
    {
        --_countDown;
        string text = _countDown.ToString();
        if (_countDown < 0)
        {
            OnFinished();
            return;
        }

        if (_countDown == 0)
        {
            text = _config.FinalText;
        }

        if (_countDown == 3)
        {
            AudioManager.Instance.PlaySound(AudioTypes.three_two_one_laught_para_el_juego);
        }
        
        DOVirtual.DelayedCall(_config.TimeBetweenNumbers, () => DoNumberAnimation(text));
    }

    private void OnFinished()
    {
        AudioManager.Instance.PlaySound(AudioTypes.musica_go);
        AudioManager.Instance.PlaySound(AudioTypes.musica_in_game);

        Finished?.Invoke();
    }
}
