using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

namespace Player
{
    public class JoinPlayer : MonoBehaviour
    {
        // Events
        public event Action<PlayerModel> PlayerJoined;

        public int PlayerCount => _playerModels.Count;

        [SerializeField]
        private int maxPlayers = 4;
        
        private readonly Dictionary<int, PlayerModel> _playerModels = new();
        private PlayerInputs _inputs;
    
        // Start is called before the first frame update
        private void Start()
        {
            _inputs = new PlayerInputs();
            _inputs.Enable();
            _inputs.ClownP1.Join.performed += JoinPressed;
        }

        private void JoinPressed(InputAction.CallbackContext obj)
        {
            // Don't allow to join more players than allowed
            if (PlayerCount >= maxPlayers) return;
            
            // Get the controller ID
            int deviceId = obj.control.device.deviceId;
            // The device has already joined --> Do nothing
            if (_playerModels.ContainsKey(deviceId)) return;
        
            // Generate the player index depending on the amount of Character controllers
            int playerIndex = _playerModels.Count + 1;
            // Add to the dictionary of Character controllers
            _playerModels[deviceId] = new PlayerModel
            {
                PlayerIndex = playerIndex,
                Device = obj.control.device,
                //Colour = // TODO: Generate colour 
            };
            // Trigger Player joined event
            PlayerJoined?.Invoke(_playerModels[deviceId]);
        }

        /// <summary>
        /// Returns the list of PlayerModel objects which have joined.
        /// </summary>
        /// <returns>List of PlayerModel objects.</returns>
        public IEnumerable<PlayerModel> GetJoinedPlayerModels() =>
            _playerModels.Values;
    }
}
