using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerModel
    {
        public int PlayerIndex;
        public InputDevice Device;
        public int DeviceId => Device.deviceId;
        public Color Color;
    }
}
