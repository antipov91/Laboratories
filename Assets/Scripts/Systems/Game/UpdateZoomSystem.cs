using JCMG.EntitasRedux;

namespace Laboratories.Game
{
	public class UpdateZoomSystem : IUpdateSystem
	{
		private readonly Contexts contexts;

		public UpdateZoomSystem(Contexts contexts)
        {
			this.contexts = contexts;
        }

		public void Update()
		{
			if (contexts.Input.ManagerEntity.Zoom.isPressed)
				contexts.Game.Camera.instance.fieldOfView = 25f;
			else
				contexts.Game.Camera.instance.fieldOfView = 65;
		}
	}
}
