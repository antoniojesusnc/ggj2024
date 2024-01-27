using UnityEngine;

public class MainMenuUI : Singleton<MainMenuUI>
{
    [SerializeField] public GameObject _playpopup;
    [SerializeField] public GameObject _exitButton;
    
    public void OnOpen()
    {
        _playpopup.gameObject.SetActive(true);

        _exitButton.gameObject.SetActive(Application.platform == RuntimePlatform.WindowsEditor ||
                                         Application.platform != RuntimePlatform.WebGLPlayer);
    }
    
    public void OnClickInExit()
    {
        GeneralUI.Instance.ShowAreYouSureToClose();
    }
}
