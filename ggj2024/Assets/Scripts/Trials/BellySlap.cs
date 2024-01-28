using System;
using Player;
using Player.PlayerInput;
using Trials.Data;
using UnityEngine;

namespace Trials
{
    public class BellySlap : Trial<PlayerBellySlapData>
    {
        [SerializeField] 
        private LevelConfig _levelConfig;
        
        public float RemainingTime { get; private set; }
        
        private bool _isPlaying;


        public event Action OnPlayerConnected;
        public event Action OnBeginCountdown;
        public event Action OnLevelBegin;
        public event Action<float> OnUpdateTime; 
        public event Action OnLevelFinish;
        
        public void InitLevel()
        {
            _isPlaying = true;
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
            _isPlaying = false;
            OnLevelFinish?.Invoke();
        }

        protected override IInputCapturing InstantiateInputCapturing(int deviceId)
        {
            OnPlayerConnected?.Invoke();
            
            PlayerAlternatingInput playerAlternatingInput = new(deviceId);
            playerAlternatingInput.AlternatedInputPressed += ValidInputPressed;
            return playerAlternatingInput;
        }

        protected override PlayerTrialData InstantiatePlayerTrialData(PlayerController playerController) =>
            new PlayerBellySlapData {
                PlayerController = playerController
            };

        private void ValidInputPressed(int deviceId, IInputCapturing.InputTypes inputType)
        {
            // Cannot find the Player data for the device --> Do nothing
            if (!PlayerTrialDatas.TryGetValue(deviceId, out PlayerBellySlapData playerTrialData)) return;
            playerTrialData.AddSlapCount(inputType);
            Debug.Log($"Player {playerTrialData.PlayerIndex} pressed alternated {inputType} count: {playerTrialData.SlapCount}");
        }

        public void BeginCountDown()
        {
            OnBeginCountdown?.Invoke();
        }
    }
}