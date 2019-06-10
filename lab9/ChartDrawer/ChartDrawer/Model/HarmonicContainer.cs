using System.Collections.Generic;

namespace ChartDrawer.Model
{
    public class HarmonicContainer : IHarmonicContainer
    {
        private List<IHarmonic> _harmonics = new List<IHarmonic>();
        private List<IHarmonicContainerObserver> _observers;

        public HarmonicContainer()
        {
            _observers = new List<IHarmonicContainerObserver>();
        }

        public void AddHarmonic( IHarmonic harmonic )
        {
            _harmonics.Add( harmonic );
            if ( _observers != null )
            {
                foreach ( var observer in _observers )
                {
                    observer.AddedNewHarmonic( _harmonics.Count - 1 );
                }
            }
        }

        public void RemoveHarmonic( int index )
        {
            if ( index >= 0 && index < _harmonics.Count )
            {
                _harmonics.RemoveAt( index );
                if ( _observers != null )
                {
                    foreach ( var observer in _observers )
                    {
                        observer.RemovedHarmonic( index );
                    }
                }
                return;
            }
        }

        public List<IHarmonic> GetAllHarmonic()
        {
            return _harmonics;
        }

        public void AddObserver( IHarmonicContainerObserver observer )
        {
            _observers.Add( observer );
        }

        public IHarmonicPresentation [] GetAllPresentation()
        {
            return _harmonics.ToArray();
        }
    }
}