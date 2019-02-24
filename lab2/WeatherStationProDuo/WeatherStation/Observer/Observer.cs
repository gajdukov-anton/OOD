using WeatherStation.WeatherData;

namespace WeatherStation.Observer
{
    public abstract class Observer<T> : IObserver<T>
    {
        protected Observable<T> _weatherStationOutside;
        protected Observable<T> _weatherStationInside;

        public abstract void Update(T data);
    }
}
