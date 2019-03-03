using System;

namespace WeatherStation.WeatherData
{
    public class Display : Observer.IObserver<WeatherInfo>
    {

        public Display()
        { 
        }

        public void Update( WeatherInfo data )
        {
            Console.WriteLine( $"Current Temp {data.temperature}" );
            Console.WriteLine( $"Current Hum {data.humidity}" );
            Console.WriteLine( $"Current Pressure {data.pressure}" );
            Console.WriteLine( $"Current Wind Speed {data.windInfo.windSpeed}" );
            Console.WriteLine( $"Current Wind Direction {data.windInfo.windDirection}" );
            Console.WriteLine( "----------------" );
        }
      
    }
}
