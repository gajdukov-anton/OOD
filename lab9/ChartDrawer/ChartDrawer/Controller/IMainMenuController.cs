using ChartDrawer.Model;

namespace ChartDrawer.Controller
{
    public interface IMainMenuController
    {
        void RemoveHarmonic( int index );
        void SetNewAmplitude( int index, double value );
        void SetNewFrequency( int index, double value );
        void SetNewPhase( int index, double value );
        void SetNewHarmonicKind( int index, HarmonicKind value );
        IAddingNewHarmonicController GetAddingNewHarmonicController();
    }
}
