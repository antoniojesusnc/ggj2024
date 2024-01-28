using Trials;
using UnityEngine;

public class KingController : MonoBehaviour
{
    public enum Animations
    {
        bigsmile,
        idle,
        midsmile,
        ready,
        smallsmile,
        smile,
    }

    private Animator _animator;
    
    public void Start()
    {
        _animator = GetComponent<Animator>();

        (BellySlap.Instance as BellySlap).OnPlayerConnected += OnPlayerConnected;
    }

    private void OnPlayerConnected()
    {
        SetAnimation(Animations.ready);
    }

    public void SetAnimation(Animations animation)
    {
        _animator.Play(animation.ToString());
    }
}
