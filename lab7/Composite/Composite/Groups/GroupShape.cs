using Composite.Canvas;
using Composite.Drawable;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Composite.Groups
{
    public class GroupShape : IGroupShape, INode
    {
        private List<IShape> _shapes;
        private IStyle _outLineStyle;
        private IStyle _fillStyle;
        private INode _parentNode;

        public GroupShape()
        {
            _shapes = new List<IShape>();
            _outLineStyle = new Style();
            _fillStyle = new Style();
        }

        public GroupShape( IStyle outlineStyle, IStyle fillStyle )
        {
            _outLineStyle = outlineStyle;
            _fillStyle = fillStyle;
            _shapes = new List<IShape>();
        }

        public void Draw( ICanvas canvas )
        {
            foreach ( var shape in _shapes )
            {
                shape.Draw( canvas );
            }
        }

        public void RegisterNode( INode node )
        {
            _parentNode = node;
            _parentNode.UpdateFillStyle( _fillStyle );
            _parentNode.UpdateOutLineStyle( _outLineStyle );
        }

        public void InsertShape( IShape shape, int index )
        {
            _shapes.Insert( index, shape );
            shape.RegisterNode( this );
            UpdateParentNodeFillStyle( shape.GetFillStyle() );
            UpdateParentNodeOutLineStyle( shape.GetOutlineStyle() );
        }

        public void RemoveShapeAtIndex( int index )
        {
            if ( index >= 0 && index < _shapes.Count )
            {
                _shapes.RemoveAt( index );
                UpdateParentNodeFillStyle( null );
                UpdateParentNodeOutLineStyle( null );
                return;
            }
            throw new IndexOutOfRangeException();
        }

        public void SetFrame( Rect<double> frame )
        {
            if ( ValidateFrame( frame ) )
            {
                SetNewFrameToShapes( frame );
            }
            else
            {
                throw new ArgumentException( "Frame must be over 0" );
            }
        }

        public Rect<double> GetFrame()
        {
            return GetShapesCount() > 0 ? CalculateShapesFrame() : null;
        }

        public void SetFillStyle( IStyle style )
        {
            if ( _shapes.Count > 0 )
            {
                foreach ( var shape in _shapes )
                {
                    shape.SetFillStyle( style );
                }
                FillStyle( _fillStyle, style.GetColor(), style.IsEnable() );
                UpdateParentNodeFillStyle( style );
            }
        }

        public IStyle GetFillStyle()
        {
            return _fillStyle;
        }

        public void SetOutlineStyle( IStyle style )
        {
            if ( _shapes.Count > 0 )
            {
                foreach ( var shape in _shapes )
                {
                    shape.SetOutlineStyle( style );
                }
                FillStyle( _outLineStyle, style.GetColor(), style.IsEnable() );
                UpdateParentNodeOutLineStyle( style );
            }
        }

        public IStyle GetOutlineStyle()
        {
            return _outLineStyle;
        }

        public IShape GetShapeAtIndex( int index )
        {
            if ( index >= 0 && index < _shapes.Count )
            {
                return _shapes [ index ];
            }
            throw new IndexOutOfRangeException();
        }

        public int GetShapesCount()
        {
            return _shapes.Count;
        }

        public void UpdateOutLineStyle( IStyle style )
        {
            if ( _shapes.Count > 0 )
            {
                FillStyle( _outLineStyle, _shapes [ 0 ].GetOutlineStyle().GetColor(), _shapes [ 0 ].GetOutlineStyle().IsEnable() );
                foreach ( var shape in _shapes )
                {
                    if ( !shape.GetOutlineStyle().Equals( _shapes[0].GetOutlineStyle() ) )
                    {
                        FillStyle( _outLineStyle, Color.Empty, false );
                        break;
                    }
                }
            }
            UpdateParentNodeOutLineStyle( style );
        }

        public void UpdateFillStyle( IStyle style )
        {
            if ( _shapes.Count > 0 )
            {
                FillStyle( _fillStyle, _shapes [ 0 ].GetFillStyle().GetColor(), _shapes [ 0 ].GetFillStyle().IsEnable() );
                foreach ( var shape in _shapes )
                {
                    if ( !shape.GetFillStyle().Equals( _shapes[0].GetFillStyle() ) )
                    {
                        FillStyle( _fillStyle, Color.Empty, false );
                        break;
                    }
                }
            }
            UpdateParentNodeFillStyle( style );
        }

        private Rect<double> CalculateShapesFrame()
        {
            double left = double.MaxValue;
            double top = double.MinValue;
            double maxXCor = double.MinValue;
            double minYCor = double.MaxValue;
            foreach ( var shape in _shapes )
            {
                left = shape.GetFrame().Left.CompareTo( left ) > 0 ? left : shape.GetFrame().Left;
                top = shape.GetFrame().Top.CompareTo( top ) < 0 ? top : shape.GetFrame().Top;

                var xCor = shape.GetFrame().Left + shape.GetFrame().Width;
                var yCor = shape.GetFrame().Top - shape.GetFrame().Height;

                maxXCor = maxXCor.CompareTo( xCor ) > 0 ? maxXCor : xCor;
                minYCor = minYCor.CompareTo( yCor ) < 0 ? minYCor : yCor;
            }

            return new Rect<double>( left, maxXCor - left, top, top - minYCor );
        }

        private void SetNewFrameToShapes( Rect<double> frame )
        {
            if ( GetShapesCount() > 0 )
            {
                var prevFrame = GetFrame();
                double varianceLeft = frame.Left / prevFrame.Left;
                double varianceTop = frame.Top / prevFrame.Top;
                double varianceWidth = frame.Width / prevFrame.Width;
                double varianceHeight = frame.Height / prevFrame.Height;

                foreach ( var shape in _shapes )
                {
                    var newFrame = new Rect<double>(
                        shape.GetFrame().Left * varianceLeft,
                        shape.GetFrame().Width * varianceWidth,
                        shape.GetFrame().Top * varianceTop,
                        shape.GetFrame().Height * varianceHeight );
                    shape.SetFrame( newFrame );
                }
            }
        }

        private bool ValidateFrame( Rect<double> frame )
        {
            return frame.Height > 0 && frame.Left > 0 && frame.Top > 0 && frame.Width > 0;
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
