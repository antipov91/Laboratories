using Laboratories.Devices;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Laboratories
{
    public class SlitDeviceSettingsPanel : DeviceSettingsPanel
    {
        [SerializeField] private Button closeRightBtn;
        [SerializeField] private Button closeLeftBtn;
        [SerializeField] private Button openAllBtn;

        [SerializeField] private Text deltaLabel;
        [SerializeField] private Slider deltaSlider;

        public override bool CheckCondition(Contexts contexts, GameEntity senderEntity)
        {
            return senderEntity.Device.instance is SlitDevice;
        }

        protected override void OnInvoked()
        {
            var device = gameEntity.Device.instance as SlitDevice;

            var initDelta = device.Delta;
            deltaSlider.minValue = (float)(device.MinDelta * 1e6);
            deltaSlider.maxValue = (float)(device.MaxDelta * 1e6);
            deltaSlider.value = (float)(initDelta * 1e6);
            deltaSlider.wholeNumbers = true;

            deltaLabel.text = String.Format("{0:D} ìêì", (int)(initDelta * 1e6));

            deltaSlider.onValueChanged.AddListener(DeltaChanged);

            closeRightBtn.onClick.AddListener(CloseRightHandle);
            closeLeftBtn.onClick.AddListener(CloseLeftHandle);
            openAllBtn.onClick.AddListener(OpenAllHandle);
        }

        private void OpenAllHandle()
        {
            var device = gameEntity.Device.instance as SlitDevice;
            device.IsOpenAll = true;

            closeRightBtn.interactable = true;
            closeLeftBtn.interactable = true;
            openAllBtn.interactable = false;
        }

        private void CloseLeftHandle()
        {
            var device = gameEntity.Device.instance as SlitDevice;
            device.IsOpenAll = false;

            closeRightBtn.interactable = true;
            closeLeftBtn.interactable = false;
            openAllBtn.interactable = true;
        }

        private void CloseRightHandle()
        {
            var device = gameEntity.Device.instance as SlitDevice;
            device.IsOpenAll = false;

            closeRightBtn.interactable = false;
            closeLeftBtn.interactable = true;
            openAllBtn.interactable = true;
        }

        private void DeltaChanged(float value)
        {
            var device = gameEntity.Device.instance as SlitDevice;

            device.Delta = value / 1e6;
            deltaLabel.text = String.Format("{0:D} ìêì", (int)(value));
        }

        protected override void OnClosed()
        {
            deltaSlider.onValueChanged.RemoveListener(DeltaChanged);

            closeRightBtn.onClick.RemoveListener(CloseRightHandle);
            closeLeftBtn.onClick.RemoveListener(CloseLeftHandle);
            openAllBtn.onClick.RemoveListener(OpenAllHandle);
        }
    }
}