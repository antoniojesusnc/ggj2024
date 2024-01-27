using System;
using UnityEngine;

public class LevelController : Singleton<LevelController>
{
    [SerializeField] 
    private LevelConfig _levelConfig;
    
    public float RemainingTime { get; private set; }
    

    public event Action OnLevelBegin;
    public event Action<float> OnUpdateTime; 
    public event Action OnLevelFinish;
    
    private bool _isPlaying; 
    
    public void InitLevel()
    {
        RemainingTime = _levelConfig.LevelDuration;
        OnLevelBegin?.Invoke();
    }

    public void Update()
    {
        if (!_isPlaying)
        {
            return;
        }

        UpdateRemainingTime();
    }

    private void UpdateRemainingTime()
    {
        RemainingTime -= Time.deltaTime;
        OnUpdateTime?.Invoke(RemainingTime);

        if (RemainingTime <= 0)
        {
            LevelFinish();
        }
    }

    private void LevelFinish()
    {
        OnLevelFinish?.Invoke();
    }
}
