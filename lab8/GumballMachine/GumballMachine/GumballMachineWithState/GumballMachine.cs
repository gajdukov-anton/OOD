using System.IO;

namespace GumballMachine.GumballMachineWithState
{
    public class GumballMachine : IGumballMachine
    {
        private IGumballMachineConstext _gumballMachineConstext;

        public GumballMachine( uint numBalls, TextWriter textWriter )
        {
            _gumballMachineConstext = new GumballMachineContext( numBalls, textWriter );
        }

        public void EjectQuarter()
        {
            _gumballMachineConstext.EjectQuarter();
        }

        public void InsertQuarter()
        {
            _gumballMachineConstext.InsertQuarter();
        }

        public void TurnCrank()
        {
            _gumballMachineConstext.TurnCrank();
        }

        public override string ToString()
        {
            return _gumballMachineConstext.ToString();
        }
    }
}
