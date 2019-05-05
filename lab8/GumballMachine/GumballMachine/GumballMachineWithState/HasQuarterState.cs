using GumballMachine.Utils;
using System;
using System.IO;

namespace GumballMachine.GumbalMachineWithState
{
    public class HasQuarterState : IState
    {
        private IGumballMachine _gumballMachine;
        private TextWriter _textWriter;

        public HasQuarterState( IGumballMachine gumballMachine, TextWriter textWriter )
        {
            _gumballMachine = gumballMachine;
            _textWriter = textWriter;
        }

        public void InsertQuarter()
        {
            _textWriter.WriteLine( BaseConstants.INSERT_QUARTER_HAS_QUARTER_STATE );
        }

        public void EjectQuarter()
        {
            _textWriter.WriteLine( BaseConstants.EJECT_QUARTER_HAS_QUARTER_STATE );
            _gumballMachine.SetNoQuarterState();
        }

        public void TurnCrank()
        {
            _textWriter.WriteLine( BaseConstants.TURN_CRANK_HAS_QUARTER_STATE );
            _gumballMachine.SetSoldState();
        }

        public void Dispense()
        {
            _textWriter.WriteLine( BaseConstants.DISPENSE_HAS_QUARTER_STATE );
        }

        public override string ToString()
        {
            return BaseConstants.TO_STRING_HAS_QUARTER_STATE;
        }
    }
}
