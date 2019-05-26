namespace ChartDrawer.Model
{
    public interface IHarmonicContainerObserver
    {
        void AddedNewHarmonic( int index );
        void RemovedHarmonic( int index );
    }
}
