using Composite.Groups;

namespace Composite.Drawable
{
    public interface IShape : IDrawable, IInheritor
    {
        Rect<double> GetFrame();
        void SetFrame( Rect<double> rect );

        IStyle GetOutlineStyle();
        void SetOutlineStyle( IStyle style );

        IStyle GetFillStyle();
        void SetFillStyle( IStyle style );
    }
}
