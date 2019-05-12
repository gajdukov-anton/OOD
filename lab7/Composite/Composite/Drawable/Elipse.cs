using System.Collections.Generic;
using Composite.Canvas;

namespace Composite.Drawable
{
    public class Elipse : Shape
    {
        public Elipse( Rect frame, Style fillStyle = null, OutLineStyle outLineStyle = null )
            : base( frame, fillStyle, outLineStyle )
        { }

        public override void Draw( ICanvas canvas )
        {
            if (_fillStyle.IsEnable())
            {
                canvas.SetFillColor( _fillStyle.GetColor().ToArgb() );
                canvas.FillEllipse( new Point { X = _frame.left + _frame.width / 2, Y = _frame.top + _frame.height / 2}, _frame.width / 2, _frame.height / 2 );
            }
            if (_outLineStyle.IsEnable())
            {
                canvas.SetLineColor( _outLineStyle.GetColor().ToArgb() );
                canvas.SetLineWidth( _outLineStyle.GetLineWidth() ?? 0 );
                canvas.DrawEllipse( new Point { X = _frame.left + _frame.width / 2, Y = _frame.top + _frame.height / 2 }, _frame.width / 2, _frame.height / 2 );
            }
        }

        protected override List<Point> GetPoints()
        {
            throw new System.NotImplementedException();
        }
    }
}
