using System;
using WeatherStation.Observer;

namespace WeatherStation.WeatherData
{
    public class Display : Observer<WeatherInfo>
    {
        private double _curTemp;
        private double _curHum;
        private double _curPres;

        public Display( Observable<WeatherInfo> weatherStationInside, Observable<WeatherInfo> weatherStationOutside, int priority )
        {
            _weatherStationInside = weatherStationInside;
            _weatherStationOutside = weatherStationOutside;
            _weatherStationInside.RegisterObserver( this, priority );
            _weatherStationOutside.RegisterObserver( this, priority );
        }

        public override void Update( WeatherInfo data )
        {
            _curTemp = data.sensorInfo.temperature;
            _curHum = data.sensorInfo.humidity;
            _curPres = data.sensorInfo.pressure;
            _lastWeatherStation = data.sender;
            DisplayCurrentData();
        }

        public void DisplayCurrentData()
        {
            Console.WriteLine( $"Current Temp {_curTemp}" );
            Console.WriteLine( $"Current Hum {_curHum}" );
            Console.WriteLine( $"Current Pressure {_curPres}" );
            Console.WriteLine( $"Location {_lastWeatherStation.GetLocation().ToString()}" );
            Console.WriteLine( "----------------" );
        }

        public double GetCurrentTemperature()
        {
            return _curTemp;
        }

        public double GetCurrentHumidity()
        {
            return _curHum;
        }

        public double GetCurrentPressure()
        {
            return _curPres;
        }
    }
}
