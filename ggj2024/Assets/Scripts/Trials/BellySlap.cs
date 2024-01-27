using System.Collections.Generic;
using Player;
using Player.PlayerInput;
using Trials.Data;
using UnityEngine.InputSystem;

namespace Trials
{
    public class BellySlap : Trial<PlayerBellySlapData>
    {
        private PlayerInputManager _playerInputManager;

        private void Start()
        {
            _playerInputManager = GetComponent<PlayerInputManager>();
        }

        /// <summary>
        /// Joins a list of players to the game.
        /// </summary>
        /// <param name="playerModels"></param>
        private void JoinPlayers(IEnumerable<PlayerModel> playerModels)
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
            PlayerInput playerInput = _playerInputManager.JoinPlayer(playerIndex: playerModel.PlayerIndex, pairWithDevice: playerModel.Device);
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
            
            ++playerTrialData.SlapCount;
            UnityEngine.Debug.Log($"Player {playerTrialData.PlayerIndex} pressed alternated {inputType} count: {playerTrialData.SlapCount}");
        }
    }
}