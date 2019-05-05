using GumballMachine.Utils;
using System;
using System.IO;

namespace GumballMachine.NaiveGumballMachine
{
    public class GumballMachine
    {
        private uint _count;
        private QuarterCounter _quarterCounter;
        private State _state;
        private TextWriter _textWriter;

        public GumballMachine( uint count, TextWriter textWriter )
        {
            _count = count;
            _textWriter = textWriter;
            _quarterCounter = new QuarterCounter();
            _state = _count > 0 ? State.NoQuarter : State.SoldOut;
        }

        public void InsertQuarter()
        {
            switch ( _state )
            {
                case State.SoldOut:
                    _textWriter.WriteLine( BaseConstants.INSERT_QUARTER_SOLD_OUT_STATE );
                    break;
                case State.NoQuarter:
                    _textWriter.WriteLine( BaseConstants.INSERT_QUARTER_NO_QUARTER_STATE );
                    _quarterCounter.Inc();
                    _state = State.HasQuarter;
                    break;
                case State.HasQuarter:
                    if ( _quarterCounter.IsIncAvailable() )
                    {
                        _quarterCounter.Inc();
                        _textWriter.WriteLine( MultiGumbalMachineConstants.GetInsertQuarterHasQuarterStateConst( _quarterCounter.QuarterAmount ) );
                    }
                    else
                    {
                        _textWriter.WriteLine( MultiGumbalMachineConstants.INSERT_QUARTER_MAX_LIMIT_HAS_QUARTER_STATE );
                    }
                    break;
                case State.Sold:
                    _textWriter.WriteLine( BaseConstants.INSERT_QUARTER_SOLD_STATE );
                    break;
            }
        }

        public void EjectQuarter()
        {
            switch ( _state )
            {
                case State.SoldOut:
                    // _textWriter.WriteLine( BaseConstants.EJECT_QUARTER_SOLD_OUT_STATE );
                    if ( !_quarterCounter.IsEmptyCounter() )
                    {
                        _textWriter.WriteLine( MultiGumbalMachineConstants.GetEjectQuarterSoldOutStateConst( _quarterCounter.QuarterAmount ) );
                        _quarterCounter.Zeroize();
                    }
                    else
                    {
                        _textWriter.WriteLine( BaseConstants.EJECT_QUARTER_SOLD_OUT_STATE );
                    }
                    break;
                case State.NoQuarter:
                    _textWriter.WriteLine( BaseConstants.EJECT_QUARTER_NO_QUARTER_STATE );
                    break;
                case State.HasQuarter:
                    _textWriter.WriteLine( MultiGumbalMachineConstants.GetEjectQuarterHasQuarterStateConst( _quarterCounter.QuarterAmount ) );
                    _quarterCounter.Zeroize();
                    _state = State.NoQuarter;
                    break;
                case State.Sold:
                    _textWriter.WriteLine( BaseConstants.EJECT_QUARTER_SOLD_STATE );
                    break;
            }
        }

        public void TurnCrank()
        {
            switch ( _state )
            {
                case State.SoldOut:
                    _textWriter.WriteLine( BaseConstants.TURN_CRANK_SOLD_OUT_STATE );
                    break;
                case State.NoQuarter:
                    _textWriter.WriteLine( BaseConstants.TURN_CRANK_NO_QUARTER_STATE );
                    break;
                case State.HasQuarter:
                    _quarterCounter.Dec();
                    _textWriter.WriteLine( MultiGumbalMachineConstants.GetTurnCrankHasQuarterStateConst( _quarterCounter.QuarterAmount ) );
                    _state = State.Sold;
                    Dispense();
                    break;
                case State.Sold:
                    _textWriter.WriteLine( BaseConstants.TURN_CRANK_SOLD_STATE );
                    break;
            }
        }

        public void ReFill( uint numBalls )
        {
            switch ( _state )
            {
                case State.SoldOut:
                    _count = numBalls;
                    _textWriter.WriteLine( MultiGumbalMachineConstants.GetReFillSoldOutStateConst( _count ) );
                    _state = _count > 0
                        ? !_quarterCounter.IsEmptyCounter() ? State.HasQuarter : State.NoQuarter
                        : State.SoldOut;
                    break;
                case State.NoQuarter:
                    _textWriter.WriteLine( MultiGumbalMachineConstants.REFILL_NO_QUARTER_STATE );
                    break;
                case State.HasQuarter:
                    _textWriter.WriteLine( MultiGumbalMachineConstants.REFILL_HAS_QUARTER_STATE );
                    break;
                case State.Sold:
                    _textWriter.WriteLine( MultiGumbalMachineConstants.REFILL_SOLD_STATE );
                    break;
            }
        }

        public override string ToString()
        {
            string state =
            ( _state == State.SoldOut ) ? Constants.TO_STRING_SOLD_OUT_STATE :
            ( _state == State.NoQuarter ) ? Constants.TO_STRING_NO_QUARTER_STATE :
            ( _state == State.HasQuarter ) ? Constants.TO_STRING_HAS_QUARTER_STATE
                                           : Constants.TO_STRING_SOLD_STATE;

            var fmt = $"(Mighty Gumball, Inc.C# - enabled Standing Gumball Model #2019 (with state)Inventory:" +
                 $" { _count } gumball{ ( _count != 1 ? "s" : "" ) }" +
                 $" { _quarterCounter.QuarterAmount } quarter{ ( _quarterCounter.QuarterAmount != 1 ? "s" : "" ) } " +
                 $"Machine is { state })";

            return fmt;
        }

        private void Dispense()
        {
            switch ( _state )
            {
                case State.Sold:
                    if ( _count != 0 )
                    {
                        _textWriter.WriteLine( BaseConstants.RELEASE_BALL );
                        --_count;
                    }
                    if ( _count == 0 )
                    {
                        _textWriter.WriteLine( BaseConstants.DISPENSE_SOLD_STATE );
                        _state = State.SoldOut;
                    }
                    else if ( !_quarterCounter.IsEmptyCounter() )
                    {
                        _state = State.HasQuarter;
                    }
                    else
                    {
                        _state = State.NoQuarter;
                    }
                    break;
                case State.NoQuarter:
                    _textWriter.WriteLine( BaseConstants.DISPENSE_NO_QUARTER_STATE );
                    break;
                case State.SoldOut:
                case State.HasQuarter:
                    _textWriter.WriteLine( BaseConstants.DISPENSE_HAS_QUARTER_STATE );
                    break;
            }
        }
    }
}
