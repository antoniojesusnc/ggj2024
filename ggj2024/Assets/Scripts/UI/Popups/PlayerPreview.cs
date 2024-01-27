using Player;
using UnityEngine;

namespace UI.Popups
{
    public class PlayerPreview : MonoBehaviour
    {
        private PlayerModel _playerModel;

        public void SetPlayerModel(PlayerModel playerModel)
        {
            _playerModel = playerModel;
            // Todo set image color, player number, etc.
        }
    }
}
