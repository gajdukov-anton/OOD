using System.Collections.Generic;
using Composite.Canvas;

namespace Composite.Drawable
{
    public class Rectangle : Shape
    {
        public Rectangle(Rect<double> frame, Style fillStyle, OutLineStyle outLineStyle)
            :base(frame, fillStyle, outLineStyle)
        { }

        public override void Draw( ICanvas canvas )
        {
            if (_fillStyle.IsEnable())
            {
                canvas.SetFillColor( _fillStyle.GetColor().ToArgb() );
                canvas.DrawFillShapeByPoints( GetPoints() );
            }
            if (_outLineStyle.IsEnable())
            {
                canvas.SetLineColor( _outLineStyle.GetColor().ToArgb() );
                canvas.SetLineWidth( _outLineStyle.GetLineWidth() ?? 0 );
                canvas.DrawLine( new Point { X = _frame.Left, Y = _frame.Top }, new Point { X = _frame.Left, Y = _frame.Top + _frame.Height } );
                canvas.DrawLine( new Point { X = _frame.Left, Y = _frame.Top + _frame.Height }, new Point { X = _frame.Left + _frame.Width, Y = _frame.Top + _frame.Height } );
                canvas.DrawLine( new Point { X = _frame.Left + _frame.Width, Y = _frame.Top + _frame.Height }, new Point { X = _frame.Left + _frame.Width, Y = _frame.Top } );
                canvas.DrawLine( new Point { X = _frame.Left + _frame.Width, Y = _frame.Top }, new Point { X = _frame.Left, Y = _frame.Top } );
            }
        }

        protected override List<Point> GetPoints()
        {
            var result = new List<Point>
            {
                new Point { X = _frame.Left, Y = _frame.Top },
                new Point { X = _frame.Left, Y = _frame.Top + _frame.Height },
                new Point { X = _frame.Left + _frame.Width, Y = _frame.Top + _frame.Height },
                new Point { X = _frame.Left + _frame.Width, Y = _frame.Top }
            };
            return result;
        }
    }
}
