using System;
using System.Drawing;

namespace Adapter.GraphicsLib
{
    public class Canvas : ICanvas
    {

        public void LineTo( int x, int y )
        {
            Console.WriteLine( $"LineTo( {x}, {y} )" );
        }

        public void MoveTo( int x, int y )
        {
            Console.WriteLine( $"MoveTo( {x}, {y} )" );
        }

        public void SetColor( int rgbColor )
        {
            Color color = Color.FromArgb( rgbColor );
            Console.WriteLine( $"SetColor( #{Convert.ToString( color.R, 16).ToUpper()}" +
                $"{Convert.ToString( color.G, 16 ).ToUpper()}" +
                $"{Convert.ToString( color.B, 16 ).ToUpper()} )" );
        } 
    }
}
