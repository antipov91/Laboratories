using SharpCircuit;
using UnityEngine;

namespace Laboratories.Devices
{
    public class ResistorDevice : MonoDevice
    {
        public double Resistance
        {
            get { return resistor.resistance; }
            set { resistor.resistance = value; }
        }

        public float MinResistance { get { return minValue; } }
        public float MaxResistance { get { return maxValue; } }

        [SerializeField] private float initValue = 10f;
        [SerializeField] private float minValue = 0.1f;
        [SerializeField] private float maxValue = 1000f;

        private Resistor resistor;

        public override void Initialize()
        {
            resistor = new Resistor(initValue);
            deviceContext.Create(resistor, joints.Create("in"), joints.Create("out"));
        }
    }
}