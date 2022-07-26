using JCMG.EntitasRedux;

namespace Laboratories.Game
{
	public class InitializeSocketsSystem : IInitializeSystem
	{
		private readonly Contexts contexts;
		private IGroup<GameEntity> entities;

		public InitializeSocketsSystem(Contexts contexts)
        {
			this.contexts = contexts;
			entities = contexts.Game.GetGroup(GameMatcher.BlokeableSockets);
		}

		public void Initialize()
		{
			foreach (var entity in entities)
            {
				foreach (var socketName in entity.BlokeableSockets.values)
                {
					var socketEntity = contexts.Game.GetEntityWithName(socketName);
					socketEntity.IsHighlighBlocked = true;
                }
            }
		}
	}
}
