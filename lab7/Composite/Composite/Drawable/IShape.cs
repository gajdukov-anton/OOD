using Composite.Groups;

namespace Composite.Drawable
{
    public interface IShape : IDrawable
    {
        Rect? GetFrame();
        void SetFrame( Rect rect );

        IOutLineStyle GetOutlineStyle();

        IStyle GetFillStyle();
    }
}
