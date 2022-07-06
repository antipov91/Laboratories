using System.Collections.Generic;
using SharpCircuit;

namespace Laboratories.ElectricalCircuit
{
    public class Element : IElement
    {
        public float Current { get { return (float)CircuitElement.getCurrent(); } }
        public float Voltage { get { return (float)CircuitElement.getVoltageDelta(); } }

        public ICircuitElement CircuitElement { get; }

        private List<ICircuitJoint> circuitJoints;

        public Element(ICircuitElement circuitElement, params ICircuitJoint[] joints)
        {
            CircuitElement = circuitElement;
            circuitJoints = new List<ICircuitJoint>(joints);
        }

        public List<ICircuitJoint> GetJoints()
        {
            return circuitJoints;
        }

        public void Reset()
        {
            CircuitElement.setCurrent(0, 0);
            CircuitElement.reset();
        }
    }
}