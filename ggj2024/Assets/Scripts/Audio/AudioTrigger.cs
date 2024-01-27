using System;
using Unity.VisualScripting;
using UnityEngine;

public class AudioTrigger : MonoBehaviour
{
    public enum EAudioTrigger
    {
        Enter,
        Exit,
        Stay
    }

    [SerializeField] 
    private EAudioTrigger _when;
    [SerializeField] 
    private AudioTypes _sound;
    [SerializeField] 
    private bool _stopWhenLeave;
    [SerializeField] 
    private Transform _soundOrigin;

    public void OnTriggerEnter(Collider other)
    {
        if (_when == EAudioTrigger.Enter)
        {
            AudioManager.Instance.PlaySound(_sound, _soundOrigin);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (_when == EAudioTrigger.Stay)
        {
            AudioManager.Instance.PlaySound(_sound, _soundOrigin);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (_when == EAudioTrigger.Exit)
        {
            AudioManager.Instance.PlaySound(_sound, _soundOrigin);
        }

        if (_stopWhenLeave)
        {
            AudioManager.Instance.FinishAudio(_sound);
        }
    }
}
