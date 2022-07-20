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

        [SerializeField] private double minWaveLength;
        [SerializeField] private double maxWaveLength;

        public override void Initialize()
        {
            WaveLength = 450e-9;
        }

        protected override void OnDeviceState(bool isActive)
        {
            OnStateChanged?.Invoke(isActive);
        }
    }
}