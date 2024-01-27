namespace Clown.ClownInput
{
    public interface IInputCapturing
    {
        public enum InputTypes
        {
            None = 0,
            Primary = 1,
            Secondary = 2
        }

        void StartCapturing();
        void StopCapturing();
    }
}