using Laboratories.Devices;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Laboratories
{
    public class FunctionGeneratorSettingsPanel : DeviceSettingsPanel
    {
        [SerializeField] private Button sinBtn;
        [SerializeField] private Button rectBtn;
        [SerializeField] private Slider maxVoltageSlider;
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

            sinBtn.onClick.AddListener(SinClick);
            rectBtn.onClick.AddListener(RectClick);
            maxVoltageSlider.onValueChanged.AddListener(MaxVoltageHandle);
            frequencySlider.onValueChanged.AddListener(FrequencyHandle);
        }

        private void FrequencyHandle(float value)
        {
            var device = gameEntity.Device.instance as FunctionGeneratorDevice;
            device.Frequency = value;
        }

        private void MaxVoltageHandle(float value)
        {
            var device = gameEntity.Device.instance as FunctionGeneratorDevice;
            device.Voltage = value;
        }

        private void SinClick()
        {
            var device = gameEntity.Device.instance as FunctionGeneratorDevice;
            device.Waveform = SharpCircuit.Voltage.WaveType.AC;
        }

        private void RectClick()
        {
            var device = gameEntity.Device.instance as FunctionGeneratorDevice;
            device.Waveform = SharpCircuit.Voltage.WaveType.SQUARE;
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