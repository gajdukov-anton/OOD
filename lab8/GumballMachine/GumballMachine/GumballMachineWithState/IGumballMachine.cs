namespace GumballMachine.GumbalMachineWithState
{
    public interface IGumballMachine
    {
        void ReleaseBall();
        uint GetBallsCount();

        void SetSoldOutState();
        void SetNoQuarterState();
        void SetSoldState();
        void SetHasQuarterState();
    }
}
