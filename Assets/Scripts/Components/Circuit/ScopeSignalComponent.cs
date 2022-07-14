using JCMG.EntitasRedux;
using Laboratories.Devices;
using System.Collections.Generic;

namespace Laboratories.Components.Circuit
{
    [Circuit]
	public class ScopeSignalComponent : IComponent
	{
		public float timeWindow;
		public Queue<SignalFrame> queue;
		public float currentTime;
	}
}