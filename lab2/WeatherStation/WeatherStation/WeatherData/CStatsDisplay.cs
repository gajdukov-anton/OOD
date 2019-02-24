using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace WeatherStation.WeatherData
{
    public class CStatsDisplay : Observer.IObserver<SWeatherInfo>
    {
        private uint _countAcc = 0;
        private Dictionary<string, StatisticInfo> _statisticEssenceDictionary = new Dictionary<string, StatisticInfo>();
        private readonly List<FieldInfo> _sWeatherInfoFields = new List<FieldInfo>();

        public CStatsDisplay()
        {
            _sWeatherInfoFields = typeof( SWeatherInfo ).GetFields().ToList();
            foreach ( var field in _sWeatherInfoFields )
            {
                _statisticEssenceDictionary.Add( field.Name, new StatisticInfo() );
            }
        }

        public void Update( SWeatherInfo data )
        {
            foreach ( var field in _sWeatherInfoFields )
            {
                _statisticEssenceDictionary [ field.Name ].AddNewValue( ( double ) field.GetValue( data ) );
            }
            ++_countAcc;
            foreach ( var statisticEssence in _statisticEssenceDictionary )
            {
                Console.WriteLine( $"Max {statisticEssence.Key}  {statisticEssence.Value.GetMaxValue()}" );
                Console.WriteLine( $"Min {statisticEssence.Key}   {statisticEssence.Value.GetMinValue()}" );
                Console.WriteLine( $"Average {statisticEssence.Key}   {statisticEssence.Value.GetAccValue() / _countAcc}" );
                Console.WriteLine();
            }
            Console.WriteLine( "----------------" );
        }

        public Dictionary<string, StatisticInfo> GetStatisticsData()
        {
            return _statisticEssenceDictionary;
        }
    }
}
