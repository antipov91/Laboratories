using Laboratories.Devices;
using UnityEngine;
using UnityEngine.UI;

namespace Laboratories
{
    public class CapacitorDeviceSettingsPanel : DeviceSettingsPanel
    {
        [SerializeField] private Text label;
        [SerializeField] private Slider slider;

        public override bool CheckCondition(Contexts contexts, GameEntity senderEntity)
        {
            var device = senderEntity.Device.instance;
            return device is CapacitorDevice;
        }
        protected override void OnInvoked()
        {
            slider.onValueChanged.AddListener(ValueChanged);

            var device = gameEntity.Device.instance as CapacitorDevice;

            var initValue = (float)(device.Capistance * 1e6);

            slider.minValue = (float)(device.MinCapistance * 1e6);
            slider.maxValue = (float)(device.MaxCapistance * 1e6);
            slider.value = initValue;

            label.text = string.Format("{0:D} ÏÍ‘", (int)initValue);
        }

        private void ValueChanged(float value)
        {
            var device = gameEntity.Device.instance as CapacitorDevice;
            device.Capistance = value / 1e6;

            label.text = string.Format("{0:D} ÏÍ‘", (int)(value));
        }

        protected override void OnClosed()
        {
            slider.onValueChanged.RemoveListener(ValueChanged);
        }
    }
}