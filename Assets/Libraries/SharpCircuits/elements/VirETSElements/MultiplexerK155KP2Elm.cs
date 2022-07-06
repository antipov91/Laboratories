using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SharpCircuit
{
    public class MultiplexerK155KP2Elm : Chip
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

        public MultiplexerK155KP2Elm()
        {
            bits = 2;
        }

        public override bool needsBits()
        {
            return true;
        }

        public override String getChipName()
        {
            return "MultiplexerK155KP2";
        }

        public override void setupPins()
        {
            pins = new Pin[getLeadCount()];
            pins[0] = new Pin("A0");
            pins[1] = new Pin("A1");
            pins[2] = new Pin("A2");
            pins[3] = new Pin("A3");
            pins[4] = new Pin("V1");

            pins[5] = new Pin("D0");
            pins[6] = new Pin("D1");
            pins[7] = new Pin("D2");
            pins[8] = new Pin("D3");
            pins[9] = new Pin("V2");

            pins[10] = new Pin("S1");
            pins[11] = new Pin("S2");

            pins[12] = new Pin("Q");
            pins[12].output = true;
            pins[13] = new Pin("NQ");
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
            bool q = false;

            if (pins[4].value == false || pins[9].value == false)
            {
                if (pins[4].value == true)
                    q = pins[0 + GetIndex()].value;

                if (pins[9].value == true)
                    q = pins[5 + GetIndex()].value;
            }

            pins[12].value = q;
            pins[13].value = !q;
        }

        private int GetIndex()
        {
            int index = 0;
            if (pins[10].value) index += 1;
            if (pins[11].value) index += 2;
            return index;
        }
    }
}