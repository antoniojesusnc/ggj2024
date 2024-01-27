using System.Collections.Generic;
using Clown.ClownInput;
using UnityEngine.InputSystem;
using CharacterController = Clown.CharacterController;

namespace Trials
{
    public class BellySlap : Trial
    {
        private PlayerInputManager _playerInputManager; 
        private ClownInputs _inputs;
        
        Dictionary<int, CharacterController> _characterControllers = new();

        private void Start()
        {
            _playerInputManager = GetComponent<PlayerInputManager>();
            _inputs = new ClownInputs();
            _inputs.Enable();
            _inputs.ClownP1.Join.performed += JoinPressed;
        }

        private void JoinPressed(InputAction.CallbackContext obj)
        {
            int deviceId = obj.control.device.deviceId;
            
            if (!_characterControllers.ContainsKey(deviceId))
            {
                // Generate the player index depending on the amount of Character controllers
                int playerIndex = _characterControllers.Count;
                // Join the player (instantiate its GameObject)
                PlayerInput playerInput = _playerInputManager.JoinPlayer(playerIndex: playerIndex, pairWithDevice: obj.control.device);
                // Instantiate the Input capturing for this trial
                ClownAlternatingInput clownAlternatingInput = new ClownAlternatingInput(deviceId);
                clownAlternatingInput.AlternatedInputPressed += ValidInputPressed;
                // Get the character controller of the new player and initialise its values
                CharacterController characterController = playerInput.GetComponent<CharacterController>();
                characterController.PlayerIndex = playerIndex;
                characterController.InputCapturing = clownAlternatingInput;
                // Add to the dictionary of Character controllers
                _characterControllers[deviceId] = characterController;
            }
        }

        private void ValidInputPressed(IInputCapturing.InputTypes inputType)
        {
            UnityEngine.Debug.Log($"Alternate input: {inputType}");
        }
    }
}