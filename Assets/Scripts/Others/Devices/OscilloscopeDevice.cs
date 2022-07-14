using SharpCircuit;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Laboratories.Devices
{
    public class OscilloscopeDevice : MonoDevice
    {
        public int countGridVerLines = 10;
        public int countGridHorLines = 10;

        [Header("UI")]
        [SerializeField] private SpriteRenderer display;
        [SerializeField] private TextMeshPro voltDivLabel;
        [SerializeField] private TextMeshPro timeDivLabel;

        [Header("Settings")]
        [SerializeField] private UnityPlot.Plot plot;

        private CircuitEntity elmCircuit;
        private CircuitEntity secondElmCircuit;

        private OscilloscopeChannel secondChannel;
        private OscilloscopeChannel firstChannel;

        private string newVoltDiv;
        private string newTimeDiv;
        private float previouseTimeWindow = 16e-04f;

        public override void Initialize()
        {
            plot.AutoScale = false;
            plot.Boundary = new Rect(0f, -0.5f, 1f, 1f);
            plot.GridStep = new Vector2(1f / countGridVerLines, 1f / countGridHorLines);
        }

        public override void InitializeCircuit()
        {
            firstChannel = new OscilloscopeChannel(plot, Color.yellow);
            secondChannel = new OscilloscopeChannel(plot, Color.red);

            elmCircuit = deviceContext.Create(new Resistor(1e6), joints.Create("in"), joints.Create("out"));
            secondElmCircuit = deviceContext.Create(new Resistor(1e6), joints.Create("sin"), joints.Create("sout"));

            plot.Redraw();

            voltDivLabel.text = "500 ìÂ";
            newVoltDiv = "500 ìÂ";
            timeDivLabel.text = "80 ìêñ";
            newTimeDiv = "80 ìêñ";

            display.gameObject.SetActive(false);
        }

        public void SetValueScaleCh1(float scale)
        {
            firstChannel.ValueScale = scale;
        }

        public void SetValueScaleCh2(float scale)
        {
            secondChannel.ValueScale = scale;
        }

        public void SetTimeScale(float scale)
        {
            firstChannel.TimeScale = scale;
            secondChannel.TimeScale = scale;
        }

        public void SetValueOffset(float offset)
        {
            firstChannel.ValueOffset = offset;
            secondChannel.ValueOffset = offset;
        }

        public void SetTimeOffset(float offset)
        {
            firstChannel.TimeShift = offset;
            secondChannel.TimeShift = offset;
        }

        public void SetTimeWindow(float value)
        {
            elmCircuit.ScopeSignal.timeWindow = value;
            secondElmCircuit.ScopeSignal.timeWindow = value;
        }

        public void SetValueLabel(string text)
        {
            newVoltDiv = text;
        }

        public void SetTimeLabel(string text)
        {
            newTimeDiv = text;
        }

        protected override void OnDeviceState(bool isActive)
        {
            if (isActive)
            {
                firstChannel.Reset();
                secondChannel.Reset();
                firstChannel.IsRunning = true;
                secondChannel.IsRunning = true;

                secondElmCircuit.ReplaceScopeSignal(previouseTimeWindow, new Queue<SignalFrame>(), 0f);
                elmCircuit.ReplaceScopeSignal(previouseTimeWindow, new Queue<SignalFrame>(), 0f);

                display.gameObject.SetActive(true);
            }
            else if (elmCircuit.HasScopeSignal)
            {
                firstChannel.IsRunning = false;
                secondChannel.IsRunning = false;
                previouseTimeWindow = elmCircuit.ScopeSignal.timeWindow;

                elmCircuit.RemoveScopeSignal();
                secondElmCircuit.RemoveScopeSignal();

                display.gameObject.SetActive(false);
            }
        }

        protected override void OnProcess()
        {
            if (elmCircuit.HasScopeSignalResult || secondElmCircuit.HasScopeSignalResult)
            {
                if (elmCircuit.HasScopeSignalResult)
                    firstChannel.Update(elmCircuit.ScopeSignalResult.values);

                if (secondElmCircuit.HasScopeSignalResult)
                    secondChannel.Update(secondElmCircuit.ScopeSignalResult.values);

                voltDivLabel.text = newVoltDiv;
                timeDivLabel.text = newTimeDiv;
            }
        }
    }
}