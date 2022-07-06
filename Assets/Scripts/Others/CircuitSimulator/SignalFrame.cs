namespace Laboratories.ElectricalCircuit
{
    public class SignalFrame
    {
        public float Value { get; set; }
        public float DeltaTime { get; set; }

        public SignalFrame(float value, float deltaTime)
        {
            Value = value;
            DeltaTime = deltaTime;
        }
    }
}