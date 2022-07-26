using JCMG.EntitasRedux;
using System;

namespace Laboratories.Components.Meta
{
    [Meta]
	public class QuitComponent : IComponent
	{
		public Action onQuit;
	}
}