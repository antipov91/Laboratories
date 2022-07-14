using Laboratories.Devices;
using UnityEngine;
using UnityEngine.UI;

namespace Laboratories
{
    public class ACDeviceSettingsPanel : DeviceSettingsPanel
    {
        [SerializeField] private Text label;
        [SerializeField] private Slider slider;

        public override bool CheckCondition(Contexts contexts, GameEntity senderEntity)
        {
            var device = senderEntity.Device.instance;
            return device is ACPowerDevice;
        }
        
        protected override void OnInvoked()
        {
            slider.onValueChanged.AddListener(ValueChanged);

            var device = gameEntity.Device.instance as ACPowerDevice;

            var initValue = (float)device.Voltage;

            slider.minValue = (float)device.MinVoltage;
            slider.maxValue = (float)device.MaxVoltage;
            slider.value = initValue;

            label.text = string.Format("{0:D} Â", (int)device.Voltage);
        }

        private void ValueChanged(float value)
        {
            var device = gameEntity.Device.instance as ACPowerDevice;
            device.Voltage = value;

            label.text = string.Format("{0:D} Â", (int)value);
        }

        protected override void OnClosed()
        {
            slider.onValueChanged.RemoveListener(ValueChanged);
        }
    }
}