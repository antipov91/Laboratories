using Laboratories.ElectricalCircuit;
using SharpCircuit;
using System.Collections.Generic;

namespace Laboratories.Devices
{
    public class DeviceContext
    {
        private readonly Contexts contexts;
        private readonly ICircuitSimulator circuitSimulator;
        private List<CircuitEntity> entities;

        public DeviceContext(Contexts contexts, ICircuitSimulator circuitSimulator)
        {
            this.contexts = contexts;
            this.circuitSimulator = circuitSimulator;
            entities = new List<CircuitEntity>();
        }

        public CircuitEntity Create(ICircuitElement circuitElement, params ICircuitJoint[] joints)
        {
            var element = circuitSimulator.Create(circuitElement, joints);
            var entity = contexts.Circuit.CreateEntity();
            entity.ReplaceElement(element);
            entities.Add(entity);
            return entity;
        }

        public void Release()
        {
            foreach (var entity in entities)
            {
                circuitSimulator.Remove(entity.Element.instance);
                entity.Destroy();
            }
        }
    }
}