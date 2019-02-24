using WeatherStation.Observer;

namespace WeatherStation.WeatherData
{
    public class WeatherDataInside : Observable<WeatherInfo>
    {
        private double _temperature = 0.0;
        private double _humidity = 0.0;
        private double _pressure = 760.0;

        public WeatherDataInside()
            :base(LocationKind.Inside)
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
            SensorInfo sensorInfo = new SensorInfo
            {
                Temperature = GetTemperature(),
                Humidity = GetHumidity(),
                Pressure = GetPressure()
            };
            WeatherInfo info = new WeatherInfo(this, sensorInfo);
            return info;
        }
    }
}
