using JCMG.EntitasRedux;
using Laboratories.ElectricalCircuit;

namespace Laboratories.Components.Circuit
{
    [Circuit]
	public class ElementComponent : IComponent
	{
		public IElement instance;
	}
}