using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class AudioManager : Singleton<AudioManager>
{
    [SerializeField] private AudioConfig _audioConfig;

    private List<AudioManagerInfo> _audioSourcesInfo = new();
    public bool IsSFXEnabled { get; private set; }
    public bool IsMusicEnable { get; private set; }

    public AudioSource PlaySound(AudioTypes audioType)
    {
        return PlaySound(audioType, transform);
    }

    public AudioSource PlaySound(AudioTypes audioType, Transform parent)
    {
        if (!_audioConfig.TryGetSoundConfig(audioType, out var soundConfigInfo))
        {
            Debug.LogWarning($"[AudioManager] Audio not set for {audioType}");
            return null;
        }

        return PlaySoundInternal(soundConfigInfo, parent);
    }

    private AudioSource PlaySoundInternal(SoundConfigInfo soundConfigInfo, Transform parent)
    {
        AudioSource audioSource;
        if (parent == transform)
        {
            audioSource = GetAudioSource();
            _audioSourcesInfo.Add(new AudioManagerInfo(soundConfigInfo.AudioType, audioSource));
        }
        else
        {
            audioSource = GetNewAudioSource(parent);
            var managerInfo = new AudioManagerInfo(soundConfigInfo.AudioType, audioSource);
            _audioSourcesInfo.Add(managerInfo);
            StartCoroutine(DestroyAudioSourceAfterCo(managerInfo,
                                                     soundConfigInfo.AudioClip.length + soundConfigInfo.FadeOut));
        }

        transform.position = transform.position + transform.forward;
        audioSource.clip = soundConfigInfo.AudioClip;
        audioSource.volume = soundConfigInfo.Volume;
        audioSource.pitch = soundConfigInfo.PitchVariance == 0
            ? 1f
            : Random.Range(1 - soundConfigInfo.PitchVariance, 1 + soundConfigInfo.PitchVariance);
        audioSource.Play();
        return audioSource;
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
        var audioSourcesInfo = _audioSourcesInfo.Find(audioInfo => audioInfo.AudioTypes == audioToFade);
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

    public void SetSFX(bool isSFXEnabled)
    {
        IsSFXEnabled = isSFXEnabled;

        CheckVolumens();
    }

    private void CheckVolumens()
    {
        for (int i = 0; i < _audioSourcesInfo.Count; i++)
        {
            if (!_audioSourcesInfo[i].AudioSource.isPlaying)
            {
                continue;
            }

            if (!_audioConfig.TryGetSoundConfig(_audioSourcesInfo[i].AudioTypes, out var configInfo))
            {
                continue;
            }
            
            
        }
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