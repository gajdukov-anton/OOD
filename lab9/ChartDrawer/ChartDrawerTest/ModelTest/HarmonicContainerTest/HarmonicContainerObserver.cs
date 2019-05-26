using ChartDrawer.Model;

namespace ChartDrawerTest.ModelTest.HarmonicContainerTest
{
    public class HarmonicContainerObserver : IHarmonicContainerObserver
    {
        public bool WasAdding { get; set; }
        public bool WasRemoving { get; set; }
        public int Index { get; set; }

        public HarmonicContainerObserver()
        {
            WasAdding = false;
            WasRemoving = false;
            Index = 0;
        }

        public void AddedNewHarmonic( int index )
        {
            WasAdding = true;
            Index = index;
        }

        public void RemovedHarmonic( int index )
        {
            WasRemoving = true;
            Index = index;
        }
    }
}
