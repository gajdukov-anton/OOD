using System;
using System.IO;

namespace GumballMachine.GumbalMachineWithState
{
    public class SoldOutState : IState
    {
        private IGumballMachine _gumballMachine;
        private TextWriter _textWriter;

        public SoldOutState( IGumballMachine gumballMachine, TextWriter textWriter )
        {
            _gumballMachine = gumballMachine;
            _textWriter = textWriter;
        }

        public void InsertQuarter()
        {
            _textWriter.WriteLine( Constants.INSERT_QUARTER_SOLD_OUT_STATE );
        }

        public void EjectQuarter()
        {
            _textWriter.WriteLine( Constants.EJECT_QUARTER_SOLD_OUT_STATE );
        }

        public void TurnCrank()
        {
            _textWriter.WriteLine( Constants.TURN_CRANK_SOLD_OUT_STATE );
        }

        public void Dispense()
        {
            _textWriter.WriteLine( Constants.DISPENSE_SOLD_OUT_STATE );
        }

        public override string ToString()
        {
            return Constants.TO_STRING_SOLD_OUT_STATE;
        }
    }
}
