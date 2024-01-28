using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Trials;
using Trials.Data;
using Unity.Mathematics;
using UnityEngine;

public class UIPlayerBarManager : MonoBehaviour
{
    [SerializeField] private UIPlayerBarConfig _config;
    [SerializeField] private UIPlayerBar _playerBarPrefab;
    [SerializeField] private Transform _parent;
    private BellySlap _bellySlap;

    void Start()
    {
        _bellySlap = BellySlap.Instance as BellySlap;
        _bellySlap.OnLevelBegin += OnLevelBegin;
    }

    private void OnLevelBegin()
    {
        var playerData = _bellySlap.PlayerTrialDatas.Values.ToList();
        for (int i = 0; i < playerData.Count; i++)
        {
            GetPlayerBar(playerData[i]);
        }
    }
    
    private UIPlayerBar GetPlayerBar(PlayerBellySlapData playerController)
    {
        return Instantiate(_playerBarPrefab, 
                           playerController.PlayerController.transform.position + _config.BarOffset,
                           quaternion.identity,
                           _parent);
    }
}
