using System.Collections.Generic;

namespace WeatherStation
{
    abstract class CObservable<T> : IObservable<T>
    {
        private HashSet<IObserver<T>> _observers = new HashSet<IObserver<T>>();

        public void RegisterObserver( IObserver<T> observer )
        {
            _observers.Add( observer );
        }

        public void NotifyObservers()
        {
            T data = GetChangedData();
            foreach ( var observer in _observers )
            {
                observer.Update( data );
            }
        }

        public void RemoveObserver( IObserver<T> observer )
        {
            _observers.Remove( observer );
        }

        protected abstract T GetChangedData();
    }
}