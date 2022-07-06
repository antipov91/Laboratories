using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SharpCircuit
{
    public class SwitchElm : CircuitElement
    {
        public Circuit.Lead leadA { get { return lead0; } }
        public Circuit.Lead leadB { get { return lead1; } }

        public bool IsOn { get; private set; }
        private double resistance;

        public SwitchElm(bool isOn) : base()
        {
            IsOn = isOn;
        }

        public SwitchElm() : this(false) { }

        public void ToggleOn()
        {
            IsOn = true;
        }

        public void ToggleOff()
        {
            IsOn = false;
        }

        public void Toggle(bool isOn)
        {
            IsOn = isOn;
        }

        public override int getLeadCount()
        {
            return 2;
        }

        public override void calculateCurrent()
        {
            current = (lead_volt[0] - lead_volt[1]) / resistance;
        }

        public override void stamp(Circuit sim)
        {
            resistance = IsOn ? 0.015f : 1e20f;
            sim.stampResistor(lead_node[0], lead_node[1], resistance);
        }

        public override void step(Circuit sim)
        {
            resistance = IsOn ? 0.015f : 1e20f;
            sim.stampResistor(lead_node[0], lead_node[1], resistance);
        }
    }
}