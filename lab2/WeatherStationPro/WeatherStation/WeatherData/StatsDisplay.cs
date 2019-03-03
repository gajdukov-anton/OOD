using System;

namespace WeatherStation.WeatherData
{
    
    public class StatsDisplay : Observer.IObserver<WeatherInfo>
    {
        private int _countAcc = 0;
        private StatisticHandler _temperatureInfo = new StatisticHandler("temperature");
        private StatisticHandler _pressureInfo = new StatisticHandler("pressure");
        private StatisticHandler _humidityInfo = new StatisticHandler("humidity");
        private WindStatisticHandler _windInfo = new WindStatisticHandler();

        public StatsDisplay()
        {
        }

        public void Update( WeatherInfo data )
        {
            ++_countAcc;
            DisplayStatisticData(_temperatureInfo.CalculateStatisticInfo( _countAcc, data.temperature ));
            DisplayStatisticData(_humidityInfo.CalculateStatisticInfo( _countAcc, data.humidity ));
            DisplayStatisticData(_pressureInfo.CalculateStatisticInfo( _countAcc, data.pressure ));
            DisplayStatisticData(_windInfo.CalculateWindSpeedStatisticInfo( _countAcc, data));
            DisplayStatisticData( _windInfo.CalculateWindDirectionStatisticInfo( _countAcc, data ) );
            Console.WriteLine( "----------------" );
        }

        private void DisplayStatisticData (StatisticInfo info)
        {
            if ( info.MaxValue != null )
            {
                Console.WriteLine( $"Max {info.EntityName} {info.MaxValue}" );
            }
            if ( info.MinValue != null )
            {
                Console.WriteLine( $"Min {info.EntityName} {info.MinValue}" );
            }
            Console.WriteLine( $"Average {info.EntityName} {(info.AverageValue != null ? info.AverageValue.ToString() : "undefind")}" );
        }

       
    }
}
