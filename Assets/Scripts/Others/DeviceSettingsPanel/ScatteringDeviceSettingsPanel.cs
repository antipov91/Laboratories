using Laboratories.Devices;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Laboratories
{
    public class ScatteringDeviceSettingsPanel : DeviceSettingsPanel
    {
        [SerializeField] private Text distanceText;
        [SerializeField] private Slider distanceSlider;

        [SerializeField] private Text firstRadiusText;
        [SerializeField] private Slider firstRadiusSlider;

        [SerializeField] private Text secondRadiusText;
        [SerializeField] private Slider secondRadiusSlider;

        public override bool CheckCondition(Contexts contexts, GameEntity senderEntity)
        {
            return senderEntity.Device.instance is CollectingLensDevice;
        }

        protected override void OnInvoked()
        {
            var device = gameEntity.Device.instance as CollectingLensDevice;

            distanceText.text = String.Format("{0:D}", (int)device.Distance);
            firstRadiusText.text = String.Format("{0:D}", (int)device.FirstRadius);
            secondRadiusText.text = String.Format("{0:D}", (int)device.SecondRadius);

            distanceSlider.onValueChanged.AddListener(DistanceChangedHandle);
            firstRadiusSlider.onValueChanged.AddListener(FirstRadiusChangedHandle);
            secondRadiusSlider.onValueChanged.AddListener(SecondRadiusChangedHandle);
        }

        private void DistanceChangedHandle(float value)
        {
            var device = gameEntity.Device.instance as CollectingLensDevice;

            distanceText.text = String.Format("{0:D}", (int)device.Distance);

            device.Distance = value;
        }

        private void FirstRadiusChangedHandle(float value)
        {
            var device = gameEntity.Device.instance as CollectingLensDevice;

            firstRadiusText.text = String.Format("{0:D}", (int)device.FirstRadius);

            device.FirstRadius = value;
        }

        private void SecondRadiusChangedHandle(float value)
        {
            var device = gameEntity.Device.instance as CollectingLensDevice;

            secondRadiusText.text = String.Format("{0:D}", (int)device.SecondRadius);

            device.SecondRadius = value;
        }

        protected override void OnClosed()
        {
            distanceSlider.onValueChanged.RemoveListener(DistanceChangedHandle);
            firstRadiusSlider.onValueChanged.RemoveListener(FirstRadiusChangedHandle);
            secondRadiusSlider.onValueChanged.RemoveListener(SecondRadiusChangedHandle);
        }
    }
}