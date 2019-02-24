using System;
using WeatherStation.WeatherData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherStation.Observer;

namespace UnitTestDuoObservable
{
    [TestClass]
    public class TestDuoObservable
    {
        [TestMethod]
        public void TestTwoObservable()
        {
            var weatheDataOut = new WeatherDataInside( LocationKind.Outside );
            var weatheDataIn = new WeatherDataInside( LocationKind.Inside );
            var display = new Display( weatheDataIn , weatheDataOut, 2);
            var statsDisplay = new StatsDisplay( weatheDataIn, weatheDataOut, 2 );
            weatheDataOut.SetMeasurements( 3, 0.7, 760 );
            Assert.AreEqual( LocationKind.Outside, display.GetLastWeatherStation().GetLocation() );
            Assert.AreEqual( LocationKind.Outside, statsDisplay.GetLastWeatherStation().GetLocation() );
            Assert.AreEqual( 3, display.GetCurrentTemperature() );
            Assert.AreEqual( 0.7, display.GetCurrentHumidity() );
            Assert.AreEqual( 760, display.GetCurrentPressure() );
            Assert.AreEqual( 3, statsDisplay.GetStatisticInfoDictionary() [ "temperature" ].GetMaxValue() );
            Assert.AreEqual( 0.7, statsDisplay.GetStatisticInfoDictionary() [ "humidity" ].GetMaxValue() );
            Assert.AreEqual( 760, statsDisplay.GetStatisticInfoDictionary() [ "pressure" ].GetMaxValue() );
            weatheDataIn.SetMeasurements( 10, 0.8, 761 );
            Assert.AreEqual( 10, display.GetCurrentTemperature() );
            Assert.AreEqual( 0.8, display.GetCurrentHumidity() );
            Assert.AreEqual( 761, display.GetCurrentPressure() );
            Assert.AreEqual( 10, statsDisplay.GetStatisticInfoDictionary() [ "temperature" ].GetMaxValue() );
            Assert.AreEqual( 0.8, statsDisplay.GetStatisticInfoDictionary() [ "humidity" ].GetMaxValue() );
            Assert.AreEqual( 761, statsDisplay.GetStatisticInfoDictionary() [ "pressure" ].GetMaxValue() );
            Assert.AreEqual( LocationKind.Inside, display.GetLastWeatherStation().GetLocation() );
            Assert.AreEqual( LocationKind.Inside, statsDisplay.GetLastWeatherStation().GetLocation() );
            weatheDataOut.SetMeasurements( 3, 0.7, 760 );
            Assert.AreEqual( LocationKind.Outside, display.GetLastWeatherStation().GetLocation() );
            Assert.AreEqual( LocationKind.Outside, statsDisplay.GetLastWeatherStation().GetLocation() );
        }

        [TestMethod]
        public void TestThreeObservable()
        {
            var weatheDataOut = new WeatherDataInside( LocationKind.Outside );
            var weatheDataIn = new WeatherDataInside( LocationKind.Inside );
            var display = new Display( weatheDataIn, weatheDataOut, 2 );
            var statsDisplay = new StatsDisplay( weatheDataIn, weatheDataOut, 2 );
            var weatherDataOut2 = new WeatherDataInside( LocationKind.Outside );
            weatherDataOut2.RegisterObserver( display, 4 );
            weatherDataOut2.RegisterObserver( statsDisplay, 2 );
        }
    }
}
