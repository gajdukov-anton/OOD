using System.Collections.Generic;
using System;
using ChartDrawer.View;
using System.Linq;

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
              //  var harmonicChangesListData = new ContainerActionInfo( _harmonics.Count - 1, null );
                _observer.AddedNewHarmonic( _harmonics.Count - 1 );
             //   _observer.UpdateSumHarmonicVizualization();
            }
        }

        public void RemoveHarmonic( int index )
        {
            if ( index >= 0 && index < _harmonics.Count )
            {
                _harmonics.RemoveAt( index );
                if ( _observer != null )
                {
                    /* var harmonicChangesListData = new ContainerActionInfo( null, index );
                     _observer.UpdateList( harmonicChangesListData );
                     _observer.UpdateSumHarmonicVizualization(); */
                    _observer.RemovedHarmonic( index );
                }
                return;
            }
            throw new IndexOutOfRangeException();
        }

        public List<IHarmonic> GetAllHarmonic()
        {
            return _harmonics;
        }

        public int GetHarmonicCount()
        {
            return _harmonics.Count;
        }

     /*   public IHarmonic GetHarmonic( int index )
        {
            if ( index >= 0 && index < _harmonics.Count )
            {
                return _harmonics [ index ];
            }
            throw new IndexOutOfRangeException();
        }*/
        
        public void SetViewObserver( IHarmonicContainerObserver observer )
        {
            _observer = observer;
        }

        public IHarmonicPresentation[] GetAllPresentation()
        {
            return _harmonics.ToArray();
        }

     /*   public IHarmonicPresentation GetHarmonicPresentation( int index )
        {
            if ( index >= 0 && index < _harmonics.Count )
            {
                return _harmonics [ index ];
            }
            throw new IndexOutOfRangeException();
        }*/
    }
}