namespace GumballMachine.GumbalMachineWithState
{
    public interface IState
    {
        void InsertQuarter();
        void EjectQuarter();
        void TurnCrank();
        void Dispense();
        string ToString();
    }
}
