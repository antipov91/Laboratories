using JCMG.EntitasRedux;

namespace Laboratories.Components.Input
{
    [Input]
	public class ActionComponent : IComponent
	{
		public bool isDown;
		public bool isPressed;
		public bool isUp;
	}
}