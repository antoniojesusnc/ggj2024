using System;
using UnityEngine.Events;

namespace Clown.ClownInput
{
    public class ClownAlternatingInput : InputCapturing
    {
        // Events
        public Action<int, IInputCapturing.InputTypes> InvalidInputPressed;
        public Action<int, IInputCapturing.InputTypes> AlternatedInputPressed;
    
        private IInputCapturing.InputTypes _lastInputTypePressed = IInputCapturing.InputTypes.None;

        public ClownAlternatingInput(int deviceId) : base(deviceId) { }

        protected override void OnInputPressed(IInputCapturing.InputTypes inputType)
        {
            base.OnInputPressed(inputType);
            
            // The pressed input is the same as the las one --> Trigger invalid
            if (_lastInputTypePressed == inputType)
            {
                InvalidInputPressed?.Invoke(_deviceId, inputType);
            }
            // The pressed input is different to the las one --> Trigger alternated
            else
            {
                _lastInputTypePressed = inputType;
                AlternatedInputPressed?.Invoke(_deviceId, inputType);
            }
        }
    }
}
