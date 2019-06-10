using ChartDrawer.Model;
using ChartDrawer.View.MainMenu;

namespace ChartDrawer.Controller
{
    public class MainMenuController : IMainMenuController
    {
        private IHarmonicContainer _harmonicContainer;
        public MainMenuView MainMenuView { private set; get; }

        public MainMenuController( IHarmonicContainer harmonicContainer )
        {
            _harmonicContainer = harmonicContainer;
            MainMenuView = new MainMenuView( _harmonicContainer, this );
            _harmonicContainer.AddObserver( MainMenuView );
        }

        public void RemoveHarmonic( int index )
        {
            _harmonicContainer.RemoveHarmonic( index );
        }

        public void SetNewAmplitude( int index, double value )
        {
            _harmonicContainer.GetAllHarmonic()[ index ].SetAmplitude( value );
        }

        public void SetNewFrequency( int index, double value )
        {
            _harmonicContainer.GetAllHarmonic() [ index ].SetFrequency( value );
        }

        public void SetNewPhase( int index, double value )
        {
            _harmonicContainer.GetAllHarmonic() [ index ].SetPhase( value );
        }

        public void SetNewHarmonicKind( int index, HarmonicKind value )
        {
            _harmonicContainer.GetAllHarmonic() [ index ].SetHarmonicKind( value );
        }

        public void StartAddingNewHarmonic()
        {
            var addingHarmonicController = new AddingHarmonicController( _harmonicContainer, MainMenuView );
            addingHarmonicController.Start();
        }
    }
}
