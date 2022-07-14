namespace Laboratories.Devices
{
    public partial class OscilloscopeChannel
    {
        public class OscilloscopeChannelStopState : OscilloscopeChannelState
        {
            public OscilloscopeChannelStopState(OscilloscopeChannel context) : base(context) { }

            public override void Update(SignalFrame[] signalFrames)
            {
                
            }

            public override void Redraw()
            {
                context.ReсalculatePoints(context.signalFrames);
                context.plot.Redraw();
            }
        }
    }
}