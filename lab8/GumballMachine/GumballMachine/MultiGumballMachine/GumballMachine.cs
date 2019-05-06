using System.IO;

namespace GumballMachine.MultiGumballMachine
{
    public class GumballMachine : IGumballMachine
    {
        private IGumballMachineConstext _gumballMachineContext;

        public GumballMachine( uint numBalls, TextWriter textWriter )
        {
            _gumballMachineContext = new GumballMachineContext( numBalls, textWriter );
        }

        public void EjectQuarter()
        {
            _gumballMachineContext.EjectQuarter();
        }

        public void InsertQuarter()
        {
            _gumballMachineContext.InsertQuarter();
        }

        public void TurnCrank()
        {
            _gumballMachineContext.TurnCrank();
        }

        public void ReFill( uint count )
        {
            _gumballMachineContext.ReFill( count );
        }

        public override string ToString()
        {
            return _gumballMachineContext.ToString();
        }
    }
}
