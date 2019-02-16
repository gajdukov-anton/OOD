using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherStation
{
    interface IObservable<T>
    {
        void RegisterObserver( IObserver<T>  observer, int priority);
        void NotifyObservers();
        void RemoveObserver( IObserver<T> observer );
    }
}
