using System;
using UnityEngine.Events;

namespace Clown.ClownInput
{
    public class ClownAlternatingInput : InputCapturing
    {
        // Events
        public Action<IInputCapturing.InputTypes> InputPressed;
        public Action<IInputCapturing.InputTypes> AlternatedInputPressed;
    
        private IInputCapturing.InputTypes _lastInputTypePressed = IInputCapturing.InputTypes.None;

        public ClownAlternatingInput(int deviceId) : base(deviceId) { }

        protected override void OnInputPressed(IInputCapturing.InputTypes inputType)
        {
            InputPressed?.Invoke(inputType);

            // The pressed input is different to the las one --> Trigger alternated
            if (_lastInputTypePressed != inputType)
            {
                _lastInputTypePressed = inputType;
                AlternatedInputPressed?.Invoke(inputType);
            }
        }
    }
}
