namespace Laboratories.Devices
{
    public struct SignalFrame
    {
        public float value;
        public float deltaTime;

        public SignalFrame(float value, float deltaTime)
        {
            this.value = value;
            this.deltaTime = deltaTime;
        }
    }
}