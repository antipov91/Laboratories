using JCMG.EntitasRedux;
using System;
using UnityEngine;

namespace Laboratories.Circuits
{
	public class UpdateCircuitSystem : IUpdateSystem
	{
		private Contexts contexts;

		public UpdateCircuitSystem(Contexts contexts)
        {
			this.contexts = contexts;
        }

		public void Update()
		{
			try
            {
				var deltaTime = contexts.Circuit.CircuitSimulatorEntity.Circuit.instance.CountStep * contexts.Circuit.CircuitSimulatorEntity.Circuit.instance.TimeStep;
				contexts.Circuit.CircuitSimulatorEntity.ReplaceDeltaTime((float)deltaTime);
				contexts.Circuit.CircuitSimulatorEntity.Circuit.instance.Process();
            }
			catch (Exception e)
            {
				Debug.Log(e.Message);
			}
		}
	}
}