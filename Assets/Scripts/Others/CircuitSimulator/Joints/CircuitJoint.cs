namespace Laboratories.ElectricalCircuit
{
    public class CircuitJoint : ICircuitJoint
    {
        public int Id { get; set; }

        private static int count = 0;

        public CircuitJoint()
        {
            Id = count;
            count++;
        }
    }
}