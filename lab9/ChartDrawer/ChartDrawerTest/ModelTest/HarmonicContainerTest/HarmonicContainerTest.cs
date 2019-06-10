using ChartDrawer.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChartDrawerTest.ModelTest.HarmonicContainerTest
{
    [TestClass]
    public class HarmonicContainerTest
    {
        [TestMethod]
        public void AddHarmonic_ObserverRelevantPropertiesChangedAfterAddingHarmonic()
        {
            IHarmonicContainer harmonicContainer = new HarmonicContainer();
            var observer = new HarmonicContainerObserver();

            harmonicContainer.AddObserver( observer );
            harmonicContainer.AddHarmonic( new Harmonic() );

            Assert.AreEqual( 0, observer.Index );
            Assert.IsTrue( observer.WasAdding );
        }

        [TestMethod]
        public void AddHarmonic_IncreaseAmountHarmonicAfterAddingHarmonicWithNullObserver()
        {
            IHarmonicContainer harmonicContainer = new HarmonicContainer();
            harmonicContainer.AddHarmonic( new Harmonic() );
            harmonicContainer.AddHarmonic( new Harmonic() );
            var harmonics = harmonicContainer.GetAllHarmonic();

            Assert.AreEqual( 2, harmonics.Count );
        }

        [TestMethod]
        public void RemoveHarmonic_ObserverRelevantPropertiesChangedAfterRemovingHarmonic()
        {
            IHarmonicContainer harmonicContainer = new HarmonicContainer();
            var observer = new HarmonicContainerObserver();

            harmonicContainer.AddObserver( observer );
            harmonicContainer.AddHarmonic( new Harmonic() );
            harmonicContainer.AddHarmonic( new Harmonic() );
            harmonicContainer.AddHarmonic( new Harmonic() );
            harmonicContainer.RemoveHarmonic( 1 ); 

            Assert.AreEqual( 1, observer.Index );
            Assert.IsTrue( observer.WasRemoving );
        }

        [TestMethod]
        public void RemoveHarmonic_DecreaseAmountHarmonicAfterRemovingHarmonicWithNullObserver()
        {
            IHarmonicContainer harmonicContainer = new HarmonicContainer();
            harmonicContainer.AddHarmonic( new Harmonic() );
            harmonicContainer.AddHarmonic( new Harmonic() );

            var harmonics = harmonicContainer.GetAllHarmonic();
            Assert.AreEqual( 2, harmonics.Count );

            harmonicContainer.RemoveHarmonic( 1 );
            harmonics = harmonicContainer.GetAllHarmonic();
            Assert.AreEqual( 1, harmonics.Count );
        }

        [TestMethod]
        public void RemoveHarmonic_ZeroHarmonicAfterRemovingHarmonicWithoutHarmonic()
        {
            IHarmonicContainer harmonicContainer = new HarmonicContainer();
            harmonicContainer.RemoveHarmonic( 1 );
            var harmonics = harmonicContainer.GetAllHarmonic();
            Assert.AreEqual( 0, harmonics.Count );
        }
    }
}
