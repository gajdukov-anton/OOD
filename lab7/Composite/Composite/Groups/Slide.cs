using System.Collections.Generic;
using System.Drawing;
using Composite.Canvas;

namespace Composite.Groups
{
    public class Slide : ISlide
    {
        private int _width;
        private int _height;
        private Color _backgroundColor;
        private IShapes _groupShapes;

        public Slide( int width, int height )
        {
            _width = width;
            _height = height;
            _groupShapes = new Shapes();
        }

        public void Draw( ICanvas canvas )
        {
            DrawBackground( canvas );
            DrawShapes( canvas );
        }

        public Color GetBackgroundColor()
        {
            return _backgroundColor;
        }

        public double GetHeight()
        {
            return _height;
        }

        public IShapes GetShapes()
        {
            return _groupShapes;
        }

        public double GetWidth()
        {
            return _width;
        }

        public void SetBackgroundColor( int colorRGBA )
        {
            _backgroundColor = Color.FromArgb( colorRGBA );
        }

        private void DrawBackground( ICanvas canvas )
        {

            canvas.SetFillColor( _backgroundColor.ToArgb() );
            canvas.FillPolygon( GetVertices() );

        }

        private List<Canvas.Point> GetVertices()
        {
            var result = new List<Canvas.Point>
            {
                new Canvas.Point { X = 0, Y = 0 },
                new Canvas.Point { X = 0, Y = _height },
                new Canvas.Point { X = _width, Y = _height },
                new Canvas.Point { X = _width, Y = 0 }
            };
            return result;
        }

        private void DrawShapes( ICanvas canvas )
        {
            for ( int i = 0; i < _groupShapes.GetShapesCount(); i++ )
            {
                _groupShapes.GetShapeAtIndex( i ).Draw( canvas );
            }
        }
    }
}
