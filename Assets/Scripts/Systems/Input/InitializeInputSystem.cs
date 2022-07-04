using JCMG.EntitasRedux;
using UnityEngine;

namespace Laboratories.Input
{
	public class InitializeInputSystem : IInitializeSystem
	{
		private readonly Contexts contexts;

		public InitializeInputSystem(Contexts contexts)
        {
			this.contexts = contexts;
        }

		public void Initialize()
		{
			contexts.Input.IsManager = true;

			contexts.Input.ManagerEntity.ReplaceReturn(false, false, false);

			contexts.Input.ManagerEntity.ReplaceRightStix(Vector2.zero);
			contexts.Input.ManagerEntity.ReplaceMoveStix(Vector2.zero);
			contexts.Input.ManagerEntity.ReplaceCursor(Vector2.zero);
		}
	}
}