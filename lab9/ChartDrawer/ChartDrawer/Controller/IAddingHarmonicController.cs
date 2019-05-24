using ChartDrawer.Model;

namespace ChartDrawer.Controller
{
    public interface IAddingHarmonicController
    {
        void Start();
        void SetAmplitude( double value );
        void SetHarmonicKind( HarmonicKind kind );
        void SetFrequency( double value );
        void SetPhase( double value );
        void AddNewHarmonic();
        void Cancel();
    }
}
