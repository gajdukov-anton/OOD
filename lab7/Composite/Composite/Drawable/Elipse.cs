using System.Collections.Generic;
using Composite.Canvas;

namespace Composite.Drawable
{
    public class Elipse : Shape
    {
        public Elipse( Rect<double> frame, Style fillStyle, OutLineStyle outLineStyle )
            : base( frame, fillStyle, outLineStyle )
        { }

        public override void Draw( ICanvas canvas )
        {
            if (_fillStyle.IsEnable())
            {
                canvas.FillEllipse( new Point { X = _frame.Left, Y = _frame.Top }, _frame.Width, _frame.Height );
            }
            if (_outLineStyle.IsEnable())
            {
                canvas.DrawEllipse( new Point { X = _frame.Left, Y = _frame.Top }, _frame.Width, _frame.Height );
            }
        }

        protected override List<Point> GetPoints()
        {
            throw new System.NotImplementedException();
        }
    }
}
