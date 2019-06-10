namespace ChartDrawer.Model
{
    public interface IHarmonic : IHarmonicPresentation
    {
        void SetAmplitude( double amplitude );
        void SetFrequency( double frequency );
        void SetPhase( double phase );
        void SetHarmonicKind( HarmonicKind kind );
        void SetObserver( IHarmonicObserver harmonicObserver );
    }
}
