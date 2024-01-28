using UnityEngine;

public class PausePopup : MonoBehaviour
{
    private void OnEnable()
    {
        Time.timeScale = 0;
    }
    
    private void OnDisable()
    {
        Time.timeScale = 1;
    }

    public void ClickInContinue()
    {
        gameObject.SetActive(false);
    }

    public void ClickInRestart()
    {
        GameManager.Instance.BeginGame();
        gameObject.SetActive(false);
    }
    
    public void ClickInExit()
    {
        GameManager.Instance.MainMenu();
        gameObject.SetActive(false);
    }
}


