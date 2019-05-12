using Composite.Drawable;
using System.Collections.Generic;

namespace Composite.Groups
{
    public class OutLineGroupStyle : GroupStyle, IOutLineStyle
    {
        public OutLineGroupStyle( IEnumerable<IOutLineStyle> styles )
            : base( styles )
        {
        }

        public int? GetLineWidth()
        {
            int? width = GetFirstWidth();
            return IsAllLineWidthEquals() ? width : null;
        }

        public void SetLineWidth( int width )
        {
            foreach ( var style in _styles )
            {
                ( ( IOutLineStyle ) style ).SetLineWidth( width );
            }
        }

        private int? GetFirstWidth()
        {
            foreach ( var style in _styles )
            {
                return ( ( IOutLineStyle ) style ).GetLineWidth();
            }

            return null;
        }

        private bool IsAllLineWidthEquals()
        {
            int? width = GetFirstWidth();
            if ( _styles == null || IsStylesEmpty() )
            {
                return false;
            }

            foreach ( var style in _styles )
            {
                if ( ( ( IOutLineStyle ) style ).GetLineWidth() != width )
                {
                    return false;
                }
            }
            return true;
        }
    }
}
