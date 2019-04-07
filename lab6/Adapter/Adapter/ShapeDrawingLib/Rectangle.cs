using Adapter.GraphicsLib;
using System.Drawing;

namespace Adapter.ShapeDrawingLib
{
    public class Rectangle : ICanvasDrawable
    {
        private Point _leftTop;
        private int _width;
        private int _height;
        int _color;

        public Rectangle( Point leftTop, int width, int height, int colorRGB = 0x000000 )
        {
            _leftTop = leftTop;
            _width = width;
            _height = height;
            // _color = Color.FromArgb( colorRGB );
            _color = colorRGB;
        }

        public void Draw( ICanvas canvas )
        {
            canvas.SetColor( _color );
            canvas.MoveTo( _leftTop.X, _leftTop.Y );
            canvas.LineTo( _leftTop.X, _leftTop.Y - _height );
            canvas.LineTo( _leftTop.X + _width, _leftTop.Y - _height );
            canvas.LineTo( _leftTop.X + _width, _leftTop.Y );
            canvas.LineTo( _leftTop.X, _leftTop.Y );
        }
    }
}
