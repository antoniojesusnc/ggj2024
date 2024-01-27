using System;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using TMPro;
using Trials;
using Trials.Data;
using Unity.Mathematics;
using UnityEngine;

public class UIEndLevel : MonoBehaviour
{
    [SerializeField] private UIEndLevelConfig _config;
    
    [Header("Items")]
    [SerializeField] private TextMeshProUGUI _finalText;
    [SerializeField] private TextMeshProUGUI _winnerText;
    [SerializeField] private GameObject _continueButton;
    
    [SerializeField] private Transform _parent;

    [SerializeField] private UIEndLevelPlayerBar _uiEndLevelPlayerBarPrefab;

    private List<UIEndLevelPlayerBar> _endLevelPlayerBars = new List<UIEndLevelPlayerBar>();
    private List<PlayerBellySlapData> _players;

    private Tween _idleAnim;

    public event Action Finish;

    public void Init()
    {
        gameObject.SetActive(true);
        
        _players = BellySlap.Instance.PlayerTrialDatas.Values.ToList();
        
        _finalText.gameObject.SetActive(false);
        _winnerText.gameObject.SetActive(false);
        _continueButton.gameObject.SetActive(false);
        CreateSpawnBars();

        ShowMessage();

        BeginSpawnsBars();
    }

    private void ShowMessage()
    {
        _finalText.transform.localScale = Vector3.zero;
        _finalText.gameObject.SetActive(true);
        var sequence = DOTween.Sequence();
        sequence.Append(_finalText.DOScale(_config.TextFinalScale, _config.TextFinalDuration)
                                  .SetEase(_config.TextFinalEase));
        sequence.Insert(_config.TextFinalDuration * 0.75f,
                        _finalText.GetComponent<CanvasGroup>().DOFade(0, _config.TextFinalDuration * 0.25f));
        sequence.onComplete += BeginSpawnsBars;
    }

    private void BeginSpawnsBars()
    {
        DoSpawnBar(0);
    }

    private void DoSpawnBar(int index)
    {
        _endLevelPlayerBars[index].Animate(() => OnFinishSpawnBar(index));
    }

    private void OnFinishSpawnBar(int index)
    {
        MakeLaugh(index);
    }

    private void MakeLaugh(int index)
    {
        
        DOVirtual.DelayedCall(_config.TimeToLaugh, () => ContinueWithBars(index));
    }

    private void ContinueWithBars(int index)
    {
        if (index < _endLevelPlayerBars.Count)
        {
            DoSpawnBar(index + 1);
        }
        EndBarAnimation();
    }

    private void CreateSpawnBars()
    {
        int maxValue = GetMaxValue();
        for (int i = 0; i < _players.Count; i++)
        {
            var spawnMarker = GetSpawnMarker(_players[i], _players[i].SlapCount/(float)maxValue);
            _endLevelPlayerBars.Add(spawnMarker);
        }
    }

    private int GetMaxValue()
    {
        _players.Sort((p1, p2) => p1.SlapCount.CompareTo(p2.SlapCount));
        return _players[0].SlapCount;
    }

    private UIEndLevelPlayerBar GetSpawnMarker(PlayerBellySlapData playerController, float slapFactor)
    {
        return Instantiate(_uiEndLevelPlayerBarPrefab, 
                           playerController.PlayerController.transform.position + _config.BarOffset,
                           quaternion.identity,
                           _parent);
    }
    
    private void EndBarAnimation()
    {
        _winnerText.text = "The Winner is P" + _players[0].PlayerIndex;
        _winnerText.DOScale(_config.TextWinnerScale, _config.TextWinnerDuration)
                   .SetEase(_config.TextWinnerEase).onComplete += OnWinTextFinished;
        MakeWinLoseAnimationsForPlayers();
        
        _continueButton.gameObject.SetActive(true);
    }

    private void OnWinTextFinished()
    {
        _idleAnim = _winnerText.DOScale(_config.TextWinnerIdleScale, _config.TextWinnerIdleDuration)
                            .SetEase(_config.TextWinnerIdleEase).SetLoops(9999, LoopType.Yoyo);
    }

    private void MakeWinLoseAnimationsForPlayers()
    {
        
    }

    public void OnClickInContinue()
    {
        _idleAnim?.Kill();
        _idleAnim = null;
        
        Finish?.Invoke();
    }
}
