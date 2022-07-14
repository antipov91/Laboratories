using UnityEngine;
using UnityPlot;

namespace Laboratories.Devices
{
    public partial class OscilloscopeChannel
    {
        public float TimeScale
        {
            get { return _timeScale; }
            set
            {
                _timeScale = value;
                currentState.Redraw();
            }
        }

        public float TimeShift
        {
            get { return _timeShift; }
            set
            {
                _timeShift = value;
                currentState.Redraw();
            }
        }

        public float ValueScale
        {
            get { return _valueScale; }
            set
            {
                _valueScale = value;
                currentState.Redraw();
            }
        }

        public float ValueOffset
        {
            get { return _valueOffset; }
            set
            {
                _valueOffset = value;
                currentState.Redraw();
            }
        }
        
        public bool IsVisible
        {
            get { return series.IsVisible; }
            set { series.IsVisible = value;}
        }

        public bool IsRunning
        {
            get { return _isRunning; }
            set
            {
                if (_isRunning == value)
                    return;

                _isRunning = value;
                if (value)
                    currentState = runState;
                else
                    currentState = stopState;
            }
        }

        private float _timeScale;
        private float _timeShift;
        private float _valueScale;
        private float _valueOffset;
        private bool _isRunning;

        private Plot plot;
        private SeriesXY series;
        private SignalFrame[] signalFrames;

        private float timeLength;

        private OscilloscopeChannelState currentState;
        private OscilloscopeChannelState runState;
        private OscilloscopeChannelState stopState;
        
        public OscilloscopeChannel(Plot plot, Color color)
        {
            runState = new OscilloscopeChannelRunState(this);
            stopState = new OscilloscopeChannelStopState(this);
            currentState = runState;

            this.plot = plot;

            TimeScale = 1f / (10f * 8e-05f);
            TimeShift = 0f;
            ValueScale = 2f / 10f;
            ValueOffset = 0f;
            
            series = new SeriesXY("firstChannel", color, 2);

            plot.AddSeries(series);
        }

        public void Update(SignalFrame[] signalFrames)
        {
            currentState.Update(signalFrames);
        }
        
        public void Reset()
        {
            signalFrames = new SignalFrame[0];

            RecalculateTimeLenght();

            ReсalculatePoints(signalFrames);
            plot.Redraw();
        }

        private void ReсalculatePoints(SignalFrame[] frames)
        {
            series.Clear();
            float time = 0;
            float timeOffset = (1f - TimeScale * timeLength) / 2f + TimeShift;
            
            foreach (var frame in frames)
            {
                time += frame.deltaTime;
                series.AddPoint(new Vector2(TimeScale * time + timeOffset, ValueScale * frame.value + ValueOffset));
            }
        }

        private void RecalculateTimeLenght()
        {
            timeLength = 0;
            foreach (var frame in signalFrames)
                timeLength += frame.deltaTime;
        }
    }
}