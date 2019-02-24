using System;
using WeatherStation.Observer;

namespace WeatherStation.WeatherData
{
    public class Display : Observer<WeatherInfo>
    {
        public Display( Observable<WeatherInfo> weatherStationInside, Observable<WeatherInfo> weatherStationOutside, int priority )
        {
            _weatherStationInside = weatherStationInside;
            _weatherStationOutside = weatherStationOutside;
            _weatherStationInside.RegisterObserver( this, priority );
            _weatherStationOutside.RegisterObserver( this, priority );
        }

        public override void Update( WeatherInfo data )
        {
            Console.WriteLine( $"Current Temp {data.GetSensorInfo().Temperature}" );
            Console.WriteLine( $"Current Hum {data.GetSensorInfo().Humidity}" );
            Console.WriteLine( $"Current Pressure {data.GetSensorInfo().Pressure}" );
            if (data.GetSender() == _weatherStationOutside)
            {
                Console.WriteLine( $"Current windSpeed {((OutsideSensorInfo) data.GetSensorInfo() ).WindSpeed}" );
                Console.WriteLine( $"Current windDirection {( ( OutsideSensorInfo ) data.GetSensorInfo() ).WindDirection}" );
            }
            Console.WriteLine( $"Location {data.GetSender().GetLocation().ToString()}" );
            Console.WriteLine( "----------------" );
        }
    }
}
