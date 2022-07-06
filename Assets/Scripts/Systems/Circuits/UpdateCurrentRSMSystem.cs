using JCMG.EntitasRedux;
using Laboratories.ElectricalCircuit;
using UnityEngine;

namespace Laboratories.Circuits
{
	public class UpdateCurrentRSMSystem : IUpdateSystem
	{
        private readonly Contexts contexts;
        private readonly IGroup<CircuitEntity> entitiesGroup;

        public UpdateCurrentRSMSystem(Contexts contexts)
        {
            this.contexts = contexts;
            entitiesGroup = contexts.Circuit.GetGroup(CircuitMatcher.AllOf(CircuitMatcher.CurrentRSM,
                                                                           CircuitMatcher.TemporaryCurrentRSM,
                                                                           CircuitMatcher.Element));
        }

        public void Update()
        {
            foreach (var entity in entitiesGroup.GetEntities())
            {
                var time = entity.TemporaryCurrentRSM.time;
                var totalSquare = entity.TemporaryCurrentRSM.totalSquare;
                var frames = entity.TemporaryCurrentRSM.frames;

                var deltaTime = contexts.Circuit.CircuitSimulatorEntity.DeltaTime.value;
                var square = Mathf.Pow(entity.Element.instance.Current, 2) * deltaTime;

                time += deltaTime;
                totalSquare += square;
                frames.Enqueue(new SignalFrame(square, deltaTime));

                if (frames.Count > contexts.Meta.ManagerEntity.GameConfig.instance.rsmFramesCount)
                {
                    var lastFrame = frames.Dequeue();
                    time -= lastFrame.DeltaTime;
                    totalSquare -= lastFrame.Value;
                }

                entity.ReplaceCurrentRSM(Mathf.Sqrt(totalSquare / time));
                entity.ReplaceTemporaryCurrentRSM(time, totalSquare, frames);
            }
        }
    }
}
