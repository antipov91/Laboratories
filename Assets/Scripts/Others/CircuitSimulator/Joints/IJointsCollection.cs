namespace Laboratories.ElectricalCircuit
{
    public interface IJointsCollection
    {
        ICircuitJoint this[string name] { get; }
        ICircuitJoint Create(string name);
        bool Contains(string name);
    }
}