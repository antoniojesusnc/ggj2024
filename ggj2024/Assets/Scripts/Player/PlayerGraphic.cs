using System.Linq;
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
             _playerDataInput = _bellySlap.PlayerTrialDatas.Values.First(trialData => trialData.PlayerIndex == playerIndex);
             _playerDataInput.NewSlapCount += OnNewSlapCount;
        }

        private void OnNewSlapCount(IInputCapturing.InputTypes inputType)
        {
            SetAnimator(inputType == IInputCapturing.InputTypes.Primary
                            ? PlayerAnimation.der
                            : PlayerAnimation.izq);
            AudioManager.Instance.PlaySound(AudioTypes.palmada_1);
        }

        private void SetInitialAnimation()
        {
            SetAnimator(PlayerAnimation.strip);
            AudioManager.Instance.PlaySound(AudioTypes.ropa_rasgandose);
        }

        public void SetAnimator(PlayerAnimation animation)
        {
            _animator.Play(animation.ToString());
        }
    }
}
