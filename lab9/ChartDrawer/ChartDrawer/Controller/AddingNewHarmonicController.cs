using ChartDrawer.Model;

namespace ChartDrawer.Controller
{
    public class AddingNewHarmonicController : IAddingNewHarmonicController
    {
        private IHarmonicContainer _harmonicContainer;

        public AddingNewHarmonicController( IHarmonicContainer harmonicContainer )
        {
            _harmonicContainer = harmonicContainer;
        }

        public void AddNewHarmonic( HarmonicPropertiesDto harmonicPropertiesDto )
        {
            _harmonicContainer.AddHarmonic( new Harmonic( 
                harmonicPropertiesDto.Amplitude,
                harmonicPropertiesDto.Frequency,
                harmonicPropertiesDto.Phase,
                harmonicPropertiesDto.HarmonicKind) );
            _harmonicContainer.NotifyViews( new HarmonicsChangesDto
            {
                AddedHarmonicIndex = _harmonicContainer.GetHarmonicCount() - 1
            } );
        }

    }
}
