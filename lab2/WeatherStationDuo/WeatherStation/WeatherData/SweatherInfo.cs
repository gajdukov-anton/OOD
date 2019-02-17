namespace WeatherStation.WeatherData
{
    public struct SSensorInfo
    {
        public double temperature;
        public double humidity;
        public double pressure;
    };

    public  struct SWeatherInfo
    {
        public string location;
        public SSensorInfo sensorInfo;
    };
}
