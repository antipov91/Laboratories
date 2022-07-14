using UnityEngine;
using SharpCircuit;

namespace Laboratories.Devices
{
    public class CapacitorDevice : MonoDevice
    {
        public double Capistance
        {
            get { return capacitor.capacitance; }
            set { capacitor.capacitance = value; }
        }

        public float MinCapistance { get { return minValue; } }
        public float MaxCapistance { get { return maxValue; } }

        [SerializeField] private float initValue = 1f;
        [SerializeField] private float minValue = 0.1f;
        [SerializeField] private float maxValue = 100f;

        private CapacitorElm capacitor;

        public override void InitializeCircuit()
        {
            capacitor = new CapacitorElm(initValue);
            deviceContext.Create(capacitor, joints.Create("in"), joints.Create("out"));
        }
    }
}