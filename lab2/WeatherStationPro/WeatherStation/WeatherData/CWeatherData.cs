using WeatherStation.Observer;

namespace WeatherStation.WeatherData
{
    public class CWeatherData : CObservable<SWeatherInfo>
    {
        private double _temperature = 0.0;
        private double _humidity = 0.0;
        private double _pressure = 760.0;
        private double _windSpeed = 0.0;
        private double _windDirection = 0.0;

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

        public double GetWindSpeed()
        {
            return _windSpeed;
        }

        public double GetWindDirection()
        {
            return _windDirection;
        }

        public void MeasurementsChanged()
        {
            NotifyObservers();
        }

        public void SetMeasurements( double temp, double humidity, double pressure, double windSpeed, double windDirection )
        {
            _humidity = humidity;
            _temperature = temp;
            _pressure = pressure;
            _windSpeed = windSpeed;
            _windDirection = windDirection;

            MeasurementsChanged();
        }

        protected override SWeatherInfo GetChangedData()
        {
            SWeatherInfo info;
            info.temperature = GetTemperature();
            info.humidity = GetHumidity();
            info.pressure = GetPressure();
            info.windSpeed = GetWindSpeed();
            info.windDirection = GetWindDirection();
            return info;
        }
    }
}
