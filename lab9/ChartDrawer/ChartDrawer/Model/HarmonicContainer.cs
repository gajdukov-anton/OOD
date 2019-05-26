using System.Collections.Generic;
using System;

namespace ChartDrawer.Model
{
    public class HarmonicContainer : IHarmonicContainer
    {
        private List<IHarmonic> _harmonics = new List<IHarmonic>();
        private IHarmonicContainerObserver _observer;

        public HarmonicContainer()
        {
        }

        public void AddHarmonic( IHarmonic harmonic )
        {
            _harmonics.Add( harmonic );
            if ( _observer != null )
            {
                _observer.AddedNewHarmonic( _harmonics.Count - 1 );
            }
        }

        public void RemoveHarmonic( int index )
        {
            if ( index >= 0 && index < _harmonics.Count )
            {
                _harmonics.RemoveAt( index );
                if ( _observer != null )
                {
                    _observer.RemovedHarmonic( index );
                }
                return;
            }
        }

        public List<IHarmonic> GetAllHarmonic()
        {
            return _harmonics;
        }

        public int GetHarmonicCount()
        {
            return _harmonics.Count;
        }
        
        public void SetViewObserver( IHarmonicContainerObserver observer )
        {
            _observer = observer;
        }

        public IHarmonicPresentation[] GetAllPresentation()
        {
            return _harmonics.ToArray();
        }
    }
}