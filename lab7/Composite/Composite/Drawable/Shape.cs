using Composite.Canvas;
using System.Collections.Generic;

namespace Composite.Drawable
{
    public abstract class Shape : IShape
    {
        protected IOutLineStyle _outLineStyle = new OutLineStyle();
        protected IStyle _fillStyle = new Style();
        protected Rect _frame;

        public Shape( Rect frame, IStyle fillStyle = null, IOutLineStyle outLineStyle = null)
        {
            _frame = frame;
            _fillStyle = fillStyle ?? _fillStyle;
            _outLineStyle = outLineStyle ?? _outLineStyle;
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

        public Rect? GetFrame()
        {
            return _frame;
        }

        public void SetFrame( Rect rect )
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
