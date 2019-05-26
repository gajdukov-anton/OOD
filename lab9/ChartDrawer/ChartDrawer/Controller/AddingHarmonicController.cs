using ChartDrawer.Model;
using ChartDrawer.View;

namespace ChartDrawer.Controller
{
    public class AddingHarmonicController : IAddingHarmonicController
    {
        private IHarmonicContainer _harmonicContainer;
        private IHarmonic _harmonic;
        private AddingHarmonicsView _addingNewHarmonicsView;
        private IHarmonicObserver _newHarmonicObserver;

        public AddingHarmonicController( IHarmonicContainer harmonicContainer, IHarmonicObserver newHarmonicObserver )
        {
            _harmonicContainer = harmonicContainer;
            _newHarmonicObserver = newHarmonicObserver;
            _harmonic = new Harmonic();
            _addingNewHarmonicsView = new AddingHarmonicsView( _harmonic, this );
            _harmonic.SetViewObserver( _addingNewHarmonicsView );
        }

        public void Start()
        {
            _addingNewHarmonicsView.Show();
        }

        public void AddNewHarmonic()
        {
            _harmonic.SetViewObserver( _newHarmonicObserver );
            _harmonicContainer.AddHarmonic( _harmonic );
            _addingNewHarmonicsView.Close();
        }

        public void Cancel()
        {
            _addingNewHarmonicsView.Close();
        }

        public void SetAmplitude( double value )
        {
            _harmonic.SetAmplitude( value );
        }

        public void SetFrequency( double value )
        {
            _harmonic.SetFrequency( value );
        }

        public void SetHarmonicKind( HarmonicKind kind )
        {
            _harmonic.SetHarmonicKind( kind );
        }

        public void SetPhase( double value )
        {
            _harmonic.SetPhase( value );
        }
    }
}
