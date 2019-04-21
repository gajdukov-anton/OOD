using Composite.Drawable;

namespace Composite.Groups
{
    public interface INode
    {
        void UpdateOutLineStyle( IStyle style = null );
        void UpdateFillStyle( IStyle style = null );
    }
}
