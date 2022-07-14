using JCMG.EntitasRedux;
using Laboratories.ElectricalCircuit;

namespace Laboratories.Circuits
{
	public class CircuitsInitializeSystem : IInitializeSystem
	{
		private readonly Contexts contexts;

		public CircuitsInitializeSystem(Contexts contexts)
        {
			this.contexts = contexts;
        }


		public void Initialize()
		{
			contexts.Circuit.IsCircuitSimulator = true;

			var circuitEnitity = contexts.Circuit.CircuitSimulatorEntity;

			circuitEnitity.ReplaceCircuit(new CircuitSimulator());
		}
	}
}