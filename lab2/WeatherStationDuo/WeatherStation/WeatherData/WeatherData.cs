using System;
using System.Collections.Generic;
using System.Linq;
using WeatherStation.Observer;

namespace WeatherStation.WeatherData
{
    public class WeatherData : Observable<WeatherInfo>
    {
        private double _temperature = 0.0;
        private double _humidity = 0.0;
        private double _pressure = 760.0;

        public WeatherData( LocationKind location )
            :base(location)
        {
        }

        public double GetTemperature()
        {
            return _temperature;
        }
        // Относительная влажность (0...100)
        public double GetHumidity()
        {
            return _humidity;
        }
        // Атмосферное давление (в мм.рт.ст)
        public double GetPressure()
        {
            return _pressure;
        }

        public void MeasurementsChanged()
        {
            NotifyObservers();
        }

        public void SetMeasurements( double temp, double humidity, double pressure )
        {
            _humidity = humidity;
            _temperature = temp;
            _pressure = pressure;

            MeasurementsChanged();
        }

        protected override WeatherInfo GetChangedData()
        {
            WeatherInfo info;
            info.temperature = GetTemperature();
            info.humidity = GetHumidity();
            info.pressure = GetPressure();
            return info;
        }
    }
}
