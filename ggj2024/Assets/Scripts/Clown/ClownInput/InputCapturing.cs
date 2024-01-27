using UnityEngine.InputSystem;

namespace Clown.ClownInput
{
    public abstract class InputCapturing : IInputCapturing
    {
        private readonly ClownInputs _inputs = new();
        private readonly int _deviceId;

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

        protected abstract void OnInputPressed(IInputCapturing.InputTypes inputType);
    }
}
