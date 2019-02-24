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
            WeatherData weatherData = new WeatherData();
            Display cDisplay = new Display();
            ObserverWithPriority<WeatherInfo> observer = new ObserverWithPriority<WeatherInfo>( cDisplay, 2 );
            List<ObserverWithPriority<WeatherInfo>> observerList = new List<ObserverWithPriority<WeatherInfo>>();
            observerList.Add( observer );


            weatherData.RegisterObserver( cDisplay, 2 );
            Assert.IsTrue( CompareObserverList( observerList, weatherData.GetObservers() ) );
        }

        [TestMethod]
        public void TestSomeObserver()
        {
            List<ObserverWithPriority<WeatherInfo>> observerList = new List<ObserverWithPriority<WeatherInfo>>();
            var weatherData = new WeatherData();
            var cDisplay = new Display();
            var cDisplay1 = new Display();
            var statsDisplay = new StatsDisplay();
            var statsDisplay1 = new StatsDisplay();
            var cDisplay2 = new Display();

            observerList.Add( new ObserverWithPriority<WeatherInfo>( cDisplay1, 3 ) );
            observerList.Add( new ObserverWithPriority<WeatherInfo>( statsDisplay, 2 ) );
            observerList.Add( new ObserverWithPriority<WeatherInfo>( statsDisplay1, 2 ) );
            observerList.Add( new ObserverWithPriority<WeatherInfo>( cDisplay, 1 ) );
            observerList.Add( new ObserverWithPriority<WeatherInfo>( cDisplay2, 0 ) );

            weatherData.RegisterObserver( cDisplay, 1 );
            weatherData.RegisterObserver( statsDisplay, 2 );
            weatherData.RegisterObserver( cDisplay1, 3 );
            weatherData.RegisterObserver( statsDisplay1, 2 );
            weatherData.RegisterObserver( cDisplay2, 0 );
            Assert.IsTrue( CompareObserverList( observerList, weatherData.GetObservers() ) );

        }

        private bool CompareObserverList( List<ObserverWithPriority<WeatherInfo>> listOne, List<ObserverWithPriority<WeatherInfo>> listTwo )
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
