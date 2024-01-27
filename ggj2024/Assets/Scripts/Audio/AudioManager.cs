using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    [SerializeField]
    private AudioConfig _audioConfig;

    private List<AudioManagerInfo> _audioSourcesInfo = new();

    public void PlaySound(AudioTypes audioType)
    {
        PlaySound(audioType, transform);
    }

    public void PlaySound(AudioTypes audioType, Transform parent)
    {
        if (!_audioConfig.TryGetSoundConfig(audioType, out var soundConfigInfo))
        {
            Debug.LogWarning("Audio not set");
            return;
        }

        PlaySoundInternal(soundConfigInfo, parent);
    }

    private void PlaySoundInternal(SoundConfigInfo soundConfigInfo, Transform parent)
    {
        AudioSource audioSource;
        if (parent == transform)
        {
            audioSource = GetAudioSource();
            _audioSourcesInfo.Add( new AudioManagerInfo(soundConfigInfo.AudioType, audioSource));
        }
        else
        {
            audioSource = GetNewAudioSource(parent);
            var managerInfo = new AudioManagerInfo(soundConfigInfo.AudioType, audioSource);
            _audioSourcesInfo.Add( managerInfo);
            StartCoroutine(DestroyAudioSourceAfterCo(managerInfo, soundConfigInfo.AudioClip.length + soundConfigInfo.FadeOut));
        }

        transform.position = transform.position + transform.forward;
        audioSource.clip = soundConfigInfo.AudioClip;
        audioSource.volume = soundConfigInfo.Volume;
        audioSource.Play();
        
    }

    private bool IsAlreadySound(SoundConfigInfo soundConfigInfo)
    {
        for (int i = 0; i < _audioSourcesInfo.Count; i++)
        {
            if (_audioSourcesInfo[i].AudioTypes == soundConfigInfo.AudioType &&
                _audioSourcesInfo[i].AudioSource.isPlaying)
            {
                return true;
            }
        }

        return false;
    }

    public void DestroyAudioSourceAfter(AudioTypes audioTypes, float delayToDestroy)
    {
        var audioSourcesInfo = _audioSourcesInfo.Find(audioSource => audioSource.AudioTypes == audioTypes);
        if (audioSourcesInfo != null)
        {
            StartCoroutine(DestroyAudioSourceAfterCo(audioSourcesInfo, delayToDestroy));
        }
    }
    
    private IEnumerator DestroyAudioSourceAfterCo(AudioManagerInfo audioSourcesInfo, float audioClipLength)
    {
        yield return new WaitForSeconds(audioClipLength);

        if (audioSourcesInfo == null)
        {
            yield break;
        }

        DestroyAudioSource(audioSourcesInfo);
    }

    private void DestroyAudioSource(AudioManagerInfo audioSourcesInfo)
    {
        if (audioSourcesInfo.AudioSource != null)
        {
            audioSourcesInfo.AudioSource.Stop();
            Destroy(audioSourcesInfo.AudioSource);
        }
        _audioSourcesInfo.Remove(audioSourcesInfo);
        OnDestroySound(audioSourcesInfo.AudioTypes);
    }

    private void OnDestroySound(AudioTypes audioTypes)
    {
        
    }

    private AudioSource GetAudioSource()
    {
        var audioSources = GetComponents<AudioSource>();
        for (int i = 0; i < audioSources.Length; i++)
        {
            if (!audioSources[i].isPlaying)
            {
                return audioSources[i];
            }
        }

        return GetNewAudioSource(transform);
    }

    private AudioSource GetNewAudioSource(Transform parent)
    {
        var audioSource = parent.gameObject.AddComponent<AudioSource>();

        if (parent != transform)
        {
        }
        return audioSource;

    }

    public void FinishAudio(AudioTypes audioToFade)
    {
        var audioSourcesInfo =_audioSourcesInfo.Find(audioInfo => audioInfo.AudioTypes == audioToFade);
        if (audioSourcesInfo == null)
        {
            return;
        }
        
        FadeOut(audioSourcesInfo);
    }

    private void FadeOut(AudioManagerInfo audioSourcesInfo)
    {
        _audioConfig.TryGetSoundConfig(audioSourcesInfo.AudioTypes, out var audioSourcesConfigInfo);

        if (audioSourcesConfigInfo.FadeOut > 0)
        {
            audioSourcesInfo.AudioSource.DOFade(0, audioSourcesConfigInfo.FadeOut);
            StartCoroutine(DestroyAudioSourceAfterCo(audioSourcesInfo, audioSourcesConfigInfo.FadeOut));
        }
        else
        {
            DestroyAudioSource(audioSourcesInfo);
        }
    }

    public float GetDuration(AudioTypes audioType)
    {
        if (!_audioConfig.TryGetSoundConfig(audioType, out var audioSourcesInfo))
        {
            return 0;
        }

        return audioSourcesInfo.AudioClip.length;
    }
}

public class AudioManagerInfo
{
    public AudioTypes AudioTypes { get; private set; }
    public AudioSource AudioSource { get; private set; }

    public AudioManagerInfo(AudioTypes audioTypes, AudioSource audioSource)
    {
        AudioTypes = audioTypes;
        AudioSource = audioSource;
    }
}
