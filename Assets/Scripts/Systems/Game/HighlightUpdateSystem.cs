using JCMG.EntitasRedux;
using UnityEngine;

namespace Laboratories.Game
{
	public class HighlightUpdateSystem : IUpdateSystem
	{
		private readonly Contexts contexts;
		private IGroup<GameEntity> gameEntities;

		public HighlightUpdateSystem(Contexts contexts)
        {
			this.contexts = contexts;
			gameEntities = contexts.Game.GetGroup(GameMatcher.Highlight);
        }

		public void Update()
		{
			if (contexts.Game.PlayerEntity.HasDraggableObject)
				return;

			var cursorPosition = contexts.Input.ManagerEntity.Cursor.value;

			var ray = contexts.Game.CameraEntity.Camera.instance.ScreenPointToRay(cursorPosition);

			bool isFoundedHighlight = false;
			if (Physics.Raycast(ray, out var hit, contexts.Meta.ManagerEntity.GameConfig.instance.rayDistance))
			{
				if (hit.collider.gameObject.TryGetComponent<EntityLink>(out var entityLink))
				{
					var gameEntity = entityLink.Entity as GameEntity;
					if (gameEntity != null && gameEntity.HasHighlight)
					{
						if (gameEntity.Highlight.value == false)
						{
							foreach (var highlightEntity in gameEntities.GetEntities())
								if (highlightEntity.Highlight.value)
									highlightEntity.ReplaceHighlight(false);

							gameEntity.ReplaceHighlight(true);
						}
						isFoundedHighlight = true;

						if (contexts.Input.ManagerEntity.Action.isDown)
							gameEntity.IsClicked = true;	
					}
				}
			}

			if (isFoundedHighlight == false)
			{
				foreach (var highlightEntity in gameEntities.GetEntities())
					if (highlightEntity.Highlight.value)
						highlightEntity.ReplaceHighlight(false);
			}
		}
	}
}