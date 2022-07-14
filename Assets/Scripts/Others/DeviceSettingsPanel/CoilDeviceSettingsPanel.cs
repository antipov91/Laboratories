using UnityEngine;
using UnityEngine.UI;

namespace Laboratories.Devices
{
    public class CoilDeviceSettingsPanel : DeviceSettingsPanel
    {
        [SerializeField] private Text label;
        [SerializeField] private Slider slider;

        public override bool CheckCondition(Contexts contexts, GameEntity senderEntity)
        {
            var device = senderEntity.Device.instance;
            return device is CoilDevice;
        }
        protected override void OnInvoked()
        {
            slider.onValueChanged.AddListener(ValueChanged);

            var device = gameEntity.Device.instance as CoilDevice;

            var initValue = (float)(device.Inductance * 1e6);

            slider.minValue = (float)(device.MinInductance * 1e6);
            slider.maxValue = (float)(device.MaxInductance * 1e6);
            slider.value = initValue;

            label.text = string.Format("{0:D} לךֳם", (int)(device.Inductance * 1e6));
        }

        private void ValueChanged(float value)
        {
            var device = gameEntity.Device.instance as CoilDevice;
            device.Inductance = value / 1e6;

            label.text = string.Format("{0:D} לךֳם", (int)value);
        }

        protected override void OnClosed()
        {
            slider.onValueChanged.RemoveListener(ValueChanged);
        }
    }
}