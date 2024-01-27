using Player.PlayerInput;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerGraphic _playerGraphic;
        
        public int PlayerIndex;
        public IInputCapturing InputCapturing { get; set; }

        private void Start()
        {
            SubscribeEvents();
            StartCapturingInputs();
            _playerGraphic.Init(PlayerIndex);
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