using UnityEngine;

namespace Player
{
    public class PlayerImages : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        public enum PlayerAnimation
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

        public void SetAnimator(PlayerAnimation animation)
        {
            _animator.Play(animation.ToString());
        }
    }
}
