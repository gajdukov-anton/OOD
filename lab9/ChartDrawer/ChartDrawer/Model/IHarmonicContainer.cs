using ChartDrawer.View;

namespace ChartDrawer.Model
{
    public interface IHarmonicContainer
    {
        void AddHarmonic( IHarmonic harmonic );
        void RemoveHarmonic( int index );
        int GetHarmonicCount();
        IHarmonic GetHarmonic( int index );
        IHarmonic[] GetAll();
        void RegisterObserver( IObserver observer );
        void RemoveObserver( int index );
        void NotifyViews( HarmonicsChangesDto harmonicsChangesDto );
    }
}
