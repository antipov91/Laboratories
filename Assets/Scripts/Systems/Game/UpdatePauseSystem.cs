using JCMG.EntitasRedux;

namespace Laboratories.Game
{
	public class UpdatePauseSystem : IUpdateSystem
	{
		private readonly Contexts contexts;

		public UpdatePauseSystem(Contexts contexts)
        {
            this.contexts = contexts;
        }

        public void Update()
		{
			if (contexts.Input.ManagerEntity.Return.isDown)
            {
				var metaEntity = contexts.Meta.ManagerEntity;

				if (metaEntity.GameState.value == GameState.Paused)
					metaEntity.ReplaceGameState(metaEntity.PreviouseGameState.value);
				else
					metaEntity.ReplaceGameState(GameState.Paused);
            }
		}
	}
}