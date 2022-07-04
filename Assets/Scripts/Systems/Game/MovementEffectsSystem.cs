using JCMG.EntitasRedux;
using UnityEngine;

namespace Laboratories.Game
{ 
	public class MovementEffectsSystem : IInitializeSystem, IUpdateSystem
	{
        private readonly Contexts contexts;

        private Quaternion installRotation;
        private Vector3 movementVector;

        public MovementEffectsSystem(Contexts contexts)
        {
            this.contexts = contexts;
        }

        public void Initialize()
        {
            installRotation = contexts.Game.CameraEntity.CameraMovementFX.instance.localRotation;
        }

        public void Update()
		{
            var playerEntity = contexts.Game.PlayerEntity;
            var cameraEntity = contexts.Game.CameraEntity;
            var moveInput = contexts.Input.ManagerEntity.MoveStix.value;
            var rotationAmount = contexts.Meta.ManagerEntity.GameConfig.instance.rotationAmount;
            var rotationSmooth = contexts.Meta.ManagerEntity.GameConfig.instance.rotationSmooth;
            var deltaTime = contexts.Meta.ManagerEntity.DeltaTime.value;

            var vertical = moveInput.y * playerEntity.Speed.value;
            var horizontal = moveInput.x * playerEntity.Speed.value;

            float movementX = (vertical * rotationAmount);
            float movementZ = (-horizontal * rotationAmount);

            movementVector = new Vector3(movementX + playerEntity.CharacterController.instance.velocity.y * playerEntity.Speed.value, 0, movementZ);
            cameraEntity.CameraMovementFX.instance.localRotation = Quaternion.Lerp(cameraEntity.CameraMovementFX.instance.localRotation, Quaternion.Euler(movementVector + installRotation.eulerAngles), deltaTime * rotationSmooth);
        }
	}
}