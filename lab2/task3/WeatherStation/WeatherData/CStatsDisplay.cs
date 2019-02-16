using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WeatherStation.WeatherData
{
    class CStatsDisplay : IObserver<SWeatherInfo>
    {
        private uint _countAcc = 0;
        private Dictionary<string, StatisticEssence> _sensors = new Dictionary<string, StatisticEssence>();
        private readonly List<FieldInfo> _infoFields = new List<FieldInfo>();

        public CStatsDisplay()
        {
            _infoFields = typeof( SWeatherInfo ).GetFields().ToList();
            foreach ( var field in _infoFields )
            {
                _sensors.Add(field.Name, new StatisticEssence() );
            }
        }

        public void Update( SWeatherInfo data )
        {
            foreach ( var field in _infoFields )
            {
                _sensors [ field.Name ].SetValue(( double ) field.GetValue(data) );
            }
            ++_countAcc;
            foreach ( var sensor in _sensors )
            {
                Console.WriteLine( $"Max {sensor.Key}  {sensor.Value.GetMaxValue()}" );
                Console.WriteLine( $"Min {sensor.Key}   {sensor.Value.GetMinValue()}" );
                Console.WriteLine( $"Average {sensor.Key}   {sensor.Value.GetAccValue() / _countAcc}" );
                Console.WriteLine();
            }
            Console.WriteLine( "----------------" );
        }
    }
}
