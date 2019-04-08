using Adapter.GraphicsLib;
using Adapter.ModernGraphicsLib;
using System.Drawing;
using System.IO;

namespace Adapter.Application
{
    public class MGREndererClassAdapter : ModernGraphicsRenderer, ICanvas
    {
        public ModernGraphicsLib.Point _lastPoint = new ModernGraphicsLib.Point( 0, 0 );
        private RGBAColor _color = new RGBAColor();

        public MGREndererClassAdapter( TextWriter streamWriter )
            : base( streamWriter )
        {
        }

        public void LineTo( int x, int y )
        {
            DrawLine( _lastPoint, new ModernGraphicsLib.Point( x, y ), _color );
            _lastPoint.X = x;
            _lastPoint.Y = y;
        }

        public void MoveTo( int x, int y )
        {
            _lastPoint.X = x;
            _lastPoint.Y = y;
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
