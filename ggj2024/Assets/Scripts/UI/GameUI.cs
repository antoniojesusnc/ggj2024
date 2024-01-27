using UnityEngine;

public class GameUI : MonoBehaviour
{
    [SerializeField] private UIBeginMessage _uiBegin;

    public void Init()
    {
        _uiBegin.Begin();
    }
    
}
