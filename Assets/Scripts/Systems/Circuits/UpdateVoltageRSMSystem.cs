using JCMG.EntitasRedux;
using Laboratories.ElectricalCircuit;
using UnityEngine;

namespace Laboratories.Circuits
{
	public class UpdateVoltageRSMSystem : IUpdateSystem
	{
        private readonly Contexts contexts;
        private readonly IGroup<CircuitEntity> entitiesGroup;

        public UpdateVoltageRSMSystem(Contexts contexts)
        {
            this.contexts = contexts;
            entitiesGroup = contexts.Circuit.GetGroup(CircuitMatcher.AllOf(CircuitMatcher.VoltageRSM,
                                                                           CircuitMatcher.TemporaryVoltageRSM,
                                                                           CircuitMatcher.Element));
        }

        public void Update()
        {
            foreach (var entity in entitiesGroup.GetEntities())
            {
                var time = entity.TemporaryVoltageRSM.time;
                var totalSquare = entity.TemporaryVoltageRSM.totalSquare;
                var frames = entity.TemporaryVoltageRSM.frames;

                UnityEngine.Debug.Log(entity.Element.instance.Voltage);
                var deltaTime = contexts.Circuit.CircuitSimulatorEntity.DeltaTime.value;
                var square = Mathf.Pow(entity.Element.instance.Voltage, 2) * deltaTime;

                time += deltaTime;
                totalSquare += square;
                frames.Enqueue(new SignalFrame(square, deltaTime));

                if (frames.Count > contexts.Meta.ManagerEntity.GameConfig.instance.rsmFramesCount)
                {
                    var lastFrame = frames.Dequeue();
                    time -= lastFrame.DeltaTime;
                    totalSquare -= lastFrame.Value;
                }

                entity.ReplaceVoltageRSM(Mathf.Sqrt(totalSquare / time));
                entity.ReplaceTemporaryVoltageRSM(time, totalSquare, frames);
            }
        }
    }
}