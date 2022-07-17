using SharpCircuit;
using UnityEngine;

namespace Laboratories.Devices
{
    public class CoilDevice : MonoDevice
    {
        public double Inductance
        {
            get { return inductorElm.inductance; }
            set { inductorElm.inductance = value; }
        }

        public float MinInductance { get { return minValue; } }
        public float MaxInductance { get { return maxValue; } }

        [SerializeField] private float initValue = 0.1f;
        [SerializeField] private float minValue = 0.01f;
        [SerializeField] private float maxValue = 1f;

        private InductorElm inductorElm;

        public override void Initialize()
        {
            inductorElm = new InductorElm(initValue);
            deviceContext.Create(inductorElm, joints.Create("in"), joints.Create("out"));
        }
    }
}