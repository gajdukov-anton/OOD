using System;

namespace WeatherStation.WeatherData
{
    public class CDisplay : Observer.IObserver<SWeatherInfo>
    {
        private double _curTemp;
        private double _curHum;
        private double _curPres;
        private string _location = "";

        public CDisplay()
        {
        }

        public void Update( SWeatherInfo data )
        {
            _curTemp = data.sensorInfo.temperature;
            _curHum = data.sensorInfo.humidity;
            _curPres = data.sensorInfo.pressure;
            _location = data.location;
            DisplayCurrentData();
        }

        public void DisplayCurrentData()
        {
            Console.WriteLine( $"Current Temp {_curTemp}" );
            Console.WriteLine( $"Current Hum {_curHum}" );
            Console.WriteLine( $"Current Pressure {_curPres}" );
            Console.WriteLine( $"Location {_location}" );
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

        public string GetLocation()
        {
            return _location;
        }
    }
}
