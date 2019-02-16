namespace WeatherStation
{
    interface IObservable<T>
    {
        void RegisterObserver( IObserver<T>  observer);
        void NotifyObservers();
        void RemoveObserver( IObserver<T> observer );
    }
}
