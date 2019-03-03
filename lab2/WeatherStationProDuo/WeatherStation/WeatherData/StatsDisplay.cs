using System;
using System.Collections.Generic;
using WeatherStation.Observer;

namespace WeatherStation.WeatherData
{
    public class StatsDisplayInfo
    {
        public StatisticHandler TemperatureInfo { get; }
        public StatisticHandler PressureInfo { get; }
        public StatisticHandler HumidityInfo { get; }
        public WindStatisticHandler WindInfo { get; }
        public int CountAcc = 0;

        public StatsDisplayInfo()
        {
            TemperatureInfo = new StatisticHandler( "temperature" );
            PressureInfo = new StatisticHandler( "pressure" );
            HumidityInfo = new StatisticHandler( "humidity" );
            WindInfo = new WindStatisticHandler();
        }
    }

    public class StatsDisplay : Observer.IObserver<WeatherInfo>
    {
        private Observer.IObservable<WeatherInfo> _weatherStationOutside;
        private Observer.IObservable<WeatherInfo> _weatherStationInside;
        private Dictionary<Observer.IObservable<WeatherInfo>, StatsDisplayInfo> _statsDisplayInfoDictionary = new Dictionary<Observer.IObservable<WeatherInfo>, StatsDisplayInfo>();

        public StatsDisplay( Observable<WeatherInfo> weatherStationInside, Observable<WeatherInfo> weatherStationOutside, int priority )
        {
            _weatherStationInside = weatherStationInside;
            _weatherStationOutside = weatherStationOutside;
            _weatherStationInside.RegisterObserver( this, priority );
            _weatherStationOutside.RegisterObserver( this, priority );
            _statsDisplayInfoDictionary.Add( _weatherStationInside, new StatsDisplayInfo() );
            _statsDisplayInfoDictionary.Add( _weatherStationOutside, new StatsDisplayInfo() );

        }

        public void Update( WeatherInfo data, Observer.IObservable<WeatherInfo> observable )
        {

            if ( observable == _weatherStationOutside )
            {
                _statsDisplayInfoDictionary [ _weatherStationOutside ].CountAcc++;
                DisplayStatisticData( _statsDisplayInfoDictionary[_weatherStationOutside].TemperatureInfo.CalculateStatisticInfo( _statsDisplayInfoDictionary [ _weatherStationOutside ].CountAcc, data.temperature ) );
                DisplayStatisticData( _statsDisplayInfoDictionary [ _weatherStationOutside ].HumidityInfo.CalculateStatisticInfo( _statsDisplayInfoDictionary [ _weatherStationOutside ].CountAcc, data.humidity ) );
                DisplayStatisticData( _statsDisplayInfoDictionary [ _weatherStationOutside ].PressureInfo.CalculateStatisticInfo( _statsDisplayInfoDictionary [ _weatherStationOutside ].CountAcc, data.pressure ) );
                DisplayStatisticData( _statsDisplayInfoDictionary [ _weatherStationOutside ].WindInfo.CalculateWindSpeedStatisticInfo( _statsDisplayInfoDictionary [ _weatherStationOutside ].CountAcc, ( WeatherInfoOutside ) data ) );
                DisplayStatisticData( _statsDisplayInfoDictionary [ _weatherStationOutside ].WindInfo.CalculateWindDirectionStatisticInfo( _statsDisplayInfoDictionary [ _weatherStationOutside ].CountAcc, ( WeatherInfoOutside ) data ) );
            }
            else
            {
                _statsDisplayInfoDictionary [ _weatherStationInside ].CountAcc++;
                DisplayStatisticData( _statsDisplayInfoDictionary [ _weatherStationInside ].TemperatureInfo.CalculateStatisticInfo( _statsDisplayInfoDictionary [ _weatherStationInside ].CountAcc, data.temperature ) );
                DisplayStatisticData( _statsDisplayInfoDictionary [ _weatherStationInside ].HumidityInfo.CalculateStatisticInfo( _statsDisplayInfoDictionary [ _weatherStationInside ].CountAcc, data.humidity ) );
                DisplayStatisticData( _statsDisplayInfoDictionary [ _weatherStationInside ].PressureInfo.CalculateStatisticInfo( _statsDisplayInfoDictionary [ _weatherStationInside ].CountAcc, data.pressure ) );
            }
            Console.WriteLine( $"Location {observable.Location}" );
            Console.WriteLine( "----------------" );
        }


        private void DisplayStatisticData( StatisticInfo info )
        {
            if ( info.MaxValue != null )
            {
                Console.WriteLine( $"Max {info.EntityName} {info.MaxValue}" );
            }
            if ( info.MinValue != null )
            {
                Console.WriteLine( $"Min {info.EntityName} {info.MinValue}" );
            }
            Console.WriteLine( $"Average {info.EntityName} {( info.AverageValue != null ? info.AverageValue.ToString() : "undefind" )}" );
        }

    }
}
