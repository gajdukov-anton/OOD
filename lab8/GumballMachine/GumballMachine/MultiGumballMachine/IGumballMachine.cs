namespace GumballMachine.MultiGumballMachine
{
    public interface IGumballMachine
    {
        void InsertQuarter();
        void EjectQuarter();
        void TurnCrank();
        void ReFill( uint count );
    }
}
