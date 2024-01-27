using System;
using Clown.ClownInput;
using UnityEngine.Events;

namespace Trials
{
    public class BellySlap : Trial
    {
        private ClownAlternatingInput _inputCapturing;
        private new ClownAlternatingInput InputCapturing {
            get => _inputCapturing ??= base.InputCapturing as ClownAlternatingInput;
            set => base.InputCapturing = value;
        }

        private void Start()
        {
            InputCapturing = new ClownAlternatingInput();
            SubscribeEvents();
        }

        private void OnDestroy()
        {
            UnsubscribeEvents();
        }

        public void StartTrial()
        {
            InputCapturing.StartCapturing();
        }

        private void SubscribeEvents()
        {
            InputCapturing.AlternatedInputPressed += ValidInputPressed;
        }

        private void UnsubscribeEvents()
        {
            InputCapturing.AlternatedInputPressed -= ValidInputPressed;
        }

        private void ValidInputPressed(IInputCapturing.InputTypes inputType)
        {
            throw new System.NotImplementedException();
        }
    }
}