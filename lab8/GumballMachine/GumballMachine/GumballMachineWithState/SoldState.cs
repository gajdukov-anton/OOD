using System;
using System.IO;

namespace GumballMachine.GumbalMachineWithState
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
            _textWriter.WriteLine( Constants.INSERT_QUARTER_SOLD_STATE );
        }

        public void EjectQuarter()
        {
            _textWriter.WriteLine( Constants.EJECT_QUARTER_SOLD_STATE );
        }

        public void TurnCrank()
        {
            _textWriter.WriteLine( Constants.TURN_CRANK_SOLD_STATE );
        }

        public void Dispense()
        {
            _gumballMachine.ReleaseBall();
            if ( _gumballMachine.GetBallsCount() == 0 )
            {
                _textWriter.WriteLine( Constants.DISPENSE_SOLD_STATE );
                _gumballMachine.SetSoldOutState();
            }
            else
            {
                _gumballMachine.SetNoQuarterState();
            }
        }

        public override string ToString()
        {
            return Constants.TO_STRING_SOLD_STATE;
        }
    }
}
