using Adapter.GraphicsLib;
using Adapter.ModernGraphicsLib;
using System.Drawing;
using System.IO;

namespace Adapter.Application
{
    public class MGREndererClassAdapter : ModernGraphicsRenderer, ICanvas
    {
        public ModernGraphicsLib.Point LatsPoint { get; private set; }
        private RGBAColor _color = new RGBAColor();

        public MGREndererClassAdapter( TextWriter streamWriter )
            : base( streamWriter )
        {
            LatsPoint = new ModernGraphicsLib.Point();
        }

        public void LineTo( int x, int y )
        {
            DrawLine( LatsPoint, new ModernGraphicsLib.Point( x, y ), _color );
            LatsPoint.X = x;
            LatsPoint.Y = y;
        }

        public void MoveTo( int x, int y )
        {
            LatsPoint.X = x;
            LatsPoint.Y = y;
        }

        public void SetColor( int rgbColor )
        {
            Color color = Color.FromArgb( rgbColor );
            _color.A = color.A;
            _color.B = color.B;
            _color.G = color.G;
            _color.R = color.R;
        }
    }
}
