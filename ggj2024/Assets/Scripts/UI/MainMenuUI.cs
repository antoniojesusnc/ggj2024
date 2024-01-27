using UnityEngine;

public class MainMenuUI : Singleton<MainMenuUI>
{
    [SerializeField] public GameObject _playpopup;
    [SerializeField] public GameObject _creditPopup;
    
    public void OnOpen()
    {
        _playpopup.gameObject.SetActive(true);
    }
    
    public void OnClickInCredits()
    {
        _creditPopup.gameObject.SetActive(true);
    }

    public void OnClickInExit()
    {
        Application.Quit();
    }
}
