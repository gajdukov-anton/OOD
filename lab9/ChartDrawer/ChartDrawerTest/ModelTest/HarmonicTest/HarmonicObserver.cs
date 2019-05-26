using ChartDrawer.Model;

namespace ChartDrawerTest.ModelTest.HarmonicTest
{
    public class HarmonicObserver : IHarmonicObserver
    {
        public bool PropertiesChanged { get; set; }

        public HarmonicObserver()
        {
            PropertiesChanged = false;
        }

        public void HarmonicPropertiesChanged()
        {
            PropertiesChanged = true;
        }
    }
}
