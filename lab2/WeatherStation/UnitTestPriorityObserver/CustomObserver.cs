using WeatherStation.WeatherData;

namespace UnitTestPriorityObserver
{
    public class CustomObserver : WeatherStation.Observer.IObserver<SWeatherInfo>
    {
        private WeatherStation.Observer.IObservable<SWeatherInfo> _observable;
        public CustomObserver( WeatherStation.Observer.IObservable<SWeatherInfo> observable )
        {
            _observable = observable;
        }

        public void Update( SWeatherInfo data )
        {
            RemoveObserver();
        }

        private void RemoveObserver()
        {
            _observable.RemoveObserver( this );
        }
    }
}
