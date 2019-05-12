namespace ChartDrawer.Model
{
    public interface IHarmonicPresentation
    {
        double GetAmplitude();
        double GetFrequency();
        double GetPhase();
        HarmonicKind GetHarmonicKind();
    }
}
