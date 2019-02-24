using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace WeatherStation.WeatherData
{
    public class StatsDisplay : Observer.IObserver<WeatherInfo>
    {
        private int _countAcc = 0;
        private Dictionary<string, StatisticInfo> _statisticInfoDictionary = new Dictionary<string, StatisticInfo>();
        private readonly List<FieldInfo> _weatherInfoFields = new List<FieldInfo>();
        private Dictionary<string, Func<double, int, double>> _functionsForCalcAver = new Dictionary<string, Func<double, int, double>>();
        private Func<double, int, double> _defaultFuncForCalcAver;
        private Dictionary<string, Func<double, double>> _functionsForValidStatValue = new Dictionary<string, Func<double, double>>();

        public StatsDisplay( Func<double, int, double> defaultFuncForCalcAver )
        {
            _weatherInfoFields = typeof( WeatherInfo ).GetFields().ToList();
            _defaultFuncForCalcAver = defaultFuncForCalcAver;
            foreach ( var field in _weatherInfoFields )
            {
                _statisticInfoDictionary.Add( field.Name, new StatisticInfo() );
            }
        }

        public void Update( WeatherInfo data )
        {
            ++_countAcc;
            foreach ( var field in _weatherInfoFields )
            {
                double value = ValidateStatisticValue( field.Name, ( double ) field.GetValue( data ) );
                _statisticInfoDictionary [ field.Name ].SetMinMaxValue( value );
                _statisticInfoDictionary [ field.Name ].AverageValue = CalculateAverageValue( field.Name, value );
            }
            foreach ( var statisticField in _statisticInfoDictionary )
            {
                Console.WriteLine( $"Max {statisticField.Key}  {statisticField.Value.GetMaxValue()}" );
                Console.WriteLine( $"Min {statisticField.Key}   {statisticField.Value.GetMinValue()}" );
                Console.WriteLine( $"Average {statisticField.Key}   {statisticField.Value.AverageValue}" );
                Console.WriteLine();
            }
            Console.WriteLine( "----------------" );
        }

        public void AddFuncForCalcAverValue( string statisticField, Func<double, int, double> function )
        {
            _functionsForCalcAver.Add( statisticField, function );
        }

        public Dictionary<string, StatisticInfo> GetStatisticsData()
        {
            return _statisticInfoDictionary;
        }

        public void AddFuncForValidStatValue( string statisticField, Func<double, double> function )
        {
            _functionsForValidStatValue.Add( statisticField, function );
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
