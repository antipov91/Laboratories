using UnityEngine;
using SharpCircuit;
using TMPro;

namespace Laboratories.Devices
{
    public class FunctionGeneratorDevice : MonoDevice
    {
        public double Voltage
        {
            get { return voltageSource.maxVoltage; }
            set
            {
                voltageSource.maxVoltage = value;
                voltageLabel.text = string.Format("{0:D}", (int)voltageSource.maxVoltage);
            }
        }

        public double MinVoltage { get { return minVoltage; } }
        public double MaxVoltage { get { return maxVoltage; } }

        public double Frequency
        {
            get { return voltageSource.frequency; }
            set
            {
                voltageSource.frequency = value;
                frequencyLabel.text = string.Format("{0:D}", (int)voltageSource.frequency);
            }
        }

        public double MinFrequency { get { return minFrequency; } }
        public double MaxFrequency { get { return maxFrequency; } }

        public Voltage.WaveType Waveform
        {
            get { return voltageSource.waveform; }
            set { voltageSource.waveform = value; }
        }

        [Header("Settings")]
        [SerializeField] private double initVoltage;
        [SerializeField] private double minVoltage;
        [SerializeField] private double maxVoltage;

        [SerializeField] private double initFrequency;
        [SerializeField] private double minFrequency;
        [SerializeField] private double maxFrequency;

        [Header("Ui")]
        [SerializeField] private TextMeshPro voltageLabel;
        [SerializeField] private TextMeshPro frequencyLabel;

        private Voltage voltageSource;

        public override void InitializeCircuit()
        {
            voltageSource = new Voltage(SharpCircuit.Voltage.WaveType.AC);

            deviceContext.Create(voltageSource, joints.Create("in"), joints.Create("out"));
        }

        protected override void OnDeviceState(bool isActive)
        {
            base.OnDeviceState(isActive);

            if (isActive)
            {
                Voltage = initVoltage;
                Frequency = initFrequency;
                Waveform = SharpCircuit.Voltage.WaveType.AC;
            }

            voltageLabel.gameObject.SetActive(isActive);
            frequencyLabel.gameObject.SetActive(isActive);
        }
    }
}