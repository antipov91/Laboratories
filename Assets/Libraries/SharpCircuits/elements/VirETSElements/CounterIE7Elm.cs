using System;

namespace SharpCircuit
{
    public class CounterIE7Elm : Chip
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

        private byte value;

        private bool lastSubClock = false;

        public CounterIE7Elm()
        {
            bits = 6;
        }

        public override bool needsBits()
        {
            return true;
        }

        public override String getChipName()
        {
            return "CounterIE7";
        }

        public override void setupPins()
        {
            pins = new Pin[getLeadCount()];

            pins[0] = new Pin("D1");
            pins[1] = new Pin("D2");
            pins[2] = new Pin("D4");
            pins[3] = new Pin("D8");

            pins[4] = new Pin("C");

            pins[5] = new Pin("Add");
            pins[6] = new Pin("Sub");

            pins[7] = new Pin("R");

            for (int i = 8; i < 12; i++)
            {
                pins[i] = new Pin("Q" + i);
                pins[i].output = true;
            }

            pins[12] = new Pin(">15");
            pins[12].output = true;
            pins[13] = new Pin("<0");
            pins[13].output = true;

            allocLeads();
        }

        public override int getLeadCount()
        {
            return 14;
        }

        public override int getVoltageSourceCount()
        {
            return bits;
        }

        public override void execute(Circuit sim)
        {
            if (pins[5].value && !lastClock)
                Add();

            if (pins[6].value && !lastSubClock)
                Sub();

            if (!pins[4].value)
                ParallelLoading();

            if (pins[7].value)
                Reset();

            lastClock = pins[5].value;
            lastSubClock = pins[6].value;
        }


        private void Add()
        {
            value += 1;
            if (value > 15)
                value = 0;

            UpdateOutputs();
        }

        private void Sub()
        {
            value -= 1;
            if (value > 15)
                value = 15;
            UpdateOutputs();
        }

        private void ParallelLoading()
        {
            value = 0;
            if (pins[0].value) value += 1;
            if (pins[1].value) value += 2;
            if (pins[2].value) value += 4;
            if (pins[3].value) value += 8;

            UpdateOutputs();
        }

        private void Reset()
        {
            value = 0;
            UpdateOutputs();

            pins[13].value = pins[6].value;
        }

        private void UpdateOutputs()
        {
            pins[8].value = (value & 0x01) != 0;
            pins[9].value = (value & 0x02) != 0;
            pins[10].value = (value & 0x04) != 0;
            pins[11].value = (value & 0x08) != 0;
            
            pins[12].value = (value == 15 && pins[5].value && !lastClock) ? false : true;
            pins[13].value = (value == 0 && pins[6].value && !lastSubClock) ? false : true;
        }
    }
}