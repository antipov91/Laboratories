using JCMG.EntitasRedux;
using Laboratories.Devices;

namespace Laboratories.Circuits
{
	public class UpdateScopeSignalSystem : IUpdateSystem
	{
		private readonly Contexts contexts;
		private IGroup<CircuitEntity> circuitEntities;

		public UpdateScopeSignalSystem(Contexts contexts)
        {
			this.contexts = contexts;
			circuitEntities = contexts.Circuit.GetGroup(CircuitMatcher.ScopeSignal);
        }

		public void Update()
		{
			foreach (var entity in circuitEntities.GetEntities())
            {
				if (entity.HasScopeSignalResult)
					entity.RemoveScopeSignalResult();

				entity.ScopeSignal.currentTime += contexts.Circuit.CircuitSimulatorEntity.DeltaTime.value;
				var signalFrame = new SignalFrame(entity.Element.instance.Voltage, contexts.Circuit.CircuitSimulatorEntity.DeltaTime.value);
				entity.ScopeSignal.queue.Enqueue(signalFrame);

				if (entity.ScopeSignal.currentTime > entity.ScopeSignal.timeWindow)
				{
					entity.ReplaceScopeSignalResult(entity.ScopeSignal.queue.ToArray());
					entity.ScopeSignal.queue.Clear();
					entity.ScopeSignal.currentTime = 0;
				}
			}
		}
	}
}