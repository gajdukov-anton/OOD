using Composite.Style;

namespace Composite.Shape
{
    public interface IShape : IDrawable
    {
        Rect? GetFrame();
        void SetFrame( Rect rect );
        IOutLineStyle GetOutlineStyle();
        IStyle GetFillStyle();
    }
}
