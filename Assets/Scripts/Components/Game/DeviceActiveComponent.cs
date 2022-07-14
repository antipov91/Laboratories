using JCMG.EntitasRedux;
using System;

namespace Laboratories.Components.Game
{
    [Game]
    [Serializable]
    [Event(EventTarget.Self)]
	public class DeviceActiveComponent : IComponent
	{
		public bool value;
	}
}