using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using WeatherStation.Observer;

namespace WeatherStation.WeatherData
{
    public class StatsDisplay : Observer<WeatherInfo>
    {
        private uint _countAcc = 0;
        private Dictionary<string, StatisticInfo> _statisticInfoDictionary = new Dictionary<string, StatisticInfo>();
        private readonly List<FieldInfo> _sWeatherInfoFields = new List<FieldInfo>();

        public StatsDisplay( Observable<WeatherInfo> weatherStationInside, Observable<WeatherInfo> weatherStationOutside, int priority )
        {
            _weatherStationInside = weatherStationInside;
            _weatherStationOutside = weatherStationOutside;
            _weatherStationInside.RegisterObserver( this, priority );
            _weatherStationOutside.RegisterObserver( this, priority );

            _sWeatherInfoFields = typeof( WeatherInfo ).GetFields().ToList();
            foreach ( var field in _sWeatherInfoFields )
            {
                _statisticInfoDictionary.Add( field.Name, new StatisticInfo() );
            }
        }

        public override void Update( WeatherInfo data, Observer.IObservable<WeatherInfo> observable )
        {
            foreach ( var field in _sWeatherInfoFields )
            {
                _statisticInfoDictionary [ field.Name ].AddNewValue( ( double ) field.GetValue( data ) );
            }
            ++_countAcc;
            _lastWeatherStation = ( Observable<WeatherInfo> ) observable;
            DisplayCurrentData();
        }

        public void DisplayCurrentData()
        {
            foreach ( var statisticField in _statisticInfoDictionary )
            {
                Console.WriteLine( $"Max {statisticField.Key}  {statisticField.Value.GetMaxValue()}" );
                Console.WriteLine( $"Min {statisticField.Key}   {statisticField.Value.GetMinValue()}" );
                Console.WriteLine( $"Average {statisticField.Key}   {statisticField.Value.GetAccValue() / _countAcc}" );
            }
            Console.WriteLine( $"Location {_lastWeatherStation.Location.ToString()}" );
            Console.WriteLine( "----------------" );
        }

        public Dictionary<string, StatisticInfo> GetStatisticInfoDictionary()
        {
            return _statisticInfoDictionary;
        }
    }
}
