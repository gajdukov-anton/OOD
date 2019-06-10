using System.Collections.Generic;
using Composite.Canvas;
using Composite.Style;

namespace Composite.Shape
{
    public class Rectangle : Shape
    {
        public Rectangle(Rect frame, IStyle fillStyle = null, IOutLineStyle outLineStyle = null)
            :base(frame, fillStyle, outLineStyle)
        { }

        public override void Draw( ICanvas canvas )
        {
            if (_fillStyle.IsEnabled())
            {
                canvas.SetFillColor( _fillStyle.GetColor().ToArgb() );
                canvas.FillPolygon( GetPoints() );
            }
            if (_outLineStyle.IsEnabled())
            {
                canvas.SetLineColor( _outLineStyle.GetColor().ToArgb() );
                canvas.SetLineWidth( _outLineStyle.GetLineWidth() ?? 0 );
                canvas.DrawLine( new Point { X = _frame.left, Y = _frame.top }, new Point { X = _frame.left, Y = _frame.top + _frame.height } );
                canvas.DrawLine( new Point { X = _frame.left, Y = _frame.top + _frame.height }, new Point { X = _frame.left + _frame.width, Y = _frame.top + _frame.height } );
                canvas.DrawLine( new Point { X = _frame.left + _frame.width, Y = _frame.top + _frame.height }, new Point { X = _frame.left + _frame.width, Y = _frame.top } );
                canvas.DrawLine( new Point { X = _frame.left + _frame.width, Y = _frame.top }, new Point { X = _frame.left, Y = _frame.top } );
            }
        }

        private List<Point> GetPoints()
        {
            var result = new List<Point>
            {
                new Point { X = _frame.left, Y = _frame.top },
                new Point { X = _frame.left, Y = _frame.top + _frame.height },
                new Point { X = _frame.left + _frame.width, Y = _frame.top + _frame.height },
                new Point { X = _frame.left + _frame.width, Y = _frame.top }
            };
            return result;
        }
    }
}
