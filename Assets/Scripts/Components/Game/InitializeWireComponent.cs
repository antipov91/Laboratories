using JCMG.EntitasRedux;
using Laboratories.ElectricalCircuit;

namespace Laboratories.Components.Game
{
    [Game]
	public class InitializeWireComponent : IComponent
	{
		public ICircuitJoint inJoint;
		public ICircuitJoint outJoint;
	}
}