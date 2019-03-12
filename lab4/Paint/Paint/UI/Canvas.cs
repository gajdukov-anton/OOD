using Paint.Shapes;
using System;
using System.IO;

namespace Paint.UI
{
    public class Canvas : ICanvas, IDisposable
    {
        private Color _color;
        private TextWriter _textWriter;

        public Canvas( TextWriter textWriter )
        {
            _textWriter = textWriter;
        }

        public void SetColor( Color color )
        {
            _color = color;
        }

        /*public void DrawSeparator()
        {
            _textWriter.WriteLine( "-------------------" );
        }*/
        public void DrawLine( Point from, Point to )
        {
            _textWriter.WriteLine( "Line" );
            _textWriter.WriteLine( $"From x: {from.X} y: {from.Y}" );
            _textWriter.WriteLine( $"To x: {to.X} y: {to.Y}" );
        }

        public void DrawEllipse( double left, double top, double width, double height )
        {
            _textWriter.WriteLine( "Ellipse" );
            _textWriter.WriteLine( $"Left: {left}" );
            _textWriter.WriteLine( $"Top: {top}" );
            _textWriter.WriteLine( $"Width: {width}" );
            _textWriter.WriteLine( $"Height: {height}" );
        }

       /* public void DrawText(string text)
        {
            _textWriter.WriteLine( text );
        }*/

        public void Dispose()
        {
            _textWriter.Dispose();
        }
    }
}
