using JCMG.EntitasRedux;
using UnityEngine;

namespace Laboratories.Input
{
	public class UpdateInputSystem : IUpdateSystem
	{
		private readonly Contexts contexts;

		public UpdateInputSystem(Contexts contexts)
        {
			this.contexts = contexts;
        }

		public void Update()
		{
			contexts.Input.ManagerEntity.ReplaceReturn(UnityEngine.Input.GetKeyDown(KeyCode.Escape), UnityEngine.Input.GetKey(KeyCode.Escape), UnityEngine.Input.GetKeyUp(KeyCode.Escape));
			contexts.Input.ManagerEntity.ReplaceAction(UnityEngine.Input.GetMouseButtonDown(0), UnityEngine.Input.GetMouseButton(0), UnityEngine.Input.GetMouseButtonUp(0));
			contexts.Input.ManagerEntity.ReplaceZoom(UnityEngine.Input.GetKeyDown(KeyCode.Q), UnityEngine.Input.GetKey(KeyCode.Q), UnityEngine.Input.GetKeyUp(KeyCode.Q));

			var moveVector = new Vector2(UnityEngine.Input.GetAxis("Horizontal"), UnityEngine.Input.GetAxis("Vertical"));
			var rightStix = new Vector2(UnityEngine.Input.GetAxis("Mouse X"), UnityEngine.Input.GetAxis("Mouse Y"));

			contexts.Input.ManagerEntity.ReplaceMoveStix(moveVector.normalized);
			contexts.Input.ManagerEntity.ReplaceRightStix(rightStix);
			contexts.Input.ManagerEntity.ReplaceCursor(UnityEngine.Input.mousePosition);
		}
	}
}