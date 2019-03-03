namespace WeatherStation.WeatherData
{
    public class WindInfo
    {
        public double windSpeed;
        public double windDirection;
    }
    public class WeatherInfo
    {
        public double temperature;
        public double humidity;
        public double pressure;
        public WindInfo windInfo = new WindInfo();
    };
}
