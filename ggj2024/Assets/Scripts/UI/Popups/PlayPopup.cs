using System;
using Player;
using UnityEngine;

namespace UI.Popups
{
    public class PlayPopup : MonoBehaviour
    {
        private JoinPlayer _joinPlayer;

        private void Start()
        {
            _joinPlayer = GetComponent<JoinPlayer>();
        }

        public void SetPlayerNumber(int playerNumber)
        {
            GameManager.Instance.SetPlayerModels(_joinPlayer.GetJoinedPlayerModels());
            GameManager.Instance.BeginGame();
        }
    }
}
