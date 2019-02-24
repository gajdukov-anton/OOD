using WeatherStation.Observer;

namespace WeatherStation.WeatherData
{
    public struct SensorInfo
    {
        public double temperature;
        public double humidity;
        public double pressure;
    };

    public  struct WeatherInfo
    {
        public Observable<WeatherInfo> sender;
        public SensorInfo sensorInfo;
    };
}
