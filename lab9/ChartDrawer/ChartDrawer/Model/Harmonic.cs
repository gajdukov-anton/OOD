namespace ChartDrawer.Model
{
    public class Harmonic : IHarmonic
    {
        private double _amplitude;
        private double _frequency;
        private double _phase;
        private HarmonicKind _harmonicKind;
        private IHarmonicObserver _observer;

        public Harmonic(double amplitude, double frequency, double phase, HarmonicKind harmonicKind )
        {
            _amplitude = amplitude;
            _frequency = frequency;
            _phase = phase;
            _harmonicKind = harmonicKind;
        }

        public Harmonic()
        {
            _harmonicKind = HarmonicKind.Sin;
            _amplitude = 1;
            _frequency = 1;
            _phase = 0;
        }

        public void SetAmplitude( double amplitude )
        {
            _amplitude = amplitude;
            if (_observer != null)
            {
                _observer.HarmonicPropertiesChanged();
            }
        }

        public void SetFrequency( double frequency )
        {
            _frequency = frequency;
            if ( _observer != null )
            {
                _observer.HarmonicPropertiesChanged();
            }
        }

        public void SetPhase( double phase )
        {
            _phase = phase;
            if ( _observer != null )
            {
                _observer.HarmonicPropertiesChanged();
            }
        }

        public void SetHarmonicKind(HarmonicKind harmonicKind)
        {
            _harmonicKind = harmonicKind;
            if ( _observer != null )
            {
                _observer.HarmonicPropertiesChanged();
            }
        }

        public HarmonicKind GetHarmonicKind()
        {
            return _harmonicKind;
        }

        public double GetAmplitude()
        {
            return _amplitude;
        }

        public double GetFrequency()
        {
            return _frequency;
        }

        public double GetPhase()
        {
            return _phase;
        }

        public void SetObserver( IHarmonicObserver observer )
        {
            _observer = observer;
        }
    }
}
