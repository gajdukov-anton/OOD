using Composite.Canvas;

namespace Composite.Drawable
{
    public class Triangle : Shape
    {
        public Triangle( Rect<double> frame, IStyle fillStyle, IStyle outLineStyle )
            : base( frame, fillStyle, outLineStyle )
        { }

        public override void Draw( ICanvas canvas )
        {
            BeginFill( canvas );
            SetLineColorToCanvas( canvas );
            canvas.MoveTo( _frame.Left / 2, _frame.Top );
            canvas.LineTo( _frame.Left, _frame.Top - _frame.Height );
            canvas.LineTo( _frame.Left + _frame.Width, _frame.Top - _frame.Height );
            canvas.LineTo( _frame.Left / 2, _frame.Top );
            EndFill( canvas );
        }
    }
}
