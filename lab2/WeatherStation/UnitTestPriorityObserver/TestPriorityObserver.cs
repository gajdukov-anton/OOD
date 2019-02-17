using System;
using WeatherStation.WeatherData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherStation.Observer;
using System.Collections.Generic;

namespace UnitTestPriorityObserver
{
    [TestClass]
    public class TestPriorityObserver
    {
        [TestMethod]
        public void TestOneObserver()
        {
            CWeatherData weatherData = new CWeatherData();
            CDisplay cDisplay = new CDisplay();
            ObserverWithPriority<SWeatherInfo> observer = new ObserverWithPriority<SWeatherInfo>( cDisplay, 2 );
            List<ObserverWithPriority<SWeatherInfo>> observerList = new List<ObserverWithPriority<SWeatherInfo>>();
            observerList.Add( observer );


            weatherData.RegisterObserver( cDisplay, 2 );
            Assert.IsTrue( CompareObserverList( observerList, weatherData.GetObservers() ) );
        }

        [TestMethod]
        public void TestSomeObserver()
        {
            List<ObserverWithPriority<SWeatherInfo>> observerList = new List<ObserverWithPriority<SWeatherInfo>>();
            var weatherData = new CWeatherData();
            var cDisplay = new CDisplay();
            var cDisplay1 = new CDisplay();
            var statsDisplay = new CStatsDisplay();
            var statsDisplay1 = new CStatsDisplay();
            var cDisplay2 = new CDisplay();

            observerList.Add( new ObserverWithPriority<SWeatherInfo>( cDisplay1, 3 ) );
            observerList.Add( new ObserverWithPriority<SWeatherInfo>( statsDisplay, 2 ) );
            observerList.Add( new ObserverWithPriority<SWeatherInfo>( statsDisplay1, 2 ) );
            observerList.Add( new ObserverWithPriority<SWeatherInfo>( cDisplay, 1 ) );
            observerList.Add( new ObserverWithPriority<SWeatherInfo>( cDisplay2, 0 ) );

            weatherData.RegisterObserver( cDisplay, 1 );
            weatherData.RegisterObserver( statsDisplay, 2 );
            weatherData.RegisterObserver( cDisplay1, 3 );
            weatherData.RegisterObserver( statsDisplay1, 2 );
            weatherData.RegisterObserver( cDisplay2, 0 );
            Assert.IsTrue( CompareObserverList( observerList, weatherData.GetObservers() ) );

        }

        private bool CompareObserverList( List<ObserverWithPriority<SWeatherInfo>> listOne, List<ObserverWithPriority<SWeatherInfo>> listTwo )
        {
            if ( listOne.Count != listTwo.Count )
            {
                return false;
            }
            for ( int i = 0; i < listOne.Count; i++ )
            {
                if ( !listOne [ i ].observer.Equals( listTwo [ i ].observer )
                    || listOne [ i ].priority != listTwo [ i ].priority )
                {
                    return false;
                }
            }
            return true;
        }
    }
}
