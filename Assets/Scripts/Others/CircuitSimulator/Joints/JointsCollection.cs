using System.Collections.Generic;

namespace Laboratories.ElectricalCircuit
{
    public class JointsCollection : IJointsCollection
    {
        public ICircuitJoint this[string name]
        {
            get { return joints[name]; }
        }

        private Dictionary<string, ICircuitJoint> joints;

        public JointsCollection()
        {
            joints = new Dictionary<string, ICircuitJoint>();
        }

        public ICircuitJoint Create(string name)
        {
            var joint = new CircuitJoint();
            joints.Add(name, joint);
            return joint;
        }

        public bool Contains(string name)
        {
            return joints.ContainsKey(name);
        }
    }
}