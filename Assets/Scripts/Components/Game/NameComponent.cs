using JCMG.EntitasRedux;

namespace Laboratories.Components.Game
{
    [Game]
	public class NameComponent : IComponent
	{
		[PrimaryEntityIndex]
		public string value;
	}
}