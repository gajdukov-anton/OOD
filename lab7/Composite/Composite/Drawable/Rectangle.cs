using Composite.Canvas;

namespace Composite.Drawable
{
    public class Rectangle : Shape
    {
        public Rectangle(Rect<double> frame, IStyle fillStyle, IStyle outLineStyle)
            :base(frame, fillStyle, outLineStyle)
        { }

        public override void Draw( ICanvas canvas )
        {
            BeginFill( canvas );
            SetLineColorToCanvas( canvas );
            canvas.MoveTo( _frame.Left, _frame.Top );
            canvas.LineTo( _frame.Left, _frame.Top - _frame.Height );
            canvas.LineTo( _frame.Left + _frame.Width, _frame.Top - _frame.Height );
            canvas.LineTo( _frame.Left + _frame.Width, _frame.Top );
            canvas.LineTo( _frame.Left, _frame.Top );
            canvas.EndFill();
        }
    }
}
