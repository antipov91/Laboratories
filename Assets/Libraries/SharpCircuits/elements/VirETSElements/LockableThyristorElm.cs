using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SharpCircuit
{
    public class LockableThyristorElm : CircuitElement
    {
        // ThyristorElm
        // 3 nodes
        // 0 = anode, 1 = cathode, 2 = gate
        // 0, 2 = variable resistor
        // 2, 1 = 50 ohm resistor

        protected static readonly int anode = 0;
        protected static readonly int cnode = 1;
        protected static readonly int gnode = 2;

        public Circuit.Lead leadIn { get { return lead0; } }
        public Circuit.Lead leadOut { get { return lead1; } }
        public Circuit.Lead leadGate { get { return new Circuit.Lead(this, 2); } }

        /// <summary>
        /// Gate-Cathode Resistance (ohms)
        /// </summary>
        public double cresistance { get; set; }

        /// <summary>
        /// Trigger Current (A)
        /// </summary>
        public double triggerI { get; set; }

        /// <summary>
        /// Holding Current (A)
        /// </summary>
        public double holdingI { get; set; }

        protected double ic;
        protected double aresistance;
        protected bool state;

        public LockableThyristorElm() : base()
        {
            aresistance = 10e5;
            cresistance = 50;
            holdingI = 0.0082;
            triggerI = 0.01;
        }

        public override bool nonLinear() { return true; }

        public override void reset()
        {
            lead_volt[anode] = lead_volt[cnode] = lead_volt[gnode] = 0;
        }

        public override int getLeadCount()
        {
            return 3;
        }

        public override void stamp(Circuit sim)
        {
            sim.stampNonLinear(lead_node[anode]);
            sim.stampNonLinear(lead_node[cnode]);
            sim.stampNonLinear(lead_node[gnode]);
            sim.stampResistor(lead_node[gnode], lead_node[cnode], cresistance);
            sim.stampResistor(lead_node[anode], lead_node[gnode], aresistance);
        }
        
        public override void step(Circuit sim)
        {
            if (-ic < holdingI)
                state = false;
            if (-ic > triggerI && lead_volt[anode] - lead_volt[cnode] > 0)
                state = true;

            aresistance = state ? 10 : 10E5;
            sim.stampResistor(lead_node[anode], lead_node[gnode], aresistance);
            sim.needAnalyze();
        }

        public override void calculateCurrent()
        {
            ic = (lead_volt[cnode] - lead_volt[gnode]) / cresistance;
        }
    }
}