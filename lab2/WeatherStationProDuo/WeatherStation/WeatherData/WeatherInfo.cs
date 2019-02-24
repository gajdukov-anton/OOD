using WeatherStation.Observer;

namespace WeatherStation.WeatherData
{
    public class SensorInfo
    {
        public double Temperature;
        public double Humidity;
        public double Pressure;
    };

    public class OutsideSensorInfo : SensorInfo
    {
        public double WindSpeed;
        public double WindDirection;
    }

    public  class WeatherInfo
    {
        private readonly Observable<WeatherInfo> _sender;
        private readonly SensorInfo _sensorInfo;

        public WeatherInfo(Observable<WeatherInfo> sender, SensorInfo sensorInfo)
        {
            _sender = sender;
            _sensorInfo = sensorInfo;
        }

        public Observable<WeatherInfo> GetSender()
        {
            return _sender;
        }

        public SensorInfo GetSensorInfo()
        {
            return _sensorInfo;
        }
    };
}
