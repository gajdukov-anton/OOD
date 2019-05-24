using ChartDrawer.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChartDrawerTest.ModelTest
{
    [TestClass]
    public class HarmonicTest
    {
        [TestMethod]
        public void ObserverUpdateVizualizationAfterSetAmplitude()
        {
            var harmonic = new Harmonic();
            var harmonicObserver = new HarmonicObserver();

            harmonic.SetViewObserver( harmonicObserver );
            harmonic.SetAmplitude( 10 );

            Assert.IsTrue( harmonicObserver.UpdatedVizualization );
        }

        [TestMethod]
        public void ObserverUpdateVizualizationAfterSetFrequency()
        {
            var harmonic = new Harmonic();
            var harmonicObserver = new HarmonicObserver();

            harmonic.SetViewObserver( harmonicObserver );
            harmonic.SetFrequency( 10 );

            Assert.IsTrue( harmonicObserver.UpdatedVizualization );
        }

        [TestMethod]
        public void ObserverUpdateVizualizationAfterSetPhase()
        {
            var harmonic = new Harmonic();
            var harmonicObserver = new HarmonicObserver();

            harmonic.SetViewObserver( harmonicObserver );
            harmonic.SetPhase( 10 );

            Assert.IsTrue( harmonicObserver.UpdatedVizualization );
        }

        [TestMethod]
        public void ObserverUpdateVizualizationAfterSetHarmonicKind()
        {
            var harmonic = new Harmonic();
            var harmonicObserver = new HarmonicObserver();

            harmonic.SetViewObserver( harmonicObserver );
            harmonic.SetHarmonicKind( HarmonicKind.Sin );

            Assert.IsTrue( harmonicObserver.UpdatedVizualization );
        }

        [TestMethod]
        public void TestToStringValueAfterCreationHarmonic()
        {
            var harmonic = new Harmonic();

            //Assert.AreEqual( "1 * Cos(1 * x + 0)", harmonic.ToString() );
            Assert.AreEqual( "1*Sin(1*x+0)", harmonic.ToString() );
        }

        [TestMethod]
        public void TestToStringValueAfterChangeHarmonicProperties()
        {
            var harmonic = new Harmonic();

            harmonic.SetAmplitude( 10 );
            harmonic.SetFrequency( 2 );
            harmonic.SetPhase( 7 );
            harmonic.SetHarmonicKind( HarmonicKind.Cos );

         //   Assert.AreEqual( "10 * Cos(2 * x + 7)", harmonic.ToString() );
            Assert.AreEqual( "10*Cos(2*x+7)", harmonic.ToString() );
        }

        [TestMethod]
        public void TestChangePropertiesAfterSetNewValueByIHarmonicMethods()
        {
            IHarmonic harmonic = new Harmonic();
            var harmonicObserver = new HarmonicObserver();

            harmonic.SetViewObserver( harmonicObserver );
            harmonic.SetAmplitude( 10 );
            harmonic.SetFrequency( 12 );
            harmonic.SetPhase( 2 );
            harmonic.SetHarmonicKind( HarmonicKind.Cos );

            Assert.IsTrue( harmonicObserver.UpdatedVizualization );
            Assert.AreEqual( 10, harmonic.GetAmplitude() );
            Assert.AreEqual( 12, harmonic.GetFrequency() );
            Assert.AreEqual( 2, harmonic.GetPhase() );
            Assert.AreEqual( HarmonicKind.Cos, harmonic.GetHarmonicKind() );
            Assert.AreEqual( "10*Cos(12*x+2)", harmonic.ToString() );
        }
    }
}
