using DG.Tweening;
using UnityEngine;

public class Floating : MonoBehaviour
{
    [SerializeField] private float _duration;
    [SerializeField] private int _offset;
    [SerializeField] private Ease _ease;

    private Tween _tween;
    void Start()
    {
        Anim();
    }

    private void Anim()
    {
        // 6 is the pixel size factor. This should be moved to a config value
        _tween = GetComponent<RectTransform>().DOAnchorPosY(-_offset * 6, _duration).SetEase(_ease).SetLoops(-1, LoopType.Yoyo);
    }

    private void OnDestroy()
    {
        _tween?.Kill();
    }
}
