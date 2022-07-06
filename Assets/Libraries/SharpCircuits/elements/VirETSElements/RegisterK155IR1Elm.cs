using System;
using System.Collections;
using System.Collections.Generic;

namespace SharpCircuit
{
    public class RegisterK155IR1Elm : Chip
    {
        public bool hasEnable
        {
            get
            {
                return _hasEnable;
            }
            set
            {
                _hasEnable = value;
                setupPins();
            }
        }

        public bool invertReset { get; set; }

        private bool _hasEnable;

        private bool clockC1 = false;
        private bool clockC2 = false;

        public RegisterK155IR1Elm()
        {
            bits = 4;
        }

        public override String getChipName()
        {
            return "Register K155IR1";
        }

        bool hasReset()
        {
            return false;
        }

        public override bool needsBits()
        {
            return true;
        }

        public override void setupPins()
        {
            pins = new Pin[getLeadCount()];
            for (int i = 0; i < 4; i++)
            {
                pins[i] = new Pin("Q" + i);
                pins[i].output = true;
            }
            pins[4] = new Pin("D0");
            pins[5] = new Pin("D1");
            pins[6] = new Pin("D2");
            pins[7] = new Pin("D3");

            pins[8] = new Pin("C1");
            pins[9] = new Pin("C2");

            pins[10] = new Pin("V1");
            pins[11] = new Pin("V2");

            allocLeads();
        }

        public override int getLeadCount()
        {
            return 12;
        }

        public override int getVoltageSourceCount()
        {
            return bits;
        }

        public override void execute(Circuit sim)
        {
            if (pins[11].value && !pins[9].value && clockC2)
                ParallelLoading();

            if (!pins[11].value && !pins[8].value && clockC1)
                RightShift();

            clockC1 = pins[8].value;
            clockC2 = pins[9].value;
        }

        private void ParallelLoading()
        {
            for (int i = 0; i < 4; i++)
                pins[i].value = pins[i + 4].value;
        }

        private void RightShift()
        {
            pins[4].value = pins[3].value;
            pins[3].value = pins[2].value;
            pins[2].value = pins[1].value;
            pins[1].value = pins[0].value;
            pins[0].value = pins[10].value;
        }
    }
}