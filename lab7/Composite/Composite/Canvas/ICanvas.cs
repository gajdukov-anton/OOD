
namespace Composite.Canvas
{
    public interface ICanvas
    {
        void SetLineColor( int colorRGBA );
        void BeginFill( int colorRGBA );
        void EndFill();
        void MoveTo( double x, double y );
        void LineTo( double x, double y );
        void DrawEllipse( double left, double top, double width, double height );
    }
}
