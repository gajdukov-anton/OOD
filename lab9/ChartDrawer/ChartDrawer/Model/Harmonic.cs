namespace ChartDrawer.Model
{
    public class Harmonic : IHarmonic, IHarmonicPresentation
    {
        /* public double Amplitude { get; set; }
         public double Frequency { get; set; }
         public double Phase { get; set; }*/
        private double _amplitude;
        private double _frequency;
        private double _phase;
        private HarmonicKind _harmonicKind;

        public Harmonic(double amplitude, double frequency, double phase, HarmonicKind harmonicKind )
        {
            _amplitude = amplitude;
            _frequency = frequency;
            _phase = phase;
            _harmonicKind = harmonicKind;
        }

        public Harmonic()
        {

        }

        public void SetAmplitude( double amplitude )
        {
            _amplitude = amplitude;
        }

        public void SetFrequency( double frequency )
        {
            _frequency = frequency;
        }

        public void SetPhase( double phase )
        {
            _phase = phase;
        }

        public void SetHarmonicKind(HarmonicKind harmonicKind)
        {
            _harmonicKind = harmonicKind;
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
    }
}
