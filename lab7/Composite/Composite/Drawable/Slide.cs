using System.Collections.Generic;
using System.Drawing;
using Composite.Canvas;
using Composite.Groups;

namespace Composite.Drawable
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
            _groupShapes = new GroupShape();
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
           /* canvas.BeginFill( _backgroundColor.ToArgb() );
            canvas.SetLineColor( _backgroundColor.ToArgb() );
            canvas.LineTo( 0, _height );
            canvas.LineTo( _width, _height );
            canvas.LineTo( _width, 0 );
            canvas.LineTo( 0, 0 );
            canvas.EndFill();*/
        }

        private void DrawShapes( ICanvas canvas )
        {
            for (int i = 0; i < _groupShapes.GetShapesCount(); i++ )
            {
                _groupShapes.GetShapeAtIndex( i ).Draw( canvas );
            }
        }
    }
}
