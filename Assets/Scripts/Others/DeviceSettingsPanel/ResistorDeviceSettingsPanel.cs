using Laboratories.Devices;
using UnityEngine;
using UnityEngine.UI;

namespace Laboratories
{
    public class ResistorDeviceSettingsPanel : DeviceSettingsPanel
    {
        [SerializeField] private Text label;
        [SerializeField] private Slider slider;

        public override bool CheckCondition(Contexts contexts, GameEntity senderEntity)
        {
            var device = senderEntity.Device.instance;
            return device is ResistorDevice;
        }

        protected override void OnInvoked()
        {
            slider.onValueChanged.AddListener(ValueChanged);

            var device = gameEntity.Device.instance as ResistorDevice;

            var initValue = (float)device.Resistance;

            slider.minValue = (float)device.MinResistance;
            slider.maxValue = (float)device.MaxResistance;
            slider.value = initValue;

            label.text = string.Format("{0:D} Îì", (int)initValue);
        }

        private void ValueChanged(float value)
        {
            var device = gameEntity.Device.instance as ResistorDevice;
            device.Resistance = value;

            label.text = string.Format("{0:D} Îì", (int)value);
        }

        protected override void OnClosed()
        {
            slider.onValueChanged.RemoveListener(ValueChanged);
        }
    }
}