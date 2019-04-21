using Composite.Groups;
using System.Drawing;

namespace Composite.Drawable
{
    public interface ISlide : IDrawable
    {
        double GetWidth();
        double GetHeight();
        void SetBackgroundColor( int colorRGBA );
        Color GetBackgroundColor();
        IShapes GetShapes();
    }
}
