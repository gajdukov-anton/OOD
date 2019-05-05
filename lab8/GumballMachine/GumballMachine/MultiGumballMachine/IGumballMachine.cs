using GumballMachine.Utils;

namespace GumballMachine.MultiGumballMachine
{
    public interface IGumballMachine
    {
        void ReleaseBall();
        void AddBalls( uint count );
        uint GetBallsCount();

        void SetSoldOutState();
        void SetNoQuarterState();
        void SetSoldState();
        void SetHasQuarterState();

        QuarterCounter QuarterCounter { get; }
    }
}
