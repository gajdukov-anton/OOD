using System.Drawing;

namespace Composite.Drawable
{
    public interface IStyle
    {
        bool IsEnable();
        void Enable( bool enable );

        Color GetColor();
        void SetColor( Color color );   
    }
}
