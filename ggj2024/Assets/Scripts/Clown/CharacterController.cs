using Clown.ClownInput;
using UnityEngine;

namespace Clown
{
    public class CharacterController : MonoBehaviour
    {
        public int PlayerIndex; 
        public IInputCapturing InputCapturing { get; set; }

        private void Start()
        {
            SubscribeEvents();
            StartCapturingInputs();
        }

        private void OnDestroy()
        {
            UnsubscribeEvents();
        }

        public void StartCapturingInputs()
        {
            InputCapturing.StartCapturing();
        }

        private void SubscribeEvents()
        {
            //InputCapturing.AlternatedInputPressed += ValidInputPressed;
        }

        private void UnsubscribeEvents()
        {
            //InputCapturing.AlternatedInputPressed -= ValidInputPressed;
        }
    }
}