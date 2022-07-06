using System.Collections;
using System.Collections.Generic;

namespace SharpCircuit
{
    public class DiodSchottkyElm : DiodeElm
    {
        public DiodSchottkyElm() : base()
        {
            forwardDrop = 0.4f;
        }
    }
}