using System.Linq;
using Player;
using Trials;
using UnityEngine;

namespace UI
{
    public class JoinPlayerUiHandler : MonoBehaviour
    {
        [SerializeField]
        private GameObject playerPrefab;
        [SerializeField]
        private GameObject playerContainer;
        
        private JoinPlayer _joinPlayer;
        private JoinPlayer JoinPlayer => _joinPlayer ??= GetComponent<JoinPlayer>();

        private void Start()
        {
            if (playerPrefab == null) Debug.LogError("playerPreviewPrefab not initialised.");
            if (playerContainer == null) Debug.LogError("playerPreviewContainer not initialised.");
            
            SubscribeEvents();
        }

        private void OnDestroy()
        {
            UnsubscribeEvents();
        }

        private void SubscribeEvents()
        {
            JoinPlayer.PlayerJoined += OnPlayerJoined;
        }

        private void UnsubscribeEvents()
        {
            JoinPlayer.PlayerJoined -= OnPlayerJoined;
        }

        private void OnPlayerJoined(PlayerModel playerModel)
        {
            ((BellySlap)BellySlap.Instance).JoinPlayer(playerModel);
        }
    }
}
