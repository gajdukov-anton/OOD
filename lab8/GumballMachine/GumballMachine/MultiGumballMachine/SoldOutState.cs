using GumballMachine.Utils;
using System.IO;

namespace GumballMachine.MultiGumballMachine
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
            if ( !_gumballMachine.QuarterCounter.IsEmptyCounter() )
            {
                _textWriter.WriteLine( MultiGumbalMachineConstants.GetEjectQuarterSoldOutStateConst( _gumballMachine.QuarterCounter.QuarterAmount ) );
                _gumballMachine.QuarterCounter.Zeroize();
            }
            else
            {
                _textWriter.WriteLine( BaseConstants.EJECT_QUARTER_SOLD_OUT_STATE );
            }
        }

        public void TurnCrank()
        {
            _textWriter.WriteLine( BaseConstants.TURN_CRANK_SOLD_OUT_STATE );
        }

        public void Dispense()
        {
            _textWriter.WriteLine( BaseConstants.DISPENSE_SOLD_OUT_STATE );
        }

        public void ReFill( uint count )
        {
            _gumballMachine.AddBalls( count );
            _textWriter.WriteLine( MultiGumbalMachineConstants.GetReFillSoldOutStateConst( _gumballMachine.GetBallsCount() ) );
            if ( _gumballMachine.GetBallsCount() > 0 )
            {
                if ( !_gumballMachine.QuarterCounter.IsEmptyCounter() )
                {
                    _gumballMachine.SetHasQuarterState();
                }
                else
                {
                    _gumballMachine.SetNoQuarterState();
                }
            }
        }

        public override string ToString()
        {
            return BaseConstants.TO_STRING_SOLD_OUT_STATE;
        }
    }
}
