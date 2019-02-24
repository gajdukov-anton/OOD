using WeatherStation.Observer;

namespace WeatherStation.WeatherData
{
    class WeatherDataOutside : Observable<WeatherInfo>
    {
        private double _temperature = 0.0;
        private double _humidity = 0.0;
        private double _pressure = 760.0;
        private double _windDirection = 0.0;
        private double _windSpeed = 0.0;

        public WeatherDataOutside(  )
            : base( LocationKind.Outside )
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

        protected override WeatherInfo GetChangedData()
        {
            OutsideSensorInfo outsideSensorInfo = new OutsideSensorInfo
            {
                Temperature = GetTemperature(),
                Humidity = GetHumidity(),
                Pressure = GetPressure(),
                WindDirection = GetWindDirection(),
                WindSpeed = GetWindSpeed()
            };
            WeatherInfo info = new WeatherInfo( this, outsideSensorInfo );
            return info;
        }
    }
}
