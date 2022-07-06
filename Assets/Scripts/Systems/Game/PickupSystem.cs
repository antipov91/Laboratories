using JCMG.EntitasRedux;

namespace Laboratories.Game
{
	public class PickupSystem : IUpdateSystem
	{
		private readonly Contexts contexts;
		private IGroup<GameEntity> pickupedEntities;

		public PickupSystem(Contexts contexts)
        {
			this.contexts = contexts;
			pickupedEntities = contexts.Game.GetGroup(GameMatcher.Pickuped);
        }

		public void Update()
		{
			foreach (var entity in pickupedEntities.GetEntities())
            {
				var playerEntity = contexts.Game.PlayerEntity;
				var deltaTime = contexts.Meta.ManagerEntity.DeltaTime.value;

				entity.Transform.instance.position = UnityEngine.Vector3.MoveTowards(entity.Transform.instance.position, playerEntity.Hand.instance.position, deltaTime);
				entity.Transform.instance.rotation = UnityEngine.Quaternion.Lerp(entity.Transform.instance.rotation, playerEntity.Hand.instance.rotation, deltaTime);
            }
		}
	}
}
