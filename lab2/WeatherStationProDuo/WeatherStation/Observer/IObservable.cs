namespace WeatherStation.Observer
{
    public interface IObservable<T>
    {
        void RegisterObserver( IObserver<T>  observer, int priority);
        void NotifyObservers();
        void RemoveObserver( IObserver<T> observer );
        LocationKind Location { get; }
    }
}
