using JCMG.EntitasRedux;
using UnityEngine;
using UnityEngine.SceneManagement;

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

			var radialMenu = Object.Instantiate(config.radialMenu, canvas.transform);
			uiEntity.ReplaceRadialMenu(radialMenu);
			radialMenu.gameObject.SetActive(false);

			var deviceSettingsMenu = Object.Instantiate(config.deviceSettingsMenu, canvas.transform);
			uiEntity.ReplaceDeviceSettings(deviceSettingsMenu);

			var researchesMenu = Object.Instantiate(config.researchGroupPanel, canvas.transform);
			uiEntity.ReplaceResearches(researchesMenu);

			var nameInfoPanel = Object.Instantiate(config.nameInfoPanel, canvas.transform);
			uiEntity.ReplaceNameInfoPanel(nameInfoPanel);

			var pauseMenu = Object.Instantiate(config.pauseMenu, canvas.transform);
			uiEntity.ReplacePauseMenu(pauseMenu);
			pauseMenu.gameObject.SetActive(false);

			pauseMenu.OnContinueClick += ContinueHandle;
			pauseMenu.OnExitClick += ExitHandle;
		}

		private void ContinueHandle()
        {
			contexts.Meta.ManagerEntity.ReplaceGameState(contexts.Meta.ManagerEntity.PreviouseGameState.value);
        }

		private void ExitHandle()
        {
			contexts.Meta.ManagerEntity.ReplaceQuit(OnQuit);
		}

		private void OnQuit()
		{
			SceneManager.LoadScene("MainMenu");
		}
	}
}