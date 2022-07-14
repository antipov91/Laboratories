using JCMG.EntitasRedux;

namespace Laboratories.Game
{
	public class UpdateDeviceSystem : IUpdateSystem
	{
		private readonly Contexts contexts;
		private IGroup<GameEntity> deviceEntities;
		
		public UpdateDeviceSystem(Contexts contexts)
        {
            this.contexts = contexts;
			deviceEntities = contexts.Game.GetGroup(GameMatcher.Device);
        }

        public void Update()
		{
			foreach (var entity in deviceEntities.GetEntities())
				entity.Device.instance.Process();
		}
	}
}