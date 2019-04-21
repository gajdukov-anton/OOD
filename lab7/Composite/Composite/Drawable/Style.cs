using System.Drawing;

namespace Composite.Drawable
{
    public class Style : IStyle
    {
        private Color _color;
        private bool _isEnable = false;

        public Style()
        {
            _color = Color.Empty;
            _isEnable = false;
        }

        public Style(Color color, bool isEnable)
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

        public override bool Equals( object obj )
        {
            return ( ( IStyle ) obj ).GetColor() == _color && ( ( IStyle ) obj ).IsEnable() == _isEnable;
        }
    }
}
