using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Laboratories
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private Button electrBtn;
        [SerializeField] private Button opticaBtn;
        [SerializeField] private Button quitBtn;

        private void OnEnable()
        {
            electrBtn.onClick.AddListener(ElectrClick);
            opticaBtn.onClick.AddListener(OpticaClick);
            quitBtn.onClick.AddListener(QuitClick);
        }

        private void QuitClick()
        {
            Application.Quit();
        }

        private void OpticaClick()
        {
            SceneManager.LoadScene("LaboratoryWork_2");
        }

        private void ElectrClick()
        {
            SceneManager.LoadScene("LaboratoryWork_1");
        }

        private void OnDisable()
        {
            electrBtn.onClick.RemoveListener(ElectrClick);
            opticaBtn.onClick.RemoveListener(OpticaClick);
            quitBtn.onClick.RemoveListener(QuitClick);
        }
    }
}