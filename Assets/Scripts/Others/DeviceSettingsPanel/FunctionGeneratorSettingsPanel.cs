using Laboratories.Devices;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Laboratories
{
    public class FunctionGeneratorSettingsPanel : DeviceSettingsPanel
    {
        [SerializeField] private Button sinBtn;
        [SerializeField] private Button rectBtn;
        [SerializeField] private Text maxVoltageLabel;
        [SerializeField] private Slider maxVoltageSlider;
        [SerializeField] private Text frequencyLabel;
        [SerializeField] private Slider frequencySlider;

        public override bool CheckCondition(Contexts contexts, GameEntity senderEntity)
        {
            return senderEntity.Device.instance is FunctionGeneratorDevice;
        }

        protected override void OnInvoked()
        {
            var device = gameEntity.Device.instance as FunctionGeneratorDevice;

            var initVoltage = device.Voltage;
            var initFrequency = device.Frequency;

            maxVoltageSlider.minValue = (float)device.MinVoltage;
            maxVoltageSlider.maxValue = (float)device.MaxVoltage;
            maxVoltageSlider.value = (float)initVoltage;

            frequencySlider.minValue = (float)device.MinFrequency;
            frequencySlider.maxValue = (float)device.MaxFrequency;
            frequencySlider.value = (float)initFrequency;

            if (device.Waveform == SharpCircuit.Voltage.WaveType.AC)
            {
                sinBtn.interactable = false;
                rectBtn.interactable = true;
            }
            else if (device.Waveform == SharpCircuit.Voltage.WaveType.SQUARE)
            {
                sinBtn.interactable = true;
                rectBtn.interactable = false;
            }
            else
                throw new ArgumentException();

            frequencyLabel.text = String.Format("{0:F2}", initFrequency);
            maxVoltageLabel.text = String.Format("{0:F2}", initVoltage);

            sinBtn.onClick.AddListener(SinClick);
            rectBtn.onClick.AddListener(RectClick);
            maxVoltageSlider.onValueChanged.AddListener(MaxVoltageHandle);
            frequencySlider.onValueChanged.AddListener(FrequencyHandle);
        }

        private void FrequencyHandle(float value)
        {
            var device = gameEntity.Device.instance as FunctionGeneratorDevice;

            frequencyLabel.text = String.Format("{0:F2}", value);
            device.Frequency = value;
        }

        private void MaxVoltageHandle(float value)
        {
            var device = gameEntity.Device.instance as FunctionGeneratorDevice;

            maxVoltageLabel.text = String.Format("{0:F2}", value);
            device.Voltage = value;
        }

        private void SinClick()
        {
            var device = gameEntity.Device.instance as FunctionGeneratorDevice;
            device.Waveform = SharpCircuit.Voltage.WaveType.AC;

            sinBtn.interactable = false;
            rectBtn.interactable = true;
        }

        private void RectClick()
        {
            var device = gameEntity.Device.instance as FunctionGeneratorDevice;
            device.Waveform = SharpCircuit.Voltage.WaveType.SQUARE;

            sinBtn.interactable = true;
            rectBtn.interactable = false;
        }

        protected override void OnClosed()
        {
            sinBtn.onClick.RemoveListener(SinClick);
            rectBtn.onClick.RemoveListener(RectClick);
            maxVoltageSlider.onValueChanged.RemoveListener(MaxVoltageHandle);
            frequencySlider.onValueChanged.RemoveListener(FrequencyHandle);
        }
    }
}