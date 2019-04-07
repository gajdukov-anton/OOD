using System.Drawing;

namespace Adapter.GraphicsLib
{
    public interface ICanvas
    {
        void SetColor( int rgbColor ); 
        void MoveTo( int x, int y );
        void LineTo( int x, int y );
    }
}
