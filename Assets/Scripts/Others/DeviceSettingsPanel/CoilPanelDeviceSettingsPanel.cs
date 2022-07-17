using Laboratories.Devices;
using UnityEngine;
using UnityEngine.UI;

namespace Laboratories
{
    public class CoilPanelDeviceSettingsPanel : DeviceSettingsPanel
    {
        [SerializeField] private Text inductanceLabel;
        [SerializeField] private Slider inductanceSlider;

        [SerializeField] private Text lengthLabel;
        [SerializeField] private Slider lengthSlider;

        [SerializeField] private Text radiusLabel;
        [SerializeField] private Slider radiusSlider;

        [SerializeField] private Text countLabel;
        [SerializeField] private Slider countSlider;

        public override bool CheckCondition(Contexts contexts, GameEntity senderEntity)
        {
            return senderEntity.Device.instance is CoilPanelDevice;
        }

        protected override void OnInvoked()
        {
            var device = gameEntity.Device.instance as CoilPanelDevice;

            var initInductance = device.Inductance;
            var initLength = device.Length;
            var initRadius = device.Radius;
            var initCount = device.Count;

            inductanceSlider.onValueChanged.AddListener(InductanceChangedHandle);
            lengthSlider.onValueChanged.AddListener(LengthChangedHandle);
            radiusSlider.onValueChanged.AddListener(RadiusChangedHandle);
            countSlider.onValueChanged.AddListener(CountChangedHandle);

            inductanceSlider.minValue = (device.MinInductance * 1e6f);
            inductanceSlider.maxValue = (device.MaxInductance * 1e6f);
            inductanceSlider.value = (int)(initInductance * 1e6f);

            lengthSlider.minValue = device.MinLength;
            lengthSlider.maxValue = device.MaxLength;
            lengthSlider.value = (float)initLength;

            radiusSlider.minValue = device.MinRadius;
            radiusSlider.maxValue = device.MaxRadius;
            radiusSlider.value = (float)initRadius;

            countSlider.minValue = device.MinCount;
            countSlider.maxValue = device.MaxCount;
            countSlider.value = initCount;
            countSlider.wholeNumbers = true;

            countLabel.text = string.Format("{0:D}", initCount);
            radiusLabel.text = string.Format("{0:F1} —Ï", initRadius);
            lengthLabel.text = string.Format("{0:F1} —Ï", initLength);
            inductanceLabel.text = string.Format("{0:D} ÏÍ√Ì", (int)(initInductance * 1e6));
        }

        private void CountChangedHandle(float value)
        {
            var device = gameEntity.Device.instance as CoilPanelDevice;

            device.Count = (int)value;
            countLabel.text = string.Format("{0:D}", (int)value);
        }

        private void RadiusChangedHandle(float value)
        {
            var device = gameEntity.Device.instance as CoilPanelDevice;

            device.Radius = value;
            radiusLabel.text = string.Format("{0:F2} —Ï", value);
        }

        private void LengthChangedHandle(float value)
        {
            var device = gameEntity.Device.instance as CoilPanelDevice;

            device.Length = value;
            lengthLabel.text = string.Format("{0:F2} —Ï", value);
        }

        private void InductanceChangedHandle(float value)
        {
            var device = gameEntity.Device.instance as CoilPanelDevice;

            device.Inductance = (value / 1e5);
            inductanceLabel.text = string.Format("{0:D} ÏÍ√Ì", (int)value);
        }

        protected override void OnClosed()
        {
            inductanceSlider.onValueChanged.RemoveListener(InductanceChangedHandle);
            lengthSlider.onValueChanged.RemoveListener(LengthChangedHandle);
            radiusSlider.onValueChanged.RemoveListener(RadiusChangedHandle);
            countSlider.onValueChanged.RemoveListener(CountChangedHandle);
        }
    }
}