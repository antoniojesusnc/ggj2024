using System;
using System.Linq;
using Player;
using UnityEngine;
using UnityEngine.Serialization;

namespace UI.Popups
{
    public class PlayPopup : MonoBehaviour
    {
        [SerializeField]
        private GameObject playerPreviewPrefab;
        [SerializeField]
        private GameObject playerPreviewContainer;
        
        private JoinPlayer _joinPlayer;

        private void Start()
        {
            if (playerPreviewPrefab == null) Debug.LogError("playerPreviewPrefab not initialised.");
            if (playerPreviewContainer == null) Debug.LogError("playerPreviewContainer not initialised.");
            
            _joinPlayer = GetComponent<JoinPlayer>();
            SubscribeEvents();
        }

        private void OnDestroy()
        {
            UnsubscribeEvents();
        }

        public void BeginGame()
        {
            // Don't start the game if there are no players
            if (!_joinPlayer.GetJoinedPlayerModels().Any()) return;
            
            GameManager.Instance.SetPlayerModels(_joinPlayer.GetJoinedPlayerModels());
            GameManager.Instance.BeginGame();
        }

        private void SubscribeEvents()
        {
            _joinPlayer.PlayerJoined += OnPlayerJoined;
        }

        private void UnsubscribeEvents()
        {
            _joinPlayer.PlayerJoined -= OnPlayerJoined;
        }

        private void OnPlayerJoined(PlayerModel playerModel)
        {
            GameObject playerPreviewObject = Instantiate(playerPreviewPrefab, playerPreviewContainer.transform);
            playerPreviewObject.GetComponent<PlayerPreview>().SetPlayerModel(playerModel);
        }
    }
}
