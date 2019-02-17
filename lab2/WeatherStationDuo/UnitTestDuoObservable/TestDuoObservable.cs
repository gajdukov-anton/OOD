using System;
using WeatherStation.WeatherData;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestDuoObservable
{
    [TestClass]
    public class TestDuoObservable
    {
        [TestMethod]
        public void TestOneObservable()
        {
            var weatheDataOut = new CWeatherData( "Out of doors" );
            var display = new CDisplay();
            var statsDisplay = new CStatsDisplay();

            weatheDataOut.RegisterObserver( display, 2 );
            weatheDataOut.RegisterObserver( statsDisplay, 2 );
            weatheDataOut.SetMeasurements( 3, 0.7, 760 );
            Assert.AreEqual( "Out of doors", display.GetLocation() );
            Assert.AreEqual( "Out of doors", statsDisplay.GetLocation() );
            weatheDataOut.SetMeasurements( 3, 0.7, 760 );
            Assert.AreEqual( "Out of doors", display.GetLocation() );
            Assert.AreEqual( "Out of doors", statsDisplay.GetLocation() );

        }

        [TestMethod]
        public void TestTwoObservable()
        {
            var weatheDataOut = new CWeatherData( "Out of doors" );
            var weatheDataIn = new CWeatherData( "Indoors" );
            var display = new CDisplay();
            var statsDisplay = new CStatsDisplay();

            weatheDataOut.RegisterObserver( display, 2 );
            weatheDataOut.RegisterObserver( statsDisplay, 2 );
            weatheDataIn.RegisterObserver( statsDisplay, 2 );
            weatheDataIn.RegisterObserver( display, 2 );
            weatheDataOut.SetMeasurements( 3, 0.7, 760 );
            Assert.AreEqual( "Out of doors", display.GetLocation() );
            Assert.AreEqual( "Out of doors", statsDisplay.GetLocation() );
            weatheDataIn.SetMeasurements( 10, 0.8, 761 );
            Assert.AreEqual( "Indoors", display.GetLocation() );
            Assert.AreEqual( "Indoors", statsDisplay.GetLocation() );
            weatheDataOut.SetMeasurements( 3, 0.7, 760 );
            Assert.AreEqual( "Out of doors", display.GetLocation() );
            Assert.AreEqual( "Out of doors", statsDisplay.GetLocation() );
        }
    }
}
