using System.Collections.Generic;

namespace WeatherStation
{
    struct ObserverWithPriority<T>
    {
        public int priority;
        public IObserver<T> observer;

        public ObserverWithPriority( IObserver<T> observer, int priority ) : this()
        {
            this.observer = observer;
            this.priority = priority;
        }
    }

    abstract class CObservable<T> : IObservable<T>
    {
        private List<ObserverWithPriority<T>> _observers = new List<ObserverWithPriority<T>>();

        public void RegisterObserver( IObserver<T> observer, int priority )
        {
            if ( _observers.Count == 0 )
            {
                _observers.Add( new ObserverWithPriority<T>( observer, priority ) );
            }
            else
            {
                for ( int i = 0; i < _observers.Count; i++ )
                {
                    if ( _observers [ i ].priority < priority )
                    {
                        _observers.Insert( i, new ObserverWithPriority<T>( observer, priority ) );
                        break;
                    }
                    if ( i == _observers.Count - 1 )
                    {
                        _observers.Add( new ObserverWithPriority<T>( observer, priority ) );
                        break;
                    }
                }
            }
        }

        public void NotifyObservers()
        {
            T data = GetChangedData();
            foreach ( var observer in _observers )
            {
                observer.observer.Update( data );
            }
        }

        public void RemoveObserver( IObserver<T> observer )
        {
            for ( int i = 0; i < _observers.Count; i++ )
            {
                if ( _observers [ i ].observer.Equals( observer ) )
                {
                    _observers.RemoveAt( i );
                }
            }
        }

        protected abstract T GetChangedData();
    }
}
