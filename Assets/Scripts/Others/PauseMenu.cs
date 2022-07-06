using System;
using UnityEngine;
using UnityEngine.UI;

namespace Laboratories
{
    public class PauseMenu : Menu
    {
        public Action OnContinueClick;
        public Action OnExitClick;

        [Header("Ui")]
        [SerializeField] private Button continueBtn;
        [SerializeField] private Button optionsBtn;
        [SerializeField] private Button exitBtn;

        [Header("SubMenu")]
        [SerializeField] private SubMenu optionsSubMenu;
        private void OnEnable()
        {
            continueBtn.onClick.AddListener(ContinueClick);
            optionsBtn.onClick.AddListener(OptionsClick);
            exitBtn.onClick.AddListener(ExitClick);
        }

        private void ContinueClick()
        {
            OnContinueClick?.Invoke();
        }

        private void OptionsClick()
        {
            CurrentSubMenu = optionsSubMenu;
        }

        private void ExitClick()
        {
            OnExitClick?.Invoke();
        }

        private void OnDisable()
        {
            continueBtn.onClick.RemoveListener(ContinueClick);
            optionsBtn.onClick.RemoveListener(OptionsClick);
            exitBtn.onClick.RemoveListener(ExitClick);
        }
    }
}