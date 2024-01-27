using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "ScriptableObjects/SoundConfiguration", order = 1)]
public class AudioConfig : ScriptableObject
{ 
    [SerializeField]
    private List<SoundConfigInfo> _audios = new();
    
    public bool TryGetSoundConfig(AudioTypes audioType, out SoundConfigInfo soundConfigInfo)
    {
        soundConfigInfo = _audios.Find(audioInfo => audioInfo.AudioType == audioType);
        return soundConfigInfo != null;
    }

    [ContextMenu("Do Something")]
    public void GenerateOnePerAudioType()
    {
        for (AudioTypes i = AudioTypes.None; i < AudioTypes.Size; i++)
        {
            _audios.Add(new SoundConfigInfo(i, null, 0.5f, 0));
        }
    }
}

[System.Serializable]
public class SoundConfigInfo
{
    [field: SerializeField]
    public AudioTypes AudioType { get; private set; }
    
    [field: SerializeField]
    public AudioClip AudioClip { get; private set; }

    [field: SerializeField] 
    public float Volume { get; private set; } = 1;
    
    [field: SerializeField] 
    public float FadeOut { get; private set; }
    
    [field: SerializeField] 
    public float PitchVariance { get; private set; }

    public SoundConfigInfo(AudioTypes audioType, AudioClip audioClip, float volume, float fadeOut)
    {
        AudioType = audioType;
        AudioClip = audioClip;
        Volume = volume;
        FadeOut = fadeOut;
    }
}
