using Laboratories.Devices;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Laboratories
{
    public class OscilloscopeDeviceSettingsPanel : DeviceSettingsPanel
    {
        [Header("Settings")]
        [SerializeField] private string[] strPeriods = new string[] { "1s", "800ms", "400ms", "200ms", "80.0ms", "40.0ms", "20.0ms", "8.00ms", "4.00ms", "2.00ms", "800us", "400us", "200us", "80.0us" };
        [SerializeField] private float[] periods = new float[] { 1f, 0.8f, 0.4f, 0.2f, 0.08f, 0.04f, 0.02f, 0.008f, 0.004f, 0.002f, 0.0008f, 0.0004f, 0.0002f, 0.00008f };
        [SerializeField] private string[] strVoltsDiv = new string[] { "20.0V", "10.0V", "5.00V", "2.00V", "1.00V", "500mV", "200mV", "100mV", "50.0mV", "20.0mV" };
        [SerializeField] private float[] voltsRations = new float[] { 0.05f, 0.1f, 0.2f, 0.5f, 1f, 2f, 5f, 10f, 20f, 50f };

        [Header("Ui")]
        [SerializeField] private Text valueScaleCh1Label;
        [SerializeField] private Slider valueScaleCh1Slider;

        [SerializeField] private Text valueScaleCh2Label;
        [SerializeField] private Slider valueScaleCh2Slider;
        
        [SerializeField] private Text valueOffsetLabel;
        [SerializeField] private Slider valueOffsetSlider;

        [SerializeField] private Text timeScaleLabel;
        [SerializeField] private Slider timeScaleSlider;

        [SerializeField] private Text timeOffsetLabel;
        [SerializeField] private Slider timeOffsetSlider;

        private void Awake()
        {
            valueScaleCh1Slider.minValue = 0;
            valueScaleCh1Slider.maxValue = voltsRations.Length - 1;
            valueScaleCh1Slider.wholeNumbers = true;
            valueScaleCh1Slider.value = 4;

            valueScaleCh2Slider.minValue = 0;
            valueScaleCh2Slider.maxValue = voltsRations.Length - 1;
            valueScaleCh2Slider.wholeNumbers = true;
            valueScaleCh2Slider.value = 4;

            timeScaleSlider.minValue = 0;
            timeScaleSlider.maxValue = periods.Length - 1;
            timeScaleSlider.wholeNumbers = true;
            timeScaleSlider.value = 0;

            valueOffsetSlider.minValue = -0.5f;
            valueOffsetSlider.maxValue = 0.5f;

            timeOffsetSlider.minValue = -0.5f;
            timeOffsetSlider.maxValue = 0.5f;


            timeScaleLabel.text = strPeriods[(int)timeScaleSlider.value];
            valueScaleCh1Label.text = strVoltsDiv[(int)valueScaleCh1Slider.value];
            valueScaleCh2Label.text = strVoltsDiv[(int)valueScaleCh2Slider.value];
            timeOffsetLabel.text = string.Format("{0:F2}", 0f);
            valueOffsetLabel.text = string.Format("{0:F2}", 0f);
        }

        public override bool CheckCondition(Contexts contexts, GameEntity senderEntity)
        {
            var device = senderEntity.Device.instance;
            return device is OscilloscopeDevice;
        }

        protected override void OnInvoked()
        {
            var device = gameEntity.Device.instance as OscilloscopeDevice;

            valueScaleCh1Slider.onValueChanged.AddListener(ValueScaleCh1Changed);
            valueScaleCh2Slider.onValueChanged.AddListener(ValueScaleCh2Changed);
            valueOffsetSlider.onValueChanged.AddListener(ValueOffsetChanged);
            timeScaleSlider.onValueChanged.AddListener(TimeScaleChanged);
            timeOffsetSlider.onValueChanged.AddListener(TimeOffsetChanged);
        }

        private void TimeScaleChanged(float value)
        {
            var device = gameEntity.Device.instance as OscilloscopeDevice;

            timeScaleLabel.text = strPeriods[(int)timeScaleSlider.value];

            float timeScale = 1f / (device.countGridVerLines * periods[(int)timeScaleSlider.value]);
            device.SetTimeScale(timeScale);

            device.SetTimeWindow(2f * periods[(int)timeScaleSlider.value] * device.countGridVerLines);
            device.SetTimeLabel(strPeriods[(int)timeScaleSlider.value]);
        }

        private void TimeOffsetChanged(float value)
        {
            var device = gameEntity.Device.instance as OscilloscopeDevice;

            device.SetTimeOffset(value);
            timeOffsetLabel.text = string.Format("{0:F2}", value);
        }

        private void ValueOffsetChanged(float value)
        {
            var device = gameEntity.Device.instance as OscilloscopeDevice;

            device.SetValueOffset(value);
            valueOffsetLabel.text = string.Format("{0:F2}", value);
        }

        private void ValueScaleCh1Changed(float value)
        {
            var device = gameEntity.Device.instance as OscilloscopeDevice;

            var scale = voltsRations[(int)valueScaleCh1Slider.value] / device.countGridVerLines;
            device.SetValueScaleCh1(scale);

            valueScaleCh1Label.text = strVoltsDiv[(int)valueScaleCh1Slider.value];
            device.SetValueLabel(strVoltsDiv[(int)valueScaleCh1Slider.value]);
        }

        private void ValueScaleCh2Changed(float value)
        {
            var device = gameEntity.Device.instance as OscilloscopeDevice;

            var scale = voltsRations[(int)valueScaleCh2Slider.value] / device.countGridVerLines;
            device.SetValueScaleCh2(scale);

            valueScaleCh2Label.text = strVoltsDiv[(int)valueScaleCh2Slider.value];
            device.SetValueLabel(strVoltsDiv[(int)valueScaleCh2Slider.value]);
        }

        protected override void OnClosed()
        {
            valueScaleCh1Slider.onValueChanged.RemoveListener(ValueScaleCh1Changed);
            valueScaleCh2Slider.onValueChanged.RemoveListener(ValueScaleCh2Changed);
            valueOffsetSlider.onValueChanged.RemoveListener(ValueOffsetChanged);
            timeScaleSlider.onValueChanged.RemoveListener(TimeScaleChanged);
            timeOffsetSlider.onValueChanged.RemoveListener(TimeOffsetChanged);
        }
    }
}