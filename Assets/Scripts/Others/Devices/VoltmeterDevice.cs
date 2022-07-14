using SharpCircuit;
using UnityEngine;

namespace Laboratories.Devices
{
    public class VoltmeterDevice : MonoDevice
    {
        [SerializeField] private float minValue = 0f;
        [SerializeField] private float maxValue = 220f;

        public override void InitializeCircuit()
        {
            var entity = deviceContext.Create(new Resistor(1000000), joints.Create("in"), joints.Create("out"));
            entity.ReplaceVoltageRSM(0f);
        }
    }
}