using UnityEngine;

public class GameUI : MonoBehaviour
{
    [SerializeField] private UIBeginMessage _uiBegin;

    public void Start()
    {
        BeginGameplay();
    }

    private void BeginGameplay()
    {
        _uiBegin.Begin();
        _uiBegin.Finished += FinishedCountDown;
    }

    private void FinishedCountDown()
    {
        GameManager.Instance.InitGamePlay();
    }
}
