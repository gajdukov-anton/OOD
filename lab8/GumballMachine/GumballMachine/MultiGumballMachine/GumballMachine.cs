using GumballMachine.Utils;
using System.IO;

namespace GumballMachine.MultiGumballMachine
{
    public class GumballMachine : IGumballMachine
    {
        public QuarterCounter QuarterCounter { get; private set; }

        private uint _count;
        private IState _state;
        private TextWriter _textWriter;
        private readonly SoldOutState _soldOutState;
        private readonly SoldState _soldState;
        private readonly NoQuarterState _noQuarterState;
        private readonly HasQuarterState _hasQuarterState;

        public GumballMachine( uint numBalls, TextWriter textWriter )
        {
            _count = numBalls;
            _textWriter = textWriter;
            _soldOutState = new SoldOutState( this, _textWriter );
            _soldState = new SoldState( this, _textWriter );
            _noQuarterState = new NoQuarterState( this, _textWriter );
            _hasQuarterState = new HasQuarterState( this, _textWriter );
            QuarterCounter = new QuarterCounter();
            _state = _count > 0 ? ( IState ) _noQuarterState : _soldOutState;
        }

        public void EjectQuarter()
        {
            _state.EjectQuarter();
        }

        public void InsertQuarter()
        {
            _state.InsertQuarter();
        }

        public void TurnCrank()
        {
            _state.TurnCrank();
            _state.Dispense();
        }

        public void ReFill( uint count )
        {
            _state.ReFill( count );
        }

        public override string ToString()
        {
            var fmt = $"(Mighty Gumball, Inc.C# - enabled Standing Gumball Model #2019 (with state)Inventory:" +
                $" { GetBallsCount() } gumball{ ( GetBallsCount() != 1 ? "s" : "" ) }" +
                $" { QuarterCounter.QuarterAmount } quarter{ ( QuarterCounter.QuarterAmount != 1 ? "s" : "" ) } " +
                $"Machine is { _state.ToString() })";

            return fmt;
        }

        public uint GetBallsCount()
        {
            return _count;
        }

        public void ReleaseBall()
        {
            if ( _count != 0 )
            {
                _textWriter.WriteLine( BaseConstants.RELEASE_BALL );
                --_count;
            }
        }

        public void AddBalls( uint count )
        {
            _count += count;
        }

        public void SetSoldOutState()
        {
            _state = _soldOutState;
        }

        public void SetNoQuarterState()
        {
            _state = _noQuarterState;
        }

        public void SetSoldState()
        {
            _state = _soldState;
        }

        public void SetHasQuarterState()
        {
            _state = _hasQuarterState;
        }
    }
}
