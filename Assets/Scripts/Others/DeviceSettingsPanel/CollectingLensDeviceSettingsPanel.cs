using UnityEngine;
using Laboratories.Devices;
using UnityEngine.UI;
using System;

namespace Laboratories
{
    public class CollectingLensDeviceSettingsPanel : DeviceSettingsPanel
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

            distanceText.text = String.Format("{0:F2}", device.Distance);
            firstRadiusText.text = String.Format("{0:F1}", device.FirstRadius * 1000f);
            secondRadiusText.text = String.Format("{0:F1}", device.SecondRadius * 1000f);

            var initDistance = device.Distance;
            distanceSlider.minValue = device.MinDistance;
            distanceSlider.maxValue = device.MaxDistance;
            distanceSlider.value = initDistance;

            var initFirstRadius = device.FirstRadius;
            firstRadiusSlider.minValue = (float)device.MinFirstRadius;
            firstRadiusSlider.maxValue = (float)device.MaxFirstRadius;
            firstRadiusSlider.value = (float)initFirstRadius;

            var initSecondRadius = device.SecondRadius;
            secondRadiusSlider.minValue = (float)device.MinSecondRadius;
            secondRadiusSlider.maxValue = (float)device.MaxSecondRadius;
            secondRadiusSlider.value = (float)initSecondRadius;

            distanceSlider.onValueChanged.AddListener(DistanceChangedHandle);
            firstRadiusSlider.onValueChanged.AddListener(FirstRadiusChangedHandle);
            secondRadiusSlider.onValueChanged.AddListener(SecondRadiusChangedHandle);
        }

        private void DistanceChangedHandle(float value)
        {
            var device = gameEntity.Device.instance as CollectingLensDevice;

            distanceText.text = String.Format("{0:F2}", device.Distance);

            device.Distance = value;
        }

        private void FirstRadiusChangedHandle(float value)
        {
            var device = gameEntity.Device.instance as CollectingLensDevice;

            firstRadiusText.text = String.Format("{0:F1}", device.FirstRadius * 1000f);

            device.FirstRadius = value;
        }

        private void SecondRadiusChangedHandle(float value)
        {
            var device = gameEntity.Device.instance as CollectingLensDevice;

            secondRadiusText.text = String.Format("{0:F1}", device.SecondRadius * 1000f);

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