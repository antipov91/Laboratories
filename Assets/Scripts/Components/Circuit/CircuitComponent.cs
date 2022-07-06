using Laboratories.ElectricalCircuit;
using JCMG.EntitasRedux;

namespace Laboratories.Components.Circuit
{
    [Circuit]
	public class CircuitComponent : IComponent
	{
		public ICircuitSimulator instance;
	}
}
