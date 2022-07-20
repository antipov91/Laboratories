using System;
using UnityEngine;
using UnityEngine.UI;

namespace Laboratories.Devices
{
    public class LaserDeviceSettingsPanel : DeviceSettingsPanel
    {
        [Header("Ui")]
        [SerializeField] private Text waveLengthLabel;
        [SerializeField] private Slider waveLengthSlider;

        public override bool CheckCondition(Contexts contexts, GameEntity senderEntity)
        {
            var device = senderEntity.Device.instance;
            return device is LaserDevice;
        }

        protected override void OnInvoked()
        {
            var device = gameEntity.Device.instance as LaserDevice;

            var initValue = (float)(device.WaveLength * 1e9);
            waveLengthSlider.minValue = (float)(device.MinWaveLength * 1e9);
            waveLengthSlider.maxValue = (float)(device.MaxWaveLength * 1e9);
            waveLengthSlider.value = initValue;

            waveLengthLabel.text = String.Format("{0:D}", (int)initValue);
            waveLengthSlider.onValueChanged.AddListener(WaveLengthChanged);
        }

        private void WaveLengthChanged(float value)
        {
            var device = gameEntity.Device.instance as LaserDevice;

            device.WaveLength = value * 1e-9;
            waveLengthLabel.text = String.Format("{0:D}", (int)value);
        }

        protected override void OnClosed()
        {
            waveLengthSlider.onValueChanged.RemoveListener(WaveLengthChanged);
        }
    }
}