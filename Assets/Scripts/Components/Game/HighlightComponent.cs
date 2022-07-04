using JCMG.EntitasRedux;

namespace Laboratories.Components.Game
{
    [Game, Event(EventTarget.Self)]
	public class HighlightComponent : IComponent
	{
		public bool value;
	}
}