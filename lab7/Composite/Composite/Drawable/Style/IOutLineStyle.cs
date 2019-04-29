namespace Composite.Drawable
{
    public interface IOutLineStyle : IStyle
    {
        void SetLineWidth( int width );
        int? GetLineWidth();
    }
}
