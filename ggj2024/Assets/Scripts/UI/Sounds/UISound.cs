using UnityEngine;
using UnityEngine.UI;

public class UISound : MonoBehaviour
{
    [SerializeField] public Image _image;
    [SerializeField] public Sprite _enable;
    [SerializeField] public Sprite _disable;

    public void OnClick()
    {
        AudioManager.Instance.SetSFX(AudioManager.Instance.IsMusicEnable);
        _image.sprite = AudioManager.Instance.IsMusicEnable ? _enable : _disable;
    }
}
