using UnityEngine;

public class ClownImages : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public enum ClownAnimation
    {
        lento,
        izquierda,
        derecha,
        strip,
        idle
    }
    
    private void Start()
    {
        
    }

    public void SetAnimator(ClownAnimation animation)
    {
        _animator.Play(animation.ToString());
    }
}
