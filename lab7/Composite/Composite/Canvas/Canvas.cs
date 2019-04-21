using System;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace Composite.Canvas
{
    public class Canvas : ICanvas
    {
        private Color _lineColor;
        private TextWriter _textWriter;
        private Point _currentPoint;
        private Graphics _graphics;

        public Canvas( TextWriter textWriter )
        {
            _currentPoint = new Point(0, 0);
            Bitmap bitmap = new Bitmap( 1000, 1000); 
            _graphics = Graphics.FromImage(bitmap);
            _textWriter = textWriter;
        }

        public void BeginFill( int colorRGBA )
        {
            _textWriter.WriteLine( "Begin fill" );
        }

        public void DrawEllipse( double left, double top, double width, double height )
        {
            _textWriter.WriteLine( $"Draw ellipse left: {left} top: {top} width: {width} height: {height} line color: {_lineColor.Name}" );
        }

        public void EndFill()
        {
            _textWriter.WriteLine( "End fill" );
        }

        public void LineTo( double x, double y )
        {
            _textWriter.WriteLine( $"Line to x: {x} y: {y} line color: {_lineColor.Name}" );
            var point = new Point( (int) x, (int) y );
            _graphics.DrawLine( new Pen( _lineColor ), _currentPoint, point );
            _currentPoint = point;
        }

        public void MoveTo( double x, double y )
        {
            _textWriter.WriteLine( $"Move to x: {x} y: {y}" );
        }

        public void SetLineColor( int colorRGBA )
        {
            _lineColor = Color.FromArgb( colorRGBA );
        }
    }
}
