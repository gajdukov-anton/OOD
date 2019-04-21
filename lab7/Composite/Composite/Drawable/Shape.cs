using Composite.Canvas;
using Composite.Groups;
using System.Drawing;

namespace Composite.Drawable
{
    public abstract class Shape : IShape
    {
        protected IStyle _outLineStyle = new Style();
        protected IStyle _fillStyle = new Style();
        protected Rect<double> _frame;
        private INode _parentNode;

        public Shape( Rect<double> frame, IStyle fillStyle, IStyle outLineStyle )
        {
            _frame = frame;
            FillStyle( _fillStyle, fillStyle.GetColor(), fillStyle.IsEnable() );
            FillStyle( _outLineStyle, outLineStyle.GetColor(), outLineStyle.IsEnable() );
        }

        public abstract void Draw( ICanvas canvas );

        public IStyle GetFillStyle()
        {
            return _fillStyle;
        }

        public Rect<double> GetFrame()
        {
            return _frame;
        }

        public IStyle GetOutlineStyle()
        {
            return _outLineStyle;
        }

        public void SetFillStyle( IStyle style )
        {
            FillStyle( _fillStyle, style.GetColor(), style.IsEnable() );
            UpdateParentNodeFillStyle( style );
        }

        public void SetFrame( Rect<double> rect )
        {
            _frame = rect;
        }

        public void SetOutlineStyle( IStyle style )
        {
            FillStyle( _outLineStyle, style.GetColor(), style.IsEnable() );
            UpdateParentNodeOutLineStyle( style );
        }

        public void RegisterNode( INode node )
        {
            _parentNode = node;
            UpdateParentNodeFillStyle( _fillStyle );
            UpdateParentNodeOutLineStyle( _outLineStyle );
        }

        protected void BeginFill( ICanvas canvas )
        {
            if ( _fillStyle.IsEnable() )
            {
                canvas.BeginFill( _fillStyle.GetColor().ToArgb() );
            }
        }

        protected void SetLineColorToCanvas( ICanvas canvas)
        {
            if (_fillStyle.IsEnable())
            {
                canvas.SetLineColor( _fillStyle.GetColor().ToArgb() );
            }
        }

        protected void EndFill(ICanvas canvas)
        {
            if ( _fillStyle.IsEnable() )
            {
                canvas.EndFill();
            }
        }

        private void UpdateParentNodeFillStyle( IStyle style )
        {
            if ( _parentNode != null )
            {
                _parentNode.UpdateFillStyle( style );
            }
        }

        private void UpdateParentNodeOutLineStyle( IStyle style )
        {
            if ( _parentNode != null )
            {
                _parentNode.UpdateOutLineStyle( style );
            }
        }

        private void FillStyle( IStyle style, Color color, bool enable )
        {
            style.SetColor( color );
            style.Enable( enable );
        }
    }
}
