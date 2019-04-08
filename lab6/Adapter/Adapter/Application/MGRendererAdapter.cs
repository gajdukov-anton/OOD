using Adapter.GraphicsLib;
using Adapter.ModernGraphicsLib;
using System;
using System.Drawing;

namespace Adapter.Application
{
    public class MGRendererAdapter : ICanvas, IDisposable
    {
        private RGBAColor _color = new RGBAColor();
        private ModernGraphicsRenderer _renderer;
        private ModernGraphicsLib.Point _lastPoint = new ModernGraphicsLib.Point( 0, 0 );

        public MGRendererAdapter( ModernGraphicsRenderer renderer )
        {
            _renderer = renderer;
        }

        public void BeginDraw()
        {
            _renderer.BeginDraw();
        }

        public void Dispose()
        {
            _renderer.Dispose();
        }

        public void LineTo( int x, int y )
        {
            _renderer.DrawLine( _lastPoint, new ModernGraphicsLib.Point( x, y ), _color );
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
            Color color =  Color.FromArgb( rgbColor );
            _color.A = color.A;
            _color.B = color.B;
            _color.G = color.G;
            _color.R = color.R;
        }
    }
}
