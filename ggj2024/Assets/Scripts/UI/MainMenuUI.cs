using System;
using DG.Tweening;
using UnityEngine;

public class MainMenuUI : Singleton<MainMenuUI>
{
    [SerializeField] public GameObject _playpopup;
    [SerializeField] public GameObject _exitButton;


    void Start()
    {

        AudioManager.Instance.PlaySound(AudioTypes.musica_main_menu_divertida_y_tranquila);
        
        _exitButton.gameObject.SetActive(Application.platform == RuntimePlatform.WindowsEditor ||
                                         Application.platform != RuntimePlatform.WebGLPlayer);
    }
    
    public void BeginGame()
    {
        GameManager.Instance.BeginGame();
        AudioManager.Instance.DestroyAudioSourceAfter(AudioTypes.musica_main_menu_divertida_y_tranquila, 0.5f);
    }
    
    public void OnClickInExit()
    {
        GeneralUI.Instance.ShowAreYouSureToClose();
    }

    private void OnDisable()
    {
        
    }
}
