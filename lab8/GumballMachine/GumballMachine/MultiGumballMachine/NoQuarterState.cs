using GumballMachine.Utils;
using System;
using System.IO;

namespace GumballMachine.MultiGumballMachine
{
    public class NoQuarterState : IState
    {
        private IGumballMachineConstext _gumballMachine;
        private TextWriter _textWriter;

        public NoQuarterState( IGumballMachineConstext gumballMachine, TextWriter textWriter )
        {
            _gumballMachine = gumballMachine;
            _textWriter = textWriter;
        }

        public void InsertQuarter()
        {
            _textWriter.WriteLine( BaseConstants.INSERT_QUARTER_NO_QUARTER_STATE );
            _gumballMachine.QuarterCounter.Inc();
            _gumballMachine.SetHasQuarterState();
        }

        public void EjectQuarter()
        {
            _textWriter.WriteLine( BaseConstants.EJECT_QUARTER_NO_QUARTER_STATE );
        }

        public void TurnCrank()
        {
            _textWriter.WriteLine( BaseConstants.TURN_CRANK_NO_QUARTER_STATE );
        }

        public void Dispense()
        {
            _textWriter.WriteLine( BaseConstants.DISPENSE_NO_QUARTER_STATE );
        }

        public void ReFill( uint count )
        {
            _textWriter.WriteLine( MultiGumbalMachineConstants.REFILL_NO_QUARTER_STATE );
        }

        public override string ToString()
        {
            return BaseConstants.TO_STRING_NO_QUARTER_STATE;
        }
    }
}
