using System.Linq;
using DG.DemiLib;
using Player.PlayerInput;
using Trials;
using Trials.Data;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    public class PlayerGraphic : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        
        [SerializeField] private Image _clothes;

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
            _bellySlap.OnLevelFinish += OnLevelFinish;
             _playerDataInput = _bellySlap.PlayerTrialDatas.Values.First(trialData => trialData.PlayerIndex == playerIndex);
             _playerDataInput.NewSlapCount += OnNewSlapCount;

             SetColor();
        }

        private void SetColor()
        {
            _clothes.color = _playerDataInput.PlayerController.PlayerModel.Color;
        }

        private void OnLevelFinish()
        {
            _playerDataInput.NewSlapCount -= OnNewSlapCount;
            SetAnimator(PlayerAnimation.idle);
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
                --_playerDataInput.SlapCount;
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
            SetAnimator(PlayerAnimation.idledressed);
        }

        public void SetAnimator(PlayerAnimation animation)
        {
            _animator.Play(animation.ToString());
        }
    }
}
