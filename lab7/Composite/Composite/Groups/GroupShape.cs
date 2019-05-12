﻿using Composite.Canvas;
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
            if ( index >= 0 && index <= _shapes.Count )
            {
                _shapes.Insert( index, shape );
                return;
            }
            throw new IndexOutOfRangeException();
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

        public void SetFrame( Rect frame )
        {
            if ( ValidateFrame( frame ) )
            {
                SetNewFrameToShapes( frame );
            }
            else
            {
                throw new ArgumentException( "Frame height and weight must be over 0" );
            }
        }

        public Rect? GetFrame()
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

        private Rect? CalculateShapesFrame()
        {
            double left = double.MaxValue;
            double top = double.MaxValue;
            double maxXCor = double.MinValue;
            double maxYCor = double.MinValue;

            foreach ( var shape in _shapes )
            {
                left = shape.GetFrame().Value.left.CompareTo( left ) > 0 ? left : shape.GetFrame().Value.left;
                top = shape.GetFrame().Value.top.CompareTo( top ) > 0 ? top : shape.GetFrame().Value.top;

                var xCor = shape.GetFrame().Value.left + shape.GetFrame().Value.width;
                var yCor = shape.GetFrame().Value.top + shape.GetFrame().Value.height;

                maxXCor = maxXCor.CompareTo( xCor ) > 0 ? maxXCor : xCor;
                maxYCor = maxYCor.CompareTo( yCor ) > 0 ? maxYCor : yCor;
            }

            return new Rect( left, maxXCor - left, top, maxYCor - top );
        }

        private void SetNewFrameToShapes( Rect frame )
        {
            if ( GetShapesCount() > 0 )
            {
                var prevFrame = GetFrame();
                double varianceX = frame.width / prevFrame.Value.width;
                double varianceY = frame.height / prevFrame.Value.height;

                foreach ( var shape in _shapes )
                {
                    var incrementX = shape.GetFrame().Value.left - prevFrame.Value.left;
                    var incrementY = shape.GetFrame().Value.top - prevFrame.Value.top;
                    var newFrame = new Rect(
                        frame.left + ( incrementX * varianceX ),
                        shape.GetFrame().Value.width * varianceX,
                        frame.top + ( incrementY * varianceY ),
                        shape.GetFrame().Value.height * varianceY );
                    shape.SetFrame( newFrame );
                }
            }
        }

        private bool ValidateFrame( Rect frame )
        {
            return frame.height > 0 && frame.width > 0;
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
