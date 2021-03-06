﻿using GumballMachine.Utils;
using System;
using System.IO;

namespace GumballMachine.GumballMachineWithState
{
    public class SoldOutState : IState
    {
        private IGumballMachineConstext _gumballMachine;
        private TextWriter _textWriter;

        public SoldOutState( IGumballMachineConstext gumballMachine, TextWriter textWriter )
        {
            _gumballMachine = gumballMachine;
            _textWriter = textWriter;
        }

        public void InsertQuarter()
        {
            _textWriter.WriteLine( BaseConstants.INSERT_QUARTER_SOLD_OUT_STATE );
        }

        public void EjectQuarter()
        {
            _textWriter.WriteLine( BaseConstants.EJECT_QUARTER_SOLD_OUT_STATE );
        }

        public void TurnCrank()
        {
            _textWriter.WriteLine( BaseConstants.TURN_CRANK_SOLD_OUT_STATE );
        }

        public void Dispense()
        {
            _textWriter.WriteLine( BaseConstants.DISPENSE_SOLD_OUT_STATE );
        }

        public override string ToString()
        {
            return BaseConstants.TO_STRING_SOLD_OUT_STATE;
        }
    }
}
