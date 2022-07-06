using SharpCircuit;

namespace Laboratories.ElectricalCircuit
{
    public interface ICircuitSimulator
    {
        int CountStep { get; set; }
        double TimeStep { get; set; }

        IElement Create(ICircuitElement circuitElement, params ICircuitJoint[] joints);
        IElement Create(ICircuitElement circuitElement, params int[] idJoints);
        void Remove(IElement element);
        void RemoveConnectedWithJoint(ICircuitJoint joint);
        void Process();
        void Rebuild();
        void Clear();
    }
}