using System.Collections.Generic;
using System;
using IObserver = ChartDrawer.View.IObserver;

namespace ChartDrawer.Model
{
    public class HarmonicContainer : IHarmonicContainer, IHarmonicContainerPresentation
    {
        private List<IHarmonic> _harmonics = new List<IHarmonic>();
        private List<IObserver> _observers = new List<IObserver>();

        public HarmonicContainer()
        {
        }

        public void AddHarmonic( IHarmonic harmonic )
        {
            _harmonics.Add( harmonic );
        }

        public IHarmonic[] GetAll()
        {
            return _harmonics.ToArray();
        }

        public int GetHarmonicCount()
        {
            return _harmonics.Count;
        }

        public IHarmonic GetHarmonic( int index )
        {
            if (index >= 0 && index < _harmonics.Count )
            {
                return _harmonics[ index ];
            }
            throw new IndexOutOfRangeException();
        }


        public void RegisterObserver( IObserver observer )
        {
            _observers.Add( observer );
        }

        public void RemoveObserver( int index )
        {
            _observers.RemoveAt( index );
        }

        public void NotifyViews( HarmonicsChangesDto harmonicsChangesDto )
        {
            var observers = new List<IObserver>( _observers );
            foreach ( var observer in observers )
            {
                observer.Update( harmonicsChangesDto );
            }
        }

        public void RemoveHarmonic( int index )
        {
            if ( index >= 0 && index < _harmonics.Count )
            {
                _harmonics.RemoveAt( index );
                return;
            }
            throw new IndexOutOfRangeException();
        }

        public IHarmonicPresentation[] GetAllPresentation()
        {
            return _harmonics.ToArray();
        }

        public IHarmonicPresentation GetHarmonicPresentation( int index )
        {
            if ( index >= 0 && index < _harmonics.Count )
            {
                return _harmonics [ index ];
            }
            throw new IndexOutOfRangeException();
        }

        private List<IHarmonicPresentation> GetHarmonicPresentationList()
        {
            return new List<IHarmonicPresentation>( _harmonics );
        }
    }
}
