using SharpCircuit;
using System.Collections.Generic;

namespace Laboratories.ElectricalCircuit
{
    public interface IElement
    {
        float Current { get; }
        float Voltage { get; }
        ICircuitElement CircuitElement { get; }
        void Reset();
        List<ICircuitJoint> GetJoints();
    }
}