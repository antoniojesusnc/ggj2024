using Clown.ClownInput;
using UnityEngine.InputSystem;
using CharacterController = Clown.CharacterController;

namespace Trials
{
    public class BellySlap : Trial<PlayerBellySlapData>
    {
        private PlayerInputManager _playerInputManager; 
        private ClownInputs _inputs;

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
            
            if (!PlayerTrialDatas.ContainsKey(deviceId))
            {
                // Generate the player index depending on the amount of Character controllers
                int playerIndex = PlayerTrialDatas.Count + 1;
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
                PlayerTrialDatas[deviceId] = new PlayerBellySlapData()
                {
                    CharacterController = characterController
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