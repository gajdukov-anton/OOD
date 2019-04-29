using Composite.Canvas;
using Composite.Drawable;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Composite.Groups
{
    public class GroupShape : IGroupShape
    {
        private List<IShape> _shapes;
        private OutLineGroupStyle _outLineStyle;
        private GroupStyle _fillStyle;

        public GroupShape()
        {
            _shapes = new List<IShape>();
            _outLineStyle = new OutLineGroupStyle( CreateOutLineStyle() );
            _fillStyle = new GroupStyle( CreateBaseStyle() );
        }

        public void Draw( ICanvas canvas )
        {
            foreach ( var shape in _shapes )
            {
                shape.Draw( canvas );
            }
        }

        public void InsertShape( IShape shape, int index )
        {
            _shapes.Insert( index, shape );
        }

        public void RemoveShapeAtIndex( int index )
        {
            if ( index >= 0 && index < _shapes.Count )
            {
                _shapes.RemoveAt( index );
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

        public IStyle GetFillStyle()
        {
            return _fillStyle;
        }

        public IOutLineStyle GetOutlineStyle()
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
                double varianceX = frame.Width / prevFrame.Width;
                double varianceY = frame.Height / prevFrame.Height;

                foreach ( var shape in _shapes )
                {
                    var incrementX = shape.GetFrame().Left - prevFrame.Left;
                    var incrementY = prevFrame.Top - shape.GetFrame().Top;
                    var newFrame = new Rect<double>(
                        frame.Left + ( incrementX * varianceX ),
                        shape.GetFrame().Width * varianceX,
                        frame.Top - ( incrementY * varianceY ),
                        shape.GetFrame().Height * varianceY );
                    shape.SetFrame( newFrame );
                }
            }
        }

        private bool ValidateFrame( Rect<double> frame )
        {
            return frame.Height > 0 && frame.Width > 0;
        }

        private IEnumerable<IOutLineStyle> CreateOutLineStyle()
        {
            foreach ( var shape in _shapes )
            {
                yield return shape.GetOutlineStyle();
            }
        }

        private IEnumerable<IStyle> CreateBaseStyle()
        {
            foreach ( var shape in _shapes )
            {
                yield return shape.GetFillStyle();
            }
        }
    }
}
