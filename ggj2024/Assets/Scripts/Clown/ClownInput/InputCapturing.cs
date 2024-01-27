using UnityEngine.InputSystem;

namespace Clown.ClownInput
{
    public abstract class InputCapturing : IInputCapturing
    {
        private readonly ClownInputs _inputs = new();

        public virtual void StartCapturing()
        {
            _inputs.Enable();
            _inputs.ClownP1.AlternatingPrimary.performed += PrimaryInputPressed;
            _inputs.ClownP1.AlternatingPrimary.performed += SecondaryInputPressed;
        }

        public virtual void StopCapturing()
        {
            _inputs.ClownP1.AlternatingPrimary.performed -= PrimaryInputPressed;
            _inputs.ClownP1.AlternatingPrimary.performed -= SecondaryInputPressed;
        }

        private void PrimaryInputPressed(InputAction.CallbackContext obj) =>
            OnInputPressed(IInputCapturing.InputTypes.Primary);

        private void SecondaryInputPressed(InputAction.CallbackContext obj) =>
            OnInputPressed(IInputCapturing.InputTypes.Secondary);
        
        protected abstract void OnInputPressed(IInputCapturing.InputTypes inputType);
    }
}
