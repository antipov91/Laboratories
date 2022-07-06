namespace SharpCircuit
{
    public class OptoelectronicElm : CircuitElement
    {
        public Circuit.Lead leadOut { get { return lead0; } }
        public Circuit.Lead leadIn { get { return lead1; } }

        private double resistance;

        public OptoelectronicElm() : base()
        {

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
            resistance = lead_node[0] - lead_node[1] > 0 ? 1e5f : 0.015f;
            sim.stampResistor(lead_node[0], lead_node[1], resistance);
        }
    }
}