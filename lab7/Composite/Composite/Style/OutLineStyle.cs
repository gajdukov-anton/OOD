using System.Drawing;

namespace Composite.Style
{
    public class OutLineStyle : Style, IOutLineStyle
    {
        private int? _lineWidth;

        public OutLineStyle()
            :base()
        {
            _lineWidth = null;
        }

        public OutLineStyle( Color color, bool isEnable, int width )
            :base(color, isEnable)
        {
            _lineWidth = width;
        }

        public int? GetLineWidth()
        {
            return _lineWidth;
        }

        public void SetLineWidth(int width)
        {
            _lineWidth = width;
        }
    }
}
