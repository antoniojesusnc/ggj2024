using Trials;
using UnityEngine;

public class KingController : Singleton<KingController>
{
    public enum Animations
    {
        bigsmile,
        idle,
        midsmile,
        ready,
        smallsmile,
        smile,
        saveReady
    }

    private Animator _animator;
    private BellySlap _bellySlap;

    [SerializeField] private KingConfig _config;

    public void Start()
    {
        _animator = GetComponent<Animator>();

        _bellySlap = (BellySlap.Instance as BellySlap);
        _bellySlap.OnPlayerConnected += OnPlayerConnected;
        _bellySlap.OnBeginCountdown += OnBeginCountDown;
    }

    private void OnBeginCountDown()
    {
        SetAnimation(Animations.saveReady);
    }

    private void OnPlayerConnected()
    {
        SetAnimation(Animations.ready);
    }

    public void SetAnimation(Animations animation)
    {
        _animator.Play(animation.ToString());
    }

    public void Laugh(int slapCount)
    {
        var animation = _config.GetLaugh(slapCount);
        if (animation == Animations.smallsmile)
        {
            _animator.SetInteger("smile", 0);
        }
        else if (animation == Animations.midsmile)
        {
            _animator.SetInteger("smile",1);
        }
        else if (animation == Animations.bigsmile)
        {
            _animator.SetInteger("smile",2);
        }

        SetAnimation(Animations.smile);
    }
}