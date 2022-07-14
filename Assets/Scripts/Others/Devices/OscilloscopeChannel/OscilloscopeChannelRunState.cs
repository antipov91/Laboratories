namespace Laboratories.Devices
{
    public partial class OscilloscopeChannel
    {
        public class OscilloscopeChannelRunState : OscilloscopeChannelState
        {
            public OscilloscopeChannelRunState(OscilloscopeChannel context) : base(context) { }

            public override void Update(SignalFrame[] signalFrames)
            {
                context.signalFrames = (SignalFrame[])signalFrames.Clone();

                context.RecalculateTimeLenght();

                context.ReсalculatePoints(context.signalFrames);
                context.plot.Redraw();
            }

            public override void Redraw()
            {
                
            }
        }
    }
}