using GumballMachine.Utils;
using System;
using System.IO;

namespace GumballMachine.GumballMachineWithState
{
    public class SoldState : IState
    {
        private IGumballMachineConstext _gumballMachine;
        private TextWriter _textWriter;

        public SoldState( IGumballMachineConstext gumballMachine, TextWriter textWriter )
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
            else
            {
                _gumballMachine.SetNoQuarterState();
            }
        }

        public override string ToString()
        {
            return BaseConstants.TO_STRING_SOLD_STATE;
        }
    }
}
