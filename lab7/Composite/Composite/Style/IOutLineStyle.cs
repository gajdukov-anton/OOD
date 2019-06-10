namespace Composite.Style
{
    public interface IOutLineStyle : IStyle
    {
        void SetLineWidth( int width );
        int? GetLineWidth();
    }
}
