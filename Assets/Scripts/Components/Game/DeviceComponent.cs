using JCMG.EntitasRedux;
using Laboratories.Devices;
using System;

namespace Laboratories.Components.Game
{
    [Game]
    [Serializable]
	public class DeviceComponent : IComponent
	{
		public MonoDevice instance;
	}
}