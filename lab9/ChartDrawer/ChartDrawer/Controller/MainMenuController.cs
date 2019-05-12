using ChartDrawer.Model;

namespace ChartDrawer.Controller
{
    public class MainMenuController : IMainMenuController
    {
        private IHarmonicContainer _harmonicContainer;

        public MainMenuController( IHarmonicContainer harmonicContainer )
        {
            _harmonicContainer = harmonicContainer;
        }

        public void RemoveHarmonic( int index )
        {
            _harmonicContainer.RemoveHarmonic( index );
            var harmonicCHangesDto = new HarmonicsChangesDto
            {
                DeletedHarmonicIndex = index
            };

            _harmonicContainer.NotifyViews( harmonicCHangesDto );
        }

        public void SetNewAmplitude( int index, double value )
        {
            _harmonicContainer.GetHarmonic( index ).SetAmplitude( value );
            var harmonicCHangesDto = new HarmonicsChangesDto
            {
                ChangedHarmonicIndex = index
            };

            _harmonicContainer.NotifyViews( harmonicCHangesDto );
        }

        public void SetNewFrequency( int index, double value )
        {
            _harmonicContainer.GetHarmonic( index ).SetFrequency( value );
            var harmonicCHangesDto = new HarmonicsChangesDto
            {
                ChangedHarmonicIndex = index
            };

            _harmonicContainer.NotifyViews( harmonicCHangesDto );
        }

        public void SetNewPhase( int index, double value )
        {
            _harmonicContainer.GetHarmonic( index ).SetPhase( value );
            var harmonicCHangesDto = new HarmonicsChangesDto
            {
                ChangedHarmonicIndex = index
            };

            _harmonicContainer.NotifyViews( harmonicCHangesDto );
        }

        public void SetNewHarmonicKind( int index, HarmonicKind value )
        {
            _harmonicContainer.GetHarmonic( index ).SetHarmonicKind( value );
            var harmonicChangesDto = new HarmonicsChangesDto
            {
                ChangedHarmonicIndex = index
            };

            _harmonicContainer.NotifyViews( harmonicChangesDto );
        }

        public IAddingNewHarmonicController GetAddingNewHarmonicController()
        {
            return new AddingNewHarmonicController( _harmonicContainer );
        }
    }
}
