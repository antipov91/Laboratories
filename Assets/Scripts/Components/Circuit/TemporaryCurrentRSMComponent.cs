using JCMG.EntitasRedux;
using Laboratories.ElectricalCircuit;
using System.Collections.Generic;

namespace Laboratories.Components.Circuit
{
    [Circuit]
	public class TemporaryCurrentRSMComponent : IComponent
	{
		public float time;
		public float totalSquare;
		public Queue<SignalFrame> frames;
	}
}