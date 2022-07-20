using Laboratories.Devices;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Laboratories
{
    public class DifractionGridDeviceSettingsPanel : DeviceSettingsPanel
    {
        [SerializeField] private Text deltaLabel;
        [SerializeField] private Slider deltaSlider;

        [SerializeField] private Text holeLengthLabel;
        [SerializeField] private Slider holeLengthSlider;

        [SerializeField] private Text countLabel;
        [SerializeField] private Slider countSlider;

        public override bool CheckCondition(Contexts contexts, GameEntity senderEntity)
        {
            return senderEntity.Device.instance is DifractionGridDevice;
        }

        protected override void OnInvoked()
        {
            var device = gameEntity.Device.instance as DifractionGridDevice;

            var initDelta = device.Delta;
            deltaSlider.minValue = (float)(device.MinDelta * 1e6);
            deltaSlider.maxValue = (float)(device.MaxDelta * 1e6);
            deltaSlider.value = (float)(initDelta * 1e6);
            deltaSlider.wholeNumbers = true;

            var initHoleLength = device.HoleLength;
            holeLengthSlider.minValue = (float)(device.MinHoleLength * 1e6);
            holeLengthSlider.maxValue = (float)(device.MaxHoleLength * 1e6);
            holeLengthSlider.value = (float)(initHoleLength * 1e6);
            holeLengthSlider.wholeNumbers = true;

            var initCount = device.Count;
            countSlider.minValue = device.MinCount;
            countSlider.maxValue = device.MaxCount;
            countSlider.value = initCount;
            countSlider.wholeNumbers = true;

            deltaLabel.text = String.Format("{0:D} ìêì", (int)(initDelta * 1e6));
            holeLengthLabel.text = String.Format("{0:D} ìêì", (int)(initHoleLength * 1e6));
            countLabel.text = String.Format("{0:D}", (int)initCount);

            deltaSlider.onValueChanged.AddListener(DeltaHandle);
            holeLengthSlider.onValueChanged.AddListener(HoleLengthChagnedHandle);
            countSlider.onValueChanged.AddListener(CountChangedHandle);
        }

        private void CountChangedHandle(float value)
        {
            var device = gameEntity.Device.instance as DifractionGridDevice;

            device.Count = (int)value;
            countLabel.text = String.Format("{0:D}", (int)value);
        }

        private void HoleLengthChagnedHandle(float value)
        {
            var device = gameEntity.Device.instance as DifractionGridDevice;

            device.HoleLength = value * 1e-6;
            holeLengthLabel.text = String.Format("{0:D} ìêì", (int)value);
        }

        private void DeltaHandle(float value)
        {
            var device = gameEntity.Device.instance as DifractionGridDevice;

            device.Delta = value * 1e-6;
            deltaLabel.text = String.Format("{0:D} ìêì", (int)value);
        }

        protected override void OnClosed()
        {
            deltaSlider.onValueChanged.RemoveListener(DeltaHandle);
            holeLengthSlider.onValueChanged.RemoveListener(HoleLengthChagnedHandle);
            countSlider.onValueChanged.RemoveListener(CountChangedHandle);
        }
    }
}