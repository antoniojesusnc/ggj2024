using Player;

namespace Trials.Data
{
    public class PlayerTrialData
    {
        public PlayerController PlayerController;

        public int PlayerIndex => PlayerController.PlayerIndex;
    }
}
