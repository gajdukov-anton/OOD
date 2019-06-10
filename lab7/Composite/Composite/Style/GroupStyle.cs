using System.Collections.Generic;
using System.Drawing;

namespace Composite.Style
{
    public class GroupStyle<T> : IStyle where T : IStyle
    {
        protected readonly IEnumerable<T> _styles;

        public GroupStyle( IEnumerable<T> styles )
        {
            _styles = styles;
        }

        public void Enable( bool enable )
        {
            foreach ( var style in _styles )
            {
                style.Enable( enable );
            }
        }

        public bool IsEnabled()
        {
            bool isEnable = GetFirstEnable();
            foreach ( var stytle in _styles )
            {
                if ( stytle.IsEnabled() != isEnable )
                {
                    return false;
                }
            }
            return isEnable;
        }

        public void SetColor( Color color )
        {
            foreach ( var style in _styles )
            {
                style.SetColor( color );
            }
        }

        public Color GetColor()
        {
            var color = GetFirstColor();
            foreach ( var style in _styles )
            {
                if ( style.GetColor() != color )
                {
                    return Color.Empty;
                }
            }
            return color;
        }

        private Color GetFirstColor()
        {
            foreach ( var style in _styles )
            {
                return style.GetColor();
            }
            return Color.Empty;
        }

        private bool GetFirstEnable()
        {
            foreach ( var style in _styles )
            {
                return style.IsEnabled();
            }
            return false;
        }
    }
}
