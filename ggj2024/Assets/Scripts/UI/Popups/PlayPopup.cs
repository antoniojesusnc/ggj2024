using UnityEngine;

public class PlayPopup : MonoBehaviour
{
    public void SetPlayerNumber(int playerNumber)
    {
        GameManager.Instance.SetPlayerNumbers(playerNumber);
        GameManager.Instance.BeginGame();
    }
}
