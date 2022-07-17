using UnityEngine;

namespace Laboratories.Devices
{
    public class AmeterDevice : MonoDevice
    {
        [SerializeField] private float minValue = 0f;
        [SerializeField] private float maxValue = 10f;

        public override void Initialize()
        {
            var entity = deviceContext.Create(new SharpCircuit.Wire(), joints.Create("in"), joints.Create("out"));
            entity.ReplaceCurrentRSM(0f);
        }
    }
}