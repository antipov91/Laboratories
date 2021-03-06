using JCMG.EntitasRedux;
using UnityEngine;

namespace Laboratories.Game
{
	public class PlacementSystem : IUpdateSystem
	{
		private readonly Contexts contexts;

		public PlacementSystem(Contexts contexts)
        {
            this.contexts = contexts;
        }

		public void Update()
		{
			var playerEntity = contexts.Game.PlayerEntity;
			if (playerEntity.HasDraggableObject == false)
				return;

			var draggedEntity = contexts.Game.GetEntityWithId(playerEntity.DraggableObject.id);
			var cursorPosition = contexts.Input.ManagerEntity.Cursor.value;
			var ray = contexts.Game.CameraEntity.Camera.instance.ScreenPointToRay(cursorPosition);

			if (Physics.Raycast(ray, out var hit, contexts.Meta.ManagerEntity.GameConfig.instance.rayDistance))
            {
				if (draggedEntity.Placements.values.Contains(hit.collider.gameObject))
				{
					draggedEntity.Transform.instance.position = hit.collider.transform.position;
					draggedEntity.Transform.instance.rotation = hit.collider.transform.rotation;

					if (contexts.Input.ManagerEntity.Action.isDown)
					{
						draggedEntity.IsPickuped = false;
						playerEntity.RemoveDraggableObject();

						var colliders = LaboratoriesTools.GetAllComponents<Collider>(draggedEntity.Transform.instance.gameObject);
						foreach (var collider in colliders)
							collider.enabled = true;

						if (draggedEntity.HasActivePlacement)
							draggedEntity.ReplaceActivePlacement(hit.collider.gameObject.CompareTag("ActivePlacement"));

						if (draggedEntity.HasBlokeableSockets)
                        {
							var isBlocked = hit.collider.gameObject.CompareTag("BlockedSockets");
							foreach (var socketName in draggedEntity.BlokeableSockets.values)
                            {
								var socketEntity = contexts.Game.GetEntityWithName(socketName);
								socketEntity.IsHighlighBlocked = isBlocked;
                            }

						}
					}
				}
			}
		}
	}
}