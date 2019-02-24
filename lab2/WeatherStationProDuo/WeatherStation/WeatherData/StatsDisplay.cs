using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using WeatherStation.Observer;

namespace WeatherStation.WeatherData
{
    public class StatsDisplay : Observer<WeatherInfo>
    {
        private int _countAcc = 0;
        private Dictionary<string, Func<double, int, double>> _functionsForCalcAver = new Dictionary<string, Func<double, int, double>>();
        private readonly Func<double, int, double> _defaultFuncForCalcAver;
        private Dictionary<string, Func<double, double>> _functionsForValidStatValue = new Dictionary<string, Func<double, double>>();

        public StatsDisplay( Observable<WeatherInfo> weatherStationInside, Observable<WeatherInfo> weatherStationOutside, int priority, Func<double, int, double> defaultFuncForCalcAver )
        {
            _weatherStationInside = weatherStationInside;
            _weatherStationOutside = weatherStationOutside;
            _weatherStationInside.RegisterObserver( this, priority );
            _weatherStationOutside.RegisterObserver( this, priority );
            _defaultFuncForCalcAver = defaultFuncForCalcAver;
        }

        public override void Update( WeatherInfo data )
        {
            ++_countAcc;
            var weatherInfoFields = CreateSensorInfoFields( data );
            var statisticInfoDictionary = CreateStatisticInfoDictionary( weatherInfoFields );
            foreach ( var field in weatherInfoFields )
            {
                double value = ValidateStatisticValue( field.Name, ( double ) field.GetValue( data.GetSensorInfo() ) );
                statisticInfoDictionary [ field.Name ].SetMinMaxValue( value );
                statisticInfoDictionary [ field.Name ].AverageValue = CalculateAverageValue( field.Name, value );
            }
            foreach ( var statisticField in statisticInfoDictionary )
            {
                Console.WriteLine( $"Max {statisticField.Key}  {statisticField.Value.GetMaxValue()}" );
                Console.WriteLine( $"Min {statisticField.Key}   {statisticField.Value.GetMinValue()}" );
                Console.WriteLine( $"Average {statisticField.Key}   {statisticField.Value.AverageValue}" );
                Console.WriteLine();
            }
            Console.WriteLine( $"Location {data.GetSender().GetLocation().ToString()}" );
            Console.WriteLine( "----------------" );
        }

        public void AddFuncForCalcAverValue( string statisticField, Func<double, int, double> function )
        {
            _functionsForCalcAver.Add( statisticField, function );
        }

        public void AddFuncForValidStatValue( string statisticField, Func<double, double> function )
        {
            _functionsForValidStatValue.Add( statisticField, function );
        }

        private List<FieldInfo> CreateSensorInfoFields( WeatherInfo data )
        {
            return data.GetSender() == _weatherStationOutside ? typeof( OutsideSensorInfo ).GetFields().ToList() : typeof( SensorInfo ).GetFields().ToList();
        }

        private Dictionary<string, StatisticInfo> CreateStatisticInfoDictionary( List<FieldInfo> weatherInfoFields )
        {
            var statisticInfoDictionary = new Dictionary<string, StatisticInfo>();
            foreach ( var field in weatherInfoFields )
            {
                statisticInfoDictionary.Add( field.Name, new StatisticInfo() );
            }
            return statisticInfoDictionary;
        }

        private double ValidateStatisticValue( string fieldName, double value )
        {
            return _functionsForValidStatValue.TryGetValue( fieldName, out Func<double, double> validate ) ? validate( value ) : value;
        }

        private double CalculateAverageValue( string fieldName, double value )
        {
            return _functionsForCalcAver.TryGetValue( fieldName, out Func<double, int, double> action ) ? action( value, _countAcc ) : _defaultFuncForCalcAver( value, _countAcc );
        }
    }
}
