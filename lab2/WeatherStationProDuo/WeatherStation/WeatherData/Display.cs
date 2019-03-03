using System;
using WeatherStation.Observer;

namespace WeatherStation.WeatherData
{
    public class Display : Observer.IObserver<WeatherInfo>
    {
        private Observer.IObservable<WeatherInfo> _lastWeatherStation;
        private Observer.IObservable<WeatherInfo> _weatherStationOutside;
        private Observer.IObservable<WeatherInfo> _weatherStationInside;

        public Display( Observable<WeatherInfo> weatherStationInside, Observable<WeatherInfo> weatherStationOutside, int priority )
        {
            _weatherStationInside = weatherStationInside;
            _weatherStationOutside = weatherStationOutside;
            _weatherStationInside.RegisterObserver( this, priority );
            _weatherStationOutside.RegisterObserver( this, priority );
        }

        public void Update( WeatherInfo data, Observer.IObservable<WeatherInfo> observable )
        {
            Console.WriteLine( $"Current Temp {data.temperature}" );
            Console.WriteLine( $"Current Hum {data.humidity}" );
            Console.WriteLine( $"Current Pressure {data.pressure}" );
            if (observable == _weatherStationOutside)
            {
                Console.WriteLine( $"Current windSpeed {(( WeatherInfoOutside ) data ).windInfo.windSpeed}" );
                Console.WriteLine( $"Current windDirection {( ( WeatherInfoOutside ) data ).windInfo.windDirection}" );
            }
            Console.WriteLine( $"Location {observable.Location.ToString()}" );
            Console.WriteLine( "----------------" );
        }
    }
}
