using JCMG.EntitasRedux;
using System;

namespace Laboratories.Components.Game
{
    [Game]
    [Serializable]
    [Event(EventTarget.Self)]
	public class ActivePlacementComponent : IComponent
	{
		public bool value;
	}
}