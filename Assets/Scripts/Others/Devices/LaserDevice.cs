using System;
using UnityEngine;
using UnityEngine.UI;

namespace Laboratories.Devices
{
    public class LaserDevice : MonoDevice
    {
        public Action<double> OnWaveLengthChanged;
        public Action<bool> OnStateChanged;

        private double waveLength;
        public double WaveLength 
        {
            get { return waveLength; } 
            set
            {
                waveLength = value;
                OnWaveLengthChanged?.Invoke(value);
            }
        }

        public double MinWaveLength { get { return minWaveLength; } }
        public double MaxWaveLength { get { return maxWaveLength; } }

        [SerializeField] private double initWaveLength;
        [SerializeField] private double minWaveLength;
        [SerializeField] private double maxWaveLength;

        private Gradient visibleLightGradient;

        private double minLength = 380e-9;
        private double maxLength = 780e-9;

        public override void Initialize()
        {
            WaveLength = initWaveLength;

            visibleLightGradient = new Gradient();


            var colorKeys = new GradientColorKey[8];

            colorKeys[0].color = new Color(105f / 255f, 0f, 198f / 255f);
            colorKeys[0].time = WaveLengthToRangeValue(415e-9);

            colorKeys[1].color = new Color(0f, 77f / 255f, 255f / 255f);
            colorKeys[1].time = WaveLengthToRangeValue(465e-9);

            colorKeys[2].color = new Color(0f, 191f / 255f, 255f / 255f);
            colorKeys[2].time = WaveLengthToRangeValue(495e-9);

            colorKeys[3].color = new Color(0f, 214f / 255f, 120f / 255f);
            colorKeys[3].time = WaveLengthToRangeValue(530e-9);

            colorKeys[4].color = new Color(153f / 255f, 255f / 255f, 153f / 255f);
            colorKeys[4].time = WaveLengthToRangeValue(560e-9);

            colorKeys[5].color = new Color(255f / 255f, 255f / 255f, 0f);
            colorKeys[5].time = WaveLengthToRangeValue(580e-9);

            colorKeys[6].color = new Color(255f / 255f, 102f / 255f, 0f);
            colorKeys[6].time = WaveLengthToRangeValue(610e-9);

            colorKeys[7].color = new Color(255f / 255f, 0f, 0f);
            colorKeys[7].time = WaveLengthToRangeValue(705e-9);

            visibleLightGradient.colorKeys = colorKeys;
        }

        public Color GetColor()
        {
            return WaveLengthToColor(WaveLength);
        }

        private float WaveLengthToRangeValue(double waveLength)
        {
            return (float)((waveLength - minLength) / (maxLength - minLength));
        }

        private Color WaveLengthToColor(double waveLength)
        {
            return visibleLightGradient.Evaluate(WaveLengthToRangeValue(waveLength));
        }

        protected override void OnDeviceState(bool isActive)
        {
            OnStateChanged?.Invoke(isActive);
        }
    }
}