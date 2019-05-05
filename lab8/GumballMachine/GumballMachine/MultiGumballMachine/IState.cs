namespace GumballMachine.MultiGumballMachine
{
    public interface IState
    {
        void InsertQuarter();
        void EjectQuarter();
        void TurnCrank();
        void Dispense();
        void ReFill( uint count );
        string ToString();
    }
}
