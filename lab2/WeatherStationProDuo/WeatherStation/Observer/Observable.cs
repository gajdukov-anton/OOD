using System.Collections.Generic;

namespace WeatherStation.Observer
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

    public abstract class Observable<T> : IObservable<T>
    {
        private List<ObserverWithPriority<T>> _observerWithPriorityList = new List<ObserverWithPriority<T>>();
        public LocationKind Location { get; private set; }


        public Observable( LocationKind location )
        {
            Location = location;
        }

        public void RegisterObserver( IObserver<T> observer, int priority )
        {
            if ( _observerWithPriorityList.Count == 0 )
            {
                _observerWithPriorityList.Add( new ObserverWithPriority<T>( observer, priority ) );
            }
            else
            {
                for ( int i = 0; i < _observerWithPriorityList.Count; i++ )
                {
                    if ( _observerWithPriorityList [ i ].priority < priority )
                    {
                        _observerWithPriorityList.Insert( i, new ObserverWithPriority<T>( observer, priority ) );
                        break;
                    }
                    if ( i == _observerWithPriorityList.Count - 1 )
                    {
                        _observerWithPriorityList.Add( new ObserverWithPriority<T>( observer, priority ) );
                        break;
                    }
                }
            }
        }

        public void NotifyObservers()
        {
            T data = GetChangedData();
            var observers = new List<ObserverWithPriority<T>>( _observerWithPriorityList );
            foreach ( var item in observers )
            {
                item.observer.Update( data, this );
            }
        }

        public void RemoveObserver( IObserver<T> observer )
        {
            for ( int i = 0; i < _observerWithPriorityList.Count; i++ )
            {
                if ( _observerWithPriorityList [ i ].observer.Equals( observer ) )
                {
                    _observerWithPriorityList.RemoveAt( i );
                }
            }
        }

        protected abstract T GetChangedData();
    }
}
