using WeatherStation.WeatherData;

namespace WeatherStation.Observer
{
    public abstract class Observer<T> : IObserver<T>
    {
        protected IObservable<T> _lastWeatherStation;
        protected IObservable<T> _weatherStationOutside;
        protected IObservable<T> _weatherStationInside;

        public abstract void Update(T data, IObservable<T> observable );
        public IObservable<T> GetLastWeatherStation()
        {
            return _lastWeatherStation;
        }
    }
}
