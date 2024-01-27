using Player;
using Player.PlayerInput;
using Player.PlayerInput;
using Trials.Data;
using UnityEngine.InputSystem;

namespace Trials
{
    public class BellySlap : Trial<PlayerBellySlapData>
    {
        private PlayerInputManager _playerInputManager; 
        private PlayerInputs _inputs;

        private void Start()
        {
            _playerInputManager = GetComponent<PlayerInputManager>();
            _inputs = new PlayerInputs();
            _inputs.Enable();
            _inputs.ClownP1.Join.performed += JoinPressed;
        }

        private void JoinPressed(InputAction.CallbackContext obj)
        {
            int deviceId = obj.control.device.deviceId;
            
            if (!PlayerTrialDatas.ContainsKey(deviceId))
            {
                // Generate the player index depending on the amount of Character controllers
                int playerIndex = PlayerTrialDatas.Count + 1;
                // Join the player (instantiate its GameObject)
                PlayerInput playerInput = _playerInputManager.JoinPlayer(playerIndex: playerIndex, pairWithDevice: obj.control.device);
                // Instantiate the Input capturing for this trial
                PlayerAlternatingInput playerAlternatingInput = new PlayerAlternatingInput(deviceId);
                playerAlternatingInput.AlternatedInputPressed += ValidInputPressed;
                // Get the character controller of the new player and initialise its values
                PlayerController playerController = playerInput.GetComponent<PlayerController>();
                playerController.PlayerIndex = playerIndex;
                playerController.InputCapturing = playerAlternatingInput;
                // Add to the dictionary of Character controllers
                PlayerTrialDatas[deviceId] = new PlayerBellySlapData()
                {
                    PlayerController = playerController
                };
            }
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