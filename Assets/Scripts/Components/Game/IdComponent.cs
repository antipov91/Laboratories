using JCMG.EntitasRedux;

namespace Laboratories.Components.Game
{
    [Game]
	public class IdComponent : IComponent
	{
		[PrimaryEntityIndex]
		public string value;
	}
}