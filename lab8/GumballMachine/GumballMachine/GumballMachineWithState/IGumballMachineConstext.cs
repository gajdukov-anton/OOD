namespace GumballMachine.GumballMachineWithState
{
    public interface IGumballMachineConstext : IGumballMachine
    {
        void ReleaseBall();
        uint GetBallsCount();
        void Dispense();

        void SetSoldOutState();
        void SetNoQuarterState();
        void SetSoldState();
        void SetHasQuarterState();
    }
}
