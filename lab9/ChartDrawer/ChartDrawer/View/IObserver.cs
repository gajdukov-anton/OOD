using ChartDrawer.Model;

namespace ChartDrawer.View
{
    public interface IObserver
    {
        void Update( HarmonicsChangesDto harmonicsChangesDto );
    }
}
