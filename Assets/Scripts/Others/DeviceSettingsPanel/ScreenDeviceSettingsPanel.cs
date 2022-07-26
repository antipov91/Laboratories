using Laboratories.Devices;
using UnityEngine;
using UnityEngine.UI;

namespace Laboratories
{
    public class ScreenDeviceSettingsPanel : DeviceSettingsPanel
    {
        [SerializeField] private Text distanceLabel;
        [SerializeField] private Slider distanceSlider;

        public override bool CheckCondition(Contexts contexts, GameEntity senderEntity)
        {
            return senderEntity.Device.instance is ScreenDevice;
        }

        protected override void OnInvoked()
        {
            var device = gameEntity.Device.instance as ScreenDevice;

            var initDistance = device.Distance;
            distanceSlider.minValue = device.MinDistance;
            distanceSlider.maxValue = device.MaxDistance;
            distanceSlider.value = initDistance;

            distanceLabel.text = string.Format("{0:F2}", initDistance);

            distanceSlider.onValueChanged.AddListener(OnDistanceChanged);
        }

        private void OnDistanceChanged(float value)
        {
            var device = gameEntity.Device.instance as ScreenDevice;

            device.Distance = value;

            distanceLabel.text = string.Format("{0:F2}", value);
        }

        protected override void OnClosed()
        {
            distanceSlider.onValueChanged.RemoveListener(OnDistanceChanged);
        }
    }
}