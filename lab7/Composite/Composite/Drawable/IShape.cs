using Composite.Groups;

namespace Composite.Drawable
{
    public interface IShape : IDrawable
    {
        Rect<double> GetFrame();
        void SetFrame( Rect<double> rect );

        IOutLineStyle GetOutlineStyle();

        IStyle GetFillStyle();
    }
}
