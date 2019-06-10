using System.Collections.Generic;

namespace Composite.Style
{
    public class OutLineGroupStyle : GroupStyle<IOutLineStyle>, IOutLineStyle
    {
        public OutLineGroupStyle( IEnumerable<IOutLineStyle> styles )
            : base( styles )
        {
        }

        public int? GetLineWidth()
        {
            int? width = GetFirstWidth();
            foreach ( var style in _styles )
            {
                if ( style.GetLineWidth() != width )
                {
                    return null;
                }
            }
            return width;
        }

        public void SetLineWidth( int width )
        {
            foreach ( var style in _styles )
            {
                style.SetLineWidth( width );
            }
        }

        private int? GetFirstWidth()
        {
            foreach ( var style in _styles )
            {
                return style.GetLineWidth();
            }

            return null;
        }
    }
}
