namespace Laboratories.Devices
{
    public partial class OscilloscopeChannel
    {
        public abstract class OscilloscopeChannelState : State<OscilloscopeChannel>
        {
            public OscilloscopeChannelState(OscilloscopeChannel context) : base(context) { }

            public abstract void Update(SignalFrame[] signalFrames);

            public abstract void Redraw();
        }
    }
}