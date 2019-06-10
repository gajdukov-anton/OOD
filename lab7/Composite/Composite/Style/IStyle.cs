using System.Drawing;

namespace Composite.Style
{
    public interface IStyle
    {
        bool IsEnabled();
        void Enable( bool enable );
        Color GetColor();
        void SetColor( Color color );   
    }
}
