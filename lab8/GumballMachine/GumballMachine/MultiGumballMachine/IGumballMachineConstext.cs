using GumballMachine.Utils;

namespace GumballMachine.MultiGumballMachine
{
    public interface IGumballMachineConstext : IGumballMachine
    {
        void ReleaseBall();
        void AddBalls( uint count );
        uint GetBallsCount();
        void Dispense();

        void SetSoldOutState();
        void SetNoQuarterState();
        void SetSoldState();
        void SetHasQuarterState();

        QuarterCounter QuarterCounter { get; }
    }
}
