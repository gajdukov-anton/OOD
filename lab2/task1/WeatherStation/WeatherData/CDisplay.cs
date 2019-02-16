using System;

namespace WeatherStation.WeatherData
{
    public class CDisplay : IObserver<SWeatherInfo>
    {
        public CDisplay()
        { 
        }

        public void Update( SWeatherInfo data )
        { 
            Console.WriteLine( $"Current Temp {data.temperature}" );
            Console.WriteLine( $"Current Hum {data.humidity}" );
            Console.WriteLine( $"Current Pressure {data.pressure}" );
            Console.WriteLine( "----------------" );
        }
    }
}
