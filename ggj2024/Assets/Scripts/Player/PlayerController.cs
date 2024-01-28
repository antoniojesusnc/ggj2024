using Player.PlayerInput;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerGraphic _playerGraphic;
        
        public int PlayerIndex;
        public IInputCapturing InputCapturing { get; set; }
        
        private PlayerModel _playerModel;

        private void Start()
        {
            SubscribeEvents();
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
            GameUI.Instance.FinishedCountdown += OnFinishedCountdown;
        }

        private void UnsubscribeEvents()
        {
            GameUI.Instance.FinishedCountdown -= OnFinishedCountdown;
        }

        private void OnFinishedCountdown()
        {
            StartCapturingInputs();
        }

        public void SetPlayerModel(PlayerModel playerModel)
        {
            _playerModel = playerModel;
            // Todo set image color, player number, etc.
        }
    }
}