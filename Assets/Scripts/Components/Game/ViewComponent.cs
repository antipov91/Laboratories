using JCMG.EntitasRedux;
using Laboratories.Views;

namespace Laboratories.Components.Game
{
    [Game]
	public class ViewComponent : IComponent
	{
		public IView instance;
	}
}