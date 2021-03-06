using JCMG.EntitasRedux;
using UnityEngine;

namespace Laboratories.Meta
{
	public class InitializeMetaSystem : IInitializeSystem
	{
		private readonly Contexts contexts;
		private GameConfig gameConfig;

		public InitializeMetaSystem(Contexts contexts, GameConfig gameConfig)
        {
			this.contexts = contexts;
			this.gameConfig = gameConfig;
        }

		public void Initialize()
		{
			contexts.Meta.IsManager = true;

			contexts.Meta.ManagerEntity.ReplaceGameConfig(gameConfig);
			contexts.Meta.ManagerEntity.ReplaceDeltaTime(0f);

			contexts.Meta.ManagerEntity.ReplaceGameState(GameState.Game);
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}
	}
}