using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlay : MonoBehaviour
{
    [SerializeField] private bool _playOnWake;
    [SerializeField] private AudioTypes _audioClip;
    
    void Start()
    {
        if (_playOnWake)
        {
            Play();
        }
    }

    public void Play()
    {
        AudioManager.Instance.PlaySound(_audioClip);
    }
}
