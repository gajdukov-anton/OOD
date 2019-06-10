using Composite.Canvas;
using Composite.Style;
using System;

namespace Composite.Shape
{
    public abstract class Shape : IShape
    {
        protected IOutLineStyle _outLineStyle = new OutLineStyle();
        protected IStyle _fillStyle = new Style.Style();
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
            if ( ValidateFrame( rect ) )
            {
                _frame = rect;
            }
            else
            {
                throw new ArgumentException( "Frame height and weight must be over 0" );
            }
        }

        private bool ValidateFrame( Rect frame )
        {
            return frame.height >= 0 && frame.width >= 0;
        }
    }
}
