using System;

namespace SharpCircuit
{

    public class Thermistor : CircuitElement
    {
        public Circuit.Lead leadIn { get { return lead0; } }
        public Circuit.Lead leadOut { get { return lead1; } }

        double resistance;

        public override void calculateCurrent()
        {
            current = (lead_volt[0] - lead_volt[1]) / resistance;
        }

        public override void stamp(Circuit sim)
        {
            double voltdiff = lead_volt[0] - lead_volt[1];
            if (voltdiff < 2.044)
                resistance = voltdiff / (0.4f * (0.000163689059239025 + 0.130247342170174 * voltdiff + 0.548696644805302 * Math.Pow(voltdiff, 2) - 0.181050678733144 * Math.Pow(voltdiff, 3)));
            else
                resistance = voltdiff / (0.4f * (1.393529802 * Math.Pow(voltdiff, -0.446584552)));
            sim.stampResistor(lead_node[0], lead_node[1], resistance);
        }
    }
}