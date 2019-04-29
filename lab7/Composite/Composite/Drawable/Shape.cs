using Composite.Canvas;
using Composite.Groups;
using System.Collections.Generic;

namespace Composite.Drawable
{
    public abstract class Shape : IShape
    {
        protected IOutLineStyle _outLineStyle = new OutLineStyle();
        protected IStyle _fillStyle = new Style();
        protected Rect<double> _frame;

        public Shape( Rect<double> frame, IStyle fillStyle, IOutLineStyle outLineStyle )
        {
            _frame = frame;
            _fillStyle = fillStyle;
            _outLineStyle = outLineStyle;
        }

        public abstract void Draw( ICanvas canvas );

        public IStyle GetFillStyle()
        {
            return _fillStyle;
        }

        public IOutLineStyle GetOutlineStyle()
        {
            return _outLineStyle;
        }

        public Rect<double> GetFrame()
        {
            return _frame;
        }

        public void SetFrame( Rect<double> rect )
        {
            _frame = rect;
        }

        protected abstract List<Point> GetPoints();

        protected void SetLineColorToCanvas( ICanvas canvas )
        {
            if ( _fillStyle.IsEnable() )
            {
                canvas.SetLineColor( _fillStyle.GetColor().ToArgb() );
            }
        }

        protected void SetLineWidth( ICanvas canvas )
        {
            if ( _fillStyle.IsEnable() )
            {
                canvas.SetLineWidth( _outLineStyle.GetLineWidth() ?? 0 );
            }
        }
    }
}
