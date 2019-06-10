namespace ChartDrawer.Model
{
    public interface IHarmonicContainerPresentation
    {
        IHarmonicPresentation[] GetAllPresentation();
        void AddObserver( IHarmonicContainerObserver observer );
    }
}
