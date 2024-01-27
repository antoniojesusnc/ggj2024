using System;
using UnityEngine.InputSystem;

namespace Player.PlayerInput
{
    public abstract class InputCapturing : IInputCapturing
    {
        // Events
        public event Action<int, IInputCapturing.InputTypes> InputPressed;
        
        private readonly PlayerInputs _inputs = new();
        protected readonly int _deviceId;

        public InputCapturing(int deviceId)
        {
            _deviceId = deviceId;
        }

        public virtual void StartCapturing()
        {
            _inputs.Enable();
            _inputs.ClownP1.AlternatingPrimary.performed += PrimaryInputPressed;
            _inputs.ClownP1.AlternatingSecondary.performed += SecondaryInputPressed;
        }

        public virtual void StopCapturing()
        {
            _inputs.ClownP1.AlternatingPrimary.performed -= PrimaryInputPressed;
            _inputs.ClownP1.AlternatingSecondary.performed -= SecondaryInputPressed;
        }

        private void PrimaryInputPressed(InputAction.CallbackContext obj)
        {
            if (obj.control.device.deviceId == _deviceId)
                OnInputPressed(IInputCapturing.InputTypes.Primary);
        }

        private void SecondaryInputPressed(InputAction.CallbackContext obj)
        {
            if (obj.control.device.deviceId == _deviceId)
                OnInputPressed(IInputCapturing.InputTypes.Secondary);
        }


        protected virtual void OnInputPressed(IInputCapturing.InputTypes inputType)
        {
            InputPressed?.Invoke(_deviceId, inputType);
        }
    }
}
