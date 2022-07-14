using UnityEngine;
using SharpCircuit;
using TMPro;

namespace Laboratories.Devices
{
    public class ACPowerDevice : MonoDevice
    {
        public double Voltage
        {
            get { return voltageSource.rsmVoltage; }
            set 
            { 
                voltageSource.rsmVoltage = value;
                label.text = string.Format("{0:D}", (int)voltageSource.rsmVoltage);
            }
        }

        public double MinVoltage { get { return minVoltage; } }
        public double MaxVoltage { get { return maxVoltage; } }


        [Header("Additional resistance")]
        [SerializeField] private float resistance = 1f;

        [Header("Voltage settings")]
        [SerializeField] private float initVoltage = 10f;
        [SerializeField] private float minVoltage = 1f;
        [SerializeField] private float maxVoltage = 220f;

        [Header("Ui")]
        [SerializeField] private TextMeshPro label;

        private ACVoltageSource voltageSource;
        private SwitchSPST switchSPST;

        public override void InitializeCircuit()
        {
            voltageSource = new ACVoltageSource();
            voltageSource.rsmVoltage = initVoltage;
            voltageSource.frequency = 50f;

            switchSPST = new SwitchSPST();

            deviceContext.Create(voltageSource, joints.Create("in"), joints.Create("middleIn"));
            deviceContext.Create(switchSPST, joints["middleIn"], joints.Create("middleOut"));
            deviceContext.Create(new Resistor(resistance), joints["middleOut"], joints.Create("out"));
        }

        protected override void OnDeviceState(bool isActive)
        {
            if (isActive)
                switchSPST.toggleOn();
            else
                switchSPST.toggleOff();

            label.text = isActive ? string.Format("{0:D}", (int)voltageSource.rsmVoltage) : "";
        }
    }
}