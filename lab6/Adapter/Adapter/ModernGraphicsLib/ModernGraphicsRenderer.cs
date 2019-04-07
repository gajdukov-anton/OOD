using System;
using System.IO;

namespace Adapter.ModernGraphicsLib
{
    public class ModernGraphicsRenderer : IDisposable
    {
        private TextWriter _out;
        private bool _drawing = false;

        public ModernGraphicsRenderer( TextWriter streamWriter )
        {
            _out = streamWriter;
        }

        public void BeginDraw()
        {
            if (_drawing)
            {
                throw new Exception( "Drawing has already begun" );
            }
            _out.WriteLine( "<draw>" );
            _drawing = true;
        }

        public void Dispose()
        {
            if(_drawing)
            {
                EndDraw();
            }
        }

        public void DrawLine(Point start, Point end, RGBAColor color )
        {
            if (!_drawing)
            {
                throw new Exception( "DrawLine is allowed between BeginDraw()/EndDraw() only" );
            }
            _out.WriteLine( $"<line fromX={start.X} fromY={start.Y} toX={end.X} toY={end.Y}>" );
            _out.WriteLine( $"  <color r=\"{color.R}\" g=\"{color.G}\" b=\"{color.B}\" a=\"{color.A}\" />" );
            _out.WriteLine( "</line>" );
        }

        public void EndDraw()
        {
            if (!_drawing)
            {
                throw new Exception( "Drawing has not been started" );
            }
            _out.WriteLine( "</draw>" );
            _drawing = false;
        }
    }
}
