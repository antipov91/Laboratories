namespace SharpCircuit
{
    public class DecoderElm : Chip
    {
        public override void setupPins()
        {
            pins = new Pin[getLeadCount()];

            pins[0] = new Pin("D1");
            pins[1] = new Pin("D2");
            pins[2] = new Pin("D3");
            pins[3] = new Pin("D4");

            pins[4] = new Pin("0");
            pins[4].output = true;
            pins[5] = new Pin("1");
            pins[5].output = true;
            pins[6] = new Pin("2");
            pins[6].output = true;
            pins[7] = new Pin("3");
            pins[7].output = true;
            pins[8] = new Pin("4");
            pins[8].output = true;
            pins[9] = new Pin("5");
            pins[9].output = true;
            pins[10] = new Pin("6");
            pins[10].output = true;
            pins[11] = new Pin("7");
            pins[11].output = true;
            pins[12] = new Pin("8");
            pins[12].output = true;
            pins[13] = new Pin("9");
            pins[13].output = true;
        }

        public override int getLeadCount()
        {
            return 14;
        }

        public override int getVoltageSourceCount()
        {
            return 10;
        }

        public override void execute(Circuit sim)
        {
            int input = 0;
            if (pins[0].value) input += 1;
            if (pins[1].value) input += 2;
            if (pins[2].value) input += 4;
            if (pins[3].value) input += 8;

            for (int i = 0; i < 10; i++)
                pins[i + 4].value = true;

            if (input < 10)
                pins[input + 4].value = false;
        }
    }
}