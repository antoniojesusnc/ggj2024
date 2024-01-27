using UnityEngine;

public class GameUI : MonoBehaviour
{
    [SerializeField] private UIBeginMessage _uiBegin;
    [SerializeField] private UIEndLevel _uiEndLevel;

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

    private void OnFinishGameplay()
    {
        _uiEndLevel.Init();
        //_uiEndLevel.Finished += 
        
    }
}
