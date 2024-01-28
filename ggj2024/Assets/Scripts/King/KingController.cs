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
        
    }
}
