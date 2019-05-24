using ChartDrawer.Model;

namespace ChartDrawerTest.ModelTest
{
    public class HarmonicObserver : IHarmonicObserver
    {
        public bool UpdatedVizualization { get; set; }

        public HarmonicObserver()
        {
            UpdatedVizualization = false;
        }

        public void HarmonicPropertyChanged()
        {
            UpdatedVizualization = true;
        }
    }
}
