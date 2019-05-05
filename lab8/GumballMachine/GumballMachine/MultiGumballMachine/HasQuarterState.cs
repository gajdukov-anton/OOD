using GumballMachine.Utils;
using System;
using System.IO;

namespace GumballMachine.MultiGumballMachine
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
            if ( _gumballMachine.QuarterCounter.IsIncAvailable() )
            {
                _gumballMachine.QuarterCounter.Inc();
                _textWriter.WriteLine( MultiGumbalMachineConstants.GetInsertQuarterHasQuarterStateConst( _gumballMachine.QuarterCounter.QuarterAmount ) );
            }
            else
            {
                _textWriter.WriteLine( MultiGumbalMachineConstants.INSERT_QUARTER_MAX_LIMIT_HAS_QUARTER_STATE );
            }
        }

        public void EjectQuarter()
        {
            _textWriter.WriteLine( MultiGumbalMachineConstants.GetEjectQuarterHasQuarterStateConst( _gumballMachine.QuarterCounter.QuarterAmount ) );
            _gumballMachine.QuarterCounter.Zeroize();
            _gumballMachine.SetNoQuarterState();
        }

        public void TurnCrank()
        {
            _gumballMachine.QuarterCounter.Dec();
            _gumballMachine.SetSoldState();
            _textWriter.WriteLine( MultiGumbalMachineConstants.GetTurnCrankHasQuarterStateConst( _gumballMachine.QuarterCounter.QuarterAmount ) );
        }

        public void Dispense()
        {
            _textWriter.WriteLine( BaseConstants.DISPENSE_HAS_QUARTER_STATE );
        }

        public void ReFill( uint count )
        {
            _textWriter.WriteLine( MultiGumbalMachineConstants.REFILL_HAS_QUARTER_STATE );
        }

        public override string ToString()
        {
            return BaseConstants.TO_STRING_HAS_QUARTER_STATE;
        }

    }
}
