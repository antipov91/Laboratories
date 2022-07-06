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
				contexts.Circuit.CircuitSimulatorEntity.Circuit.instance.Process();
            }
			catch (Exception e)
            {
				Debug.Log(e.Message);
			}
		}
	}
}