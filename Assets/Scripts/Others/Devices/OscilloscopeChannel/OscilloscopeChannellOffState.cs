namespace Laboratories.Devices
{
    public partial class OscilloscopeChannel
    {
        public class OscilloscopeChannellOffState : OscilloscopeChannelState
        {
            public OscilloscopeChannellOffState(OscilloscopeChannel context) : base(context) { }

            public override void Update(SignalFrame[] signalFrames)
            {
                
            }

            public override void Redraw()
            {

            }
        }
    }
}