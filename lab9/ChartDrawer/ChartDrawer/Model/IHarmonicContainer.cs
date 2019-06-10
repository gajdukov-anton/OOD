using ChartDrawer.View;
using System.Collections.Generic;

namespace ChartDrawer.Model
{
    public interface IHarmonicContainer : IHarmonicContainerPresentation
    {
        void AddHarmonic( IHarmonic harmonic );
        void RemoveHarmonic( int index );
        List<IHarmonic> GetAllHarmonic();
    }
}
