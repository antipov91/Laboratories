using JCMG.EntitasRedux;
using UnityEngine;

namespace Laboratories.Ui
{
	public class InitializeUiSystem : IInitializeSystem
	{
		private readonly Contexts contexts;

		public InitializeUiSystem(Contexts contexts)
        {
			this.contexts = contexts;
        }

		public void Initialize()
		{
			contexts.Ui.IsManager = true;
			var uiEntity = contexts.Ui.ManagerEntity;

			var config = contexts.Meta.ManagerEntity.GameConfig.instance;
			var canvas = GameObject.FindObjectOfType<Canvas>();

			var pauseMenu = Object.Instantiate(config.pauseMenu, canvas.transform);
			uiEntity.ReplacePauseMenu(pauseMenu);
			pauseMenu.gameObject.SetActive(false);

			pauseMenu.OnContinueClick += ContinueHandle;
			pauseMenu.OnExitClick += ExitHandle;

			var radialMenu = Object.Instantiate(config.radialMenu, canvas.transform);
			uiEntity.ReplaceRadialMenu(radialMenu);
			radialMenu.gameObject.SetActive(false);

			var deviceSettingsMenu = Object.Instantiate(config.deviceSettingsMenu, canvas.transform);
			uiEntity.ReplaceDeviceSettings(deviceSettingsMenu);
		}

		private void ContinueHandle()
        {
			contexts.Meta.ManagerEntity.ReplaceGameState(contexts.Meta.ManagerEntity.PreviouseGameState.value);
        }

		private void ExitHandle()
        {

        }
	}
}