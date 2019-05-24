using ChartDrawer.Model;

namespace ChartDrawer.Model
{
    public interface IHarmonicContainerObserver
    {
      //  void UpdateList( ContainerActionInfo harmonicChangesListData );
        void AddedNewHarmonic( int index );
        void RemovedHarmonic( int index );
    }
}
