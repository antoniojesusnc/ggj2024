using System;
using Player.PlayerInput;

namespace Trials.Data
{
    public class PlayerBellySlapData : PlayerTrialData
    {
        public int SlapCount;

        public event Action<IInputCapturing.InputTypes> NewSlapCount;
        
        public void AddSlapCount(IInputCapturing.InputTypes inputType)
        {
            ++SlapCount;
            NewSlapCount?.Invoke(inputType);
        }
    }
}
