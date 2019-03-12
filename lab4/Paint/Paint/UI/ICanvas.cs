using Paint.Shapes;

namespace Paint.UI
{
    public interface ICanvas
    {
        void SetColor( Color color );
        void DrawLine( Point from, Point to );
        void DrawEllipse( double left, double top, double width, double height );
    }
}
