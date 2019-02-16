using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace WeatherStation.WeatherData
{
    class CStatsDisplay : IObserver<SWeatherInfo>
    {
        private uint _countAcc = 0;
        private Dictionary<string, StatisticEssence> _statisticEssenceDictionary = new Dictionary<string, StatisticEssence>();
        private readonly List<FieldInfo> _sWeatherInfoFields = new List<FieldInfo>();

        public CStatsDisplay()
        {
            _sWeatherInfoFields = typeof( SWeatherInfo ).GetFields().ToList();
            foreach ( var field in _sWeatherInfoFields )
            {
                _statisticEssenceDictionary.Add(field.Name, new StatisticEssence() );
            }
        }

        public void Update( SWeatherInfo data )
        {
            foreach ( var field in _sWeatherInfoFields )
            {
                _statisticEssenceDictionary [ field.Name ].SetValue(( double ) field.GetValue(data) );
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
    }
}
