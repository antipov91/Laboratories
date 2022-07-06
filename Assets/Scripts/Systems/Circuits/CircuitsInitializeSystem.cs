using JCMG.EntitasRedux;

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

			var ciruitEnitity = contexts.Circuit.CircuitSimulatorEntity;


		}
	}
}