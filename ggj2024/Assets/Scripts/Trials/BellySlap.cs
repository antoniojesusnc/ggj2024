using System;
using System.Collections.Generic;
using Player;
using Player.PlayerInput;
using Trials.Data;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Trials
{
    public class BellySlap : Trial<PlayerBellySlapData>
    {
        [SerializeField] 
        private LevelConfig _levelConfig;
        
        public float RemainingTime { get; private set; }
        
        private PlayerInputManager _playerInputManager;
        private PlayerInputManager PlayerInputManager => _playerInputManager ??= GetComponent<PlayerInputManager>();
        private bool _isPlaying;


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
            OnLevelFinish?.Invoke();
        }

        /// <summary>
        /// Joins a list of players to the game.
        /// </summary>
        /// <param name="playerModels"></param>
        public void JoinPlayers(IEnumerable<PlayerModel> playerModels)
        {
            foreach (PlayerModel playerModel in playerModels)
            {
                JoinPlayer(playerModel);
            }
        }

        /// <summary>
        /// Joins player to the game configuring it with a <see cref="PlayerInput"/>.
        /// </summary>
        /// <param name="playerModel">Configuration to use for the player.</param>
        private void JoinPlayer(PlayerModel playerModel)
        {
            // Join the player (instantiate its GameObject)
            PlayerInput playerInput = PlayerInputManager.JoinPlayer(playerIndex: playerModel.PlayerIndex, pairWithDevice: playerModel.Device);
            playerInput.gameObject.transform.SetParent(GameUI.Instance.PlayerContainer);
            // TODO: Place properly in the scene
            // Instantiate the Input capturing for this trial
            PlayerAlternatingInput playerAlternatingInput = new PlayerAlternatingInput(playerModel.DeviceId);
            playerAlternatingInput.AlternatedInputPressed += ValidInputPressed;
            // Get the character controller of the new player and initialise its values
            PlayerController playerController = playerInput.GetComponent<PlayerController>();
            playerController.PlayerIndex = playerModel.PlayerIndex;
            playerController.InputCapturing = playerAlternatingInput;
            // Add to the dictionary of Character controllers
            PlayerTrialDatas[playerModel.DeviceId] = new PlayerBellySlapData
            {
                PlayerController = playerController
            };
        }

        private void ValidInputPressed(int deviceId, IInputCapturing.InputTypes inputType)
        {
            // Cannot find the Player data for the device --> Do nothing
            if (!PlayerTrialDatas.TryGetValue(deviceId, out PlayerBellySlapData playerTrialData)) return;
            playerTrialData.AddSlapCount(inputType);
            UnityEngine.Debug.Log($"Player {playerTrialData.PlayerIndex} pressed alternated {inputType} count: {playerTrialData.SlapCount}");
        }
    }
}