using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GeneralUI : Singleton<GeneralUI>
{
    [SerializeField] public Image _soundIcon;
    [SerializeField] public Image _sfxIcon;
    [SerializeField] public Transform _pausePopup;
    [SerializeField] public Transform _areYouSurePopup;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    private void PauseGame()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            if (Application.platform != RuntimePlatform.WebGLPlayer)
            {
                ShowAreYouSureToClose();
            }
        }
        else
        {
            ShowPausePopup();
        }
    }

    private void ShowAreYouSureToClose()
    {
        _areYouSurePopup.gameObject.SetActive(true);
    }

    private void ShowPausePopup()
    {
        _pausePopup.gameObject.SetActive(true);
    }
}
