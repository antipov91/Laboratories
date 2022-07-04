using JCMG.EntitasRedux;
using Laboratories.Views;
using UnityEngine;

namespace Laboratories.Game
{
	public class InitializeEntitiesInSceneSystem : IInitializeSystem
	{
		private readonly Contexts contexts;

		public InitializeEntitiesInSceneSystem(Contexts contexts)
		{
			this.contexts = contexts;
		}

		public void Initialize()
		{
			var blueprints = Object.FindObjectsOfType<GameBlueprintBehaviour>();
			foreach (var blueprint in blueprints)
			{
				var entity = contexts.Game.CreateEntity();
				blueprint.ApplyToEntity(entity);

				var view = blueprint.gameObject.GetComponent<GameView>();
				if (view == null)
					view = blueprint.gameObject.AddComponent<GameView>();

				if (entity.HasName == false)
					entity.ReplaceName(blueprint.gameObject.name);

				entity.ReplaceView(view);
				entity.ReplaceTransform(blueprint.GetComponent<Transform>());
				view.OnEntityInitilaized(contexts, entity);
			}
		}
	}
}
