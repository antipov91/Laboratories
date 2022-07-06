using JCMG.EntitasRedux;
using System.Collections.Generic;

namespace Laboratories.Circuits
{
    public class InitializeCurrentRSMSystem : ReactiveSystem<CircuitEntity>
    {
        public InitializeCurrentRSMSystem(Contexts contexts) : base(contexts.Circuit) { }

        protected override ICollector<CircuitEntity> GetTrigger(IContext<CircuitEntity> context)
        {
            return context.CreateCollector(CircuitMatcher.CurrentRSM.Added());
        }

        protected override bool Filter(CircuitEntity entity)
        {
            return entity.HasCurrentRSM && entity.HasElement;
        }

        protected override void Execute(List<CircuitEntity> entities)
        {
            foreach (var entity in entities)
                entity.ReplaceTemporaryCurrentRSM(0, 0, new Queue<ElectricalCircuit.SignalFrame>());
        }
    }
}