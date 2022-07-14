namespace Laboratories.Devices
{
    public class WireDevice : MonoDevice
    {
        public override void InitializeCircuit()
        {
            deviceContext.Create(new SharpCircuit.Wire(), entity.InitializeWire.inJoint, entity.InitializeWire.outJoint);
            entity.RemoveInitializeWire();
        }
    }
}