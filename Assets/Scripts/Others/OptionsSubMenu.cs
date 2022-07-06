using UnityEngine;
using UnityEngine.UI;

namespace Laboratories
{
    public class OptionsSubMenu : SubMenu
    {
        [SerializeField] private Slider soundsSlider;
        [SerializeField] private Slider musicSlider;
        [SerializeField] private Button returnBtn;

        protected override void OnInit()
        {
            returnBtn.onClick.AddListener(ReturnClick);
            soundsSlider.onValueChanged.AddListener(SoundsChanged);
            musicSlider.onValueChanged.AddListener(MusicChanged);
        }

        private void MusicChanged(float value)
        {
            
        }

        private void SoundsChanged(float value)
        {
            
        }

        private void ReturnClick()
        {
            menu.CurrentSubMenu = null;
        }

        protected override void OnDeinit()
        {
            returnBtn.onClick.RemoveListener(ReturnClick);
            soundsSlider.onValueChanged.RemoveListener(SoundsChanged);
            musicSlider.onValueChanged.RemoveListener(MusicChanged);
        }
    }
}