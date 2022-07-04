using JCMG.EntitasRedux;
using UnityEngine;

namespace Laboratories.Game
{
	public class RotationPlayerSystem : IUpdateSystem
	{
		private readonly Contexts contexts;

        private float rotationX = 0;

        public RotationPlayerSystem(Contexts contexts)
        {
            this.contexts = contexts;
        }

        public void Update()
		{
            var playerEntity = contexts.Game.PlayerEntity;
            var cameraEntity = contexts.Game.CameraEntity;
            var rightStix = contexts.Input.ManagerEntity.RightStix.value;
            var gameConfig = contexts.Meta.ManagerEntity.GameConfig.instance;

            rotationX += -rightStix.y * gameConfig.lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -gameConfig.lookLimit, gameConfig.lookLimit);
            cameraEntity.Transform.instance.localRotation = Quaternion.Euler(rotationX, 0, 0);
            playerEntity.Transform.instance.rotation *= Quaternion.Euler(0, rightStix.x * gameConfig.lookSpeed, 0);
        }
    }
}