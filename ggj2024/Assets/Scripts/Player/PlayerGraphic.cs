using System.Linq;
using Player.PlayerInput;
using Trials;
using Trials.Data;
using Unity.VisualScripting;
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
            idle,
            loose,
            tutorial,
            victoria,
            hi,
            idledressed,
        }

        private BellySlap _bellySlap;
        private PlayerBellySlapData _playerDataInput;
        private bool _levelStarted;

        public void Init(int playerIndex)
        {
            SetInitialAnimation();

            _bellySlap = BellySlap.Instance as BellySlap;
            _bellySlap.OnLevelBegin += OnLevelBegin;
            _bellySlap.OnBeginCountdown += OnBeginCountDown;
             _playerDataInput = _bellySlap.PlayerTrialDatas.Values.First(trialData => trialData.PlayerIndex == playerIndex);
             _playerDataInput.NewSlapCount += OnNewSlapCount;
        }

        private void OnBeginCountDown()
        {
            SetAnimator(PlayerAnimation.strip);
        }

        private void OnLevelBegin()
        {
            _levelStarted = true;
        }

        private void OnNewSlapCount(IInputCapturing.InputTypes inputType)
        {
            if (!_levelStarted)
            {
                SetAnimator(PlayerAnimation.hi);
                return;
            }
            
            SetAnimator(inputType == IInputCapturing.InputTypes.Primary
                            ? PlayerAnimation.der
                            : PlayerAnimation.izq);
            AudioManager.Instance.PlaySound(AudioTypes.palmada_1);
        }

        private void SetInitialAnimation()
        {
            SetAnimator(PlayerAnimation.idle);
            AudioManager.Instance.PlaySound(AudioTypes.ropa_rasgandose);
        }

        public void SetAnimator(PlayerAnimation animation)
        {
            _animator.Play(animation.ToString());
        }
    }
}
