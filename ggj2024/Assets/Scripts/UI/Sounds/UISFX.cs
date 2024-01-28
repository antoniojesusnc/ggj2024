using UnityEngine;
using UnityEngine.UI;

public class UISFX : MonoBehaviour
{
    [SerializeField] public Image _image;
    [SerializeField] public Sprite _enable;
    [SerializeField] public Sprite _disable;

    public void OnClick()
    {
        AudioManager.Instance.SetSFX(AudioManager.Instance.IsSFXEnabled);
        _image.sprite = AudioManager.Instance.IsSFXEnabled ? _enable : _disable;
    }
}
