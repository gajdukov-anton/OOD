using System;
using System.IO;

namespace GumballMachine.GumbalMachineWithState
{
    public class NoQuarterState : IState
    {
        private IGumballMachine _gumballMachine;
        private TextWriter _textWriter;

        public NoQuarterState(IGumballMachine gumballMachine, TextWriter textWriter )
        {
            _gumballMachine = gumballMachine;
            _textWriter = textWriter;
        }

        public void InsertQuarter()
        {
            _textWriter.WriteLine( Constants.INSERT_QUARTER_NO_QUARTER_STATE );
            _gumballMachine.SetHasQuarterState();
        }

        public void EjectQuarter()
        {
            _textWriter.WriteLine( Constants.EJECT_QUARTER_NO_QUARTER_STATE );
        }

        public void TurnCrank()
        {
            _textWriter.WriteLine( Constants.TURN_CRANK_NO_QUARTER_STATE );
        }

        public void Dispense()
        {
            _textWriter.WriteLine( Constants.DISPENSE_NO_QUARTER_STATE );
        }

        public override string ToString()
        {
            return Constants.TO_STRING_NO_QUARTER_STATE;
        }
    }
}
