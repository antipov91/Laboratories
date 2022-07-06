using JCMG.EntitasRedux;
using Laboratories.ElectricalCircuit;
using System.Collections.Generic;

namespace LaboratoriesComponents.Circuit
{
    [Circuit]
	public class TemporaryVoltageRSMComponent : IComponent
	{
		public float time;
		public float totalSquare;
		public Queue<SignalFrame> frames;
	}
}