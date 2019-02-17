using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace WeatherStation.WeatherData
{
    public class CStatsDisplay : Observer.IObserver<SWeatherInfo>
    {
        private uint _countAcc = 0;
        private string _location = "";
        private Dictionary<string, StatisticEssence> _statisticEssenceDictionary = new Dictionary<string, StatisticEssence>();
        private readonly List<FieldInfo> _sWeatherInfoFields = new List<FieldInfo>();

        public CStatsDisplay()
        {
            _sWeatherInfoFields = typeof( SSensorInfo ).GetFields().ToList();
            foreach ( var field in _sWeatherInfoFields )
            {
                _statisticEssenceDictionary.Add( field.Name, new StatisticEssence() );
            }
        }

        public void Update( SWeatherInfo data )
        {
            foreach ( var field in _sWeatherInfoFields )
            {
                _statisticEssenceDictionary [ field.Name ].AddNewValue( ( double ) field.GetValue( data.sensorInfo ) );
            }
            ++_countAcc;
            _location = data.location;
            DisplayCurrentData();
        }

        public void DisplayCurrentData()
        {
            foreach ( var statisticEssence in _statisticEssenceDictionary )
            {
                Console.WriteLine( $"Max {statisticEssence.Key}  {statisticEssence.Value.GetMaxValue()}" );
                Console.WriteLine( $"Min {statisticEssence.Key}   {statisticEssence.Value.GetMinValue()}" );
                Console.WriteLine( $"Average {statisticEssence.Key}   {statisticEssence.Value.GetAccValue() / _countAcc}" );
            }
            Console.WriteLine( $"Location {_location}" );
            Console.WriteLine( "----------------" );
        }

        public string GetLocation()
        {
            return _location;
        }
    }
}
