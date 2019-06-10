using Composite.Canvas;
using Composite.Style;

namespace Composite.Shape
{
    public class Elipse : Shape
    {
        public Elipse( Rect frame, IStyle fillStyle = null, IOutLineStyle outLineStyle = null )
            : base( frame, fillStyle, outLineStyle )
        { }

        public override void Draw( ICanvas canvas )
        {
            if (_fillStyle.IsEnabled())
            {
                canvas.SetFillColor( _fillStyle.GetColor().ToArgb() );
                canvas.FillEllipse( new Point { X = _frame.left + _frame.width / 2, Y = _frame.top + _frame.height / 2}, _frame.width / 2, _frame.height / 2 );
            }
            if (_outLineStyle.IsEnabled())
            {
                canvas.SetLineColor( _outLineStyle.GetColor().ToArgb() );
                canvas.SetLineWidth( _outLineStyle.GetLineWidth() ?? 0 );
                canvas.DrawEllipse( new Point { X = _frame.left + _frame.width / 2, Y = _frame.top + _frame.height / 2 }, _frame.width / 2, _frame.height / 2 );
            }
        }
    }
}
