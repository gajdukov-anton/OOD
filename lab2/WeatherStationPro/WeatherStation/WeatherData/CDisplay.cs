using System;

namespace WeatherStation.WeatherData
{
    public class CDisplay : Observer.IObserver<SWeatherInfo>
    {

        public CDisplay()
        { 
        }

        public void Update( SWeatherInfo data )
        {
            Console.WriteLine( $"Current Temp {data.temperature}" );
            Console.WriteLine( $"Current Hum {data.humidity}" );
            Console.WriteLine( $"Current Pressure {data.pressure}" );
            Console.WriteLine( $"Current Wind Speed {data.windSpeed} m/s" );
            Console.WriteLine( $"Current Wind Direction {data.windDirection} degree" );
            Console.WriteLine( "----------------" );
        }
      
    }
}
