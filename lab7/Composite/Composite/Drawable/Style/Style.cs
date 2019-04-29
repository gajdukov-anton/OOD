using System.Drawing;

namespace Composite.Drawable
{
    public class Style : IStyle
    {
        protected Color _color = Color.Empty;
        protected bool _isEnable = false;

        public Style()
        {
        }

        public Style( Color color, bool isEnable )
        {
            _color = color;
            _isEnable = isEnable;
        }

        public void Enable( bool enable )
        {
            _isEnable = enable;
        }

        public Color GetColor()
        {
            return _color;
        }

        public bool IsEnable()
        {
            return _isEnable;
        }

        public void SetColor( Color color )
        {
            _color = color;
        }
    }
}
