using GumballMachine.Utils;
using System;
using System.IO;

namespace GumballMachine.MultiGumballMachine
{
    public class SoldState : IState
    {
        private IGumballMachine _gumballMachine;
        private TextWriter _textWriter;

        public SoldState( IGumballMachine gumballMachine, TextWriter textWriter )
        {
            _gumballMachine = gumballMachine;
            _textWriter = textWriter;
        }

        public void InsertQuarter()
        {
            _textWriter.WriteLine( BaseConstants.INSERT_QUARTER_SOLD_STATE );
        }

        public void EjectQuarter()
        {
            _textWriter.WriteLine( BaseConstants.EJECT_QUARTER_SOLD_STATE );
        }

        public void TurnCrank()
        {
            _textWriter.WriteLine( BaseConstants.TURN_CRANK_SOLD_STATE );
        }

        public void Dispense()
        {
            _gumballMachine.ReleaseBall();
            if ( _gumballMachine.GetBallsCount() == 0 )
            {
                _textWriter.WriteLine( BaseConstants.DISPENSE_SOLD_STATE );
                _gumballMachine.SetSoldOutState();
            }
            else if (!_gumballMachine.QuarterCounter.IsEmptyCounter() )
            {
                _gumballMachine.SetHasQuarterState();
            }
            else
            {
                _gumballMachine.SetNoQuarterState();
            }
        }

        public void ReFill( uint count )
        {
            _textWriter.WriteLine( MultiGumbalMachineConstants.REFILL_SOLD_STATE );
        }

        public override string ToString()
        {
            return BaseConstants.TO_STRING_SOLD_STATE;
        }
    }
}
