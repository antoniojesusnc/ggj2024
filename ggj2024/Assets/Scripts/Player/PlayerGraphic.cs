using Player.PlayerInput;
using Trials;
using Trials.Data;
using UnityEngine;

namespace Player
{
    public class PlayerGraphic : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        public enum PlayerAnimation
        {
            lento,
            izq,
            der,
            strip,
            idle
        }

        private BellySlap _bellySlap;
        private PlayerBellySlapData _playerDataInput;

        public void Init(int playerIndex)
        {
            SetInitialAnimation();

            _bellySlap = BellySlap.Instance as BellySlap;
             _playerDataInput = _bellySlap.PlayerTrialDatas[playerIndex];
             _playerDataInput.NewSlapCount += OnNewSlapCount;
        }

        private void OnNewSlapCount(IInputCapturing.InputTypes inputType)
        {
            SetAnimator(inputType == IInputCapturing.InputTypes.Primary
                            ? PlayerAnimation.der
                            : PlayerAnimation.izq);
        }

        private void SetInitialAnimation()
        {
            SetAnimator(PlayerAnimation.strip);
        }

        public void SetAnimator(PlayerAnimation animation)
        {
            _animator.Play(animation.ToString());
        }
    }
}
