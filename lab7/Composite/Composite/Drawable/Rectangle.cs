using System.Collections.Generic;
using Composite.Canvas;

namespace Composite.Drawable
{
    public class Rectangle : Shape
    {
        public Rectangle(Rect frame, Style fillStyle = null, OutLineStyle outLineStyle = null)
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
                canvas.DrawLine( new Point { X = _frame.left, Y = _frame.top }, new Point { X = _frame.left, Y = _frame.top + _frame.height } );
                canvas.DrawLine( new Point { X = _frame.left, Y = _frame.top + _frame.height }, new Point { X = _frame.left + _frame.width, Y = _frame.top + _frame.height } );
                canvas.DrawLine( new Point { X = _frame.left + _frame.width, Y = _frame.top + _frame.height }, new Point { X = _frame.left + _frame.width, Y = _frame.top } );
                canvas.DrawLine( new Point { X = _frame.left + _frame.width, Y = _frame.top }, new Point { X = _frame.left, Y = _frame.top } );
            }
        }

        protected override List<Point> GetPoints()
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
