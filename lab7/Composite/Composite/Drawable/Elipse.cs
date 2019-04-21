using Composite.Canvas;

namespace Composite.Drawable
{
    public class Elipse : Shape
    {
        public Elipse( Rect<double> frame, IStyle fillStyle, IStyle outLineStyle )
            : base( frame, fillStyle, outLineStyle )
        { }

        public override void Draw( ICanvas canvas )
        {
            BeginFill( canvas );
            SetLineColorToCanvas( canvas );
            canvas.DrawEllipse( _frame.Left, _frame.Top, _frame.Width, _frame.Height );
            EndFill( canvas );
        }
    }
}
