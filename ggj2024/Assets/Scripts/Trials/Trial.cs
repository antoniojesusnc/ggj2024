using System.Collections.Generic;
using Player;
using Player.PlayerInput;
using Trials.Data;
using UnityEngine.InputSystem;

namespace Trials
{
    public abstract class Trial<TTrialDataType> : Singleton<Trial<TTrialDataType>> where TTrialDataType : PlayerTrialData
    {
        public readonly Dictionary<int, TTrialDataType> PlayerTrialDatas = new();

        private PlayerInputManager _playerInputManager;
        private PlayerInputManager PlayerInputManager => _playerInputManager ??= GetComponent<PlayerInputManager>();
        
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
        public void JoinPlayer(PlayerModel playerModel)
        {
            // Join the player (instantiate its GameObject)
            PlayerInput playerInput = PlayerInputManager.JoinPlayer(playerIndex: playerModel.PlayerIndex, pairWithDevice: playerModel.Device);
            playerInput.gameObject.transform.SetParent(GameUI.Instance.PlayerContainer);
            // TODO: Place properly in the scene
            // Get the character controller of the new player and initialise its values
            PlayerController playerController = playerInput.GetComponent<PlayerController>();
            playerController.PlayerIndex = playerModel.PlayerIndex;
            // Instantiate and assign the Input capturing for this trial
            playerController.InputCapturing = InstantiateInputCapturing(playerModel.DeviceId);
            // Add to the dictionary of Character controllers
            PlayerTrialDatas[playerModel.DeviceId] = InstantiatePlayerTrialData(playerController) as TTrialDataType;
        }

        protected abstract IInputCapturing InstantiateInputCapturing(int deviceId);
        
        protected abstract PlayerTrialData InstantiatePlayerTrialData(PlayerController playerController);
    }
}
