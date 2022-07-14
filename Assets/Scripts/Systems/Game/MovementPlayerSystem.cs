using JCMG.EntitasRedux;
using UnityEngine;

namespace Laboratories.Game
{
	public class MovementPlayerSystem : IUpdateSystem
	{
		private readonly Contexts contexts;

		public MovementPlayerSystem(Contexts contexts)
        {
			this.contexts = contexts;
        }

		public void Update()
		{
			var playerEntity = contexts.Game.PlayerEntity;
            var moveInput = contexts.Input.ManagerEntity.MoveStix.value;

            var forward = playerEntity.Transform.instance.TransformDirection(Vector3.forward);
            var right = playerEntity.Transform.instance.TransformDirection(Vector3.right);

            var vertical = moveInput.y * playerEntity.Speed.value;
            var horizontal = moveInput.x * playerEntity.Speed.value;

            var moveDirection = (forward * vertical) + (right * horizontal);

            if (!playerEntity.CharacterController.instance.isGrounded)
                moveDirection.y -= 9.8f * contexts.Meta.ManagerEntity.DeltaTime.value;

            playerEntity.CharacterController.instance.Move(moveDirection * contexts.Meta.ManagerEntity.DeltaTime.value);
        }
	}
}