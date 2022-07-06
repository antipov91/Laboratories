using JCMG.EntitasRedux;
using System.Collections.Generic;

namespace Laboratories.Circuits
{
    public class InitializeVoltageRSMSystem : ReactiveSystem<CircuitEntity>
    {
        public InitializeVoltageRSMSystem(Contexts contexts) : base(contexts.Circuit) { }

        protected override ICollector<CircuitEntity> GetTrigger(IContext<CircuitEntity> context)
        {
            return context.CreateCollector(CircuitMatcher.VoltageRSM.Added());
        }

        protected override bool Filter(CircuitEntity entity)
        {
            return entity.HasVoltageRSM && entity.HasElement;
        }

        protected override void Execute(List<CircuitEntity> entities)
        {
            foreach (var entity in entities)
                entity.ReplaceTemporaryCurrentRSM(0, 0, new Queue<ElectricalCircuit.SignalFrame>());
        }
    }
}