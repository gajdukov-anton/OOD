using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherStation.WeatherData;

namespace UnitTestPriorityObserver
{
    [TestClass]
    public class TestRemoveObserverInUpdate
    {
        [TestMethod]
        public void TestDeliteObserver()
        {
            var weatherData = new CWeatherData();
            var customObserver = new CustomObserver( weatherData );
            weatherData.RegisterObserver( customObserver, 0 );
            weatherData.SetMeasurements( 0, 0, 0 );
        }
    }
}
