using Adapter.GraphicsLib;
using System.Drawing;

namespace Adapter.ShapeDrawingLib
{
    public class Triangle : ICanvasDrawable
    {
        private Point _point1;
        private Point _point2;
        private Point _point3;
        private int _color;

        public Triangle(Point point1, Point point2, Point point3, int color = 0x000000 )
        {
            //_color = Color.FromArgb( color );
            _color = color;
            _point1 = point1;
            _point2 = point2;
            _point3 = point3;
        }

        public void Draw( ICanvas canvas )
        {
            canvas.SetColor( _color );
            canvas.MoveTo( _point1.X, _point1.Y );
            canvas.LineTo( _point2.X, _point2.Y );
            canvas.LineTo( _point3.X, _point3.Y );
            canvas.LineTo( _point1.X, _point1.Y );
        }
    }
}
