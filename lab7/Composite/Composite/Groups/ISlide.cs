using Composite.Shape;
using System.Drawing;

namespace Composite.Groups
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
