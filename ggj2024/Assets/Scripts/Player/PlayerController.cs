using Player.PlayerInput;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerGraphic _playerGraphic;
        
        public int PlayerIndex;
        public IInputCapturing InputCapturing { get; set; }
        
        public PlayerModel PlayerModel { get; private set; }

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
            var gameuiInstance = GameUI.Instance;
            if (gameuiInstance != null)
            {
                gameuiInstance.FinishedCountdown -= OnFinishedCountdown;
            }
        }

        private void OnFinishedCountdown()
        {
            StartCapturingInputs();
        }

        public void SetPlayerModel(PlayerModel playerModel)
        {
            PlayerModel = playerModel;
            // Todo set image color, player number, etc.
        }
    }
}