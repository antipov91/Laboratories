using JCMG.EntitasRedux;
using Laboratories.Devices;

namespace Laboratories.Components.Circuit
{
    [Circuit]
	public class ScopeSignalResultComponent : IComponent
	{
		public SignalFrame[] values;
	}
}