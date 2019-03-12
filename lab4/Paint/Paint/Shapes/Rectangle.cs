using Paint.UI;
using System;

namespace Paint.Shapes
{
    public class Rectangle : Shape
    {
        private Point _leftTopVertex;
        private Point _rightBottomVertex;

        public Rectangle(Point leftTop, Point rightBottom, Color color = Color.Black)
            :base(color)
        {
            _leftTopVertex = leftTop;
            _rightBottomVertex = rightBottom;
        }

        public override void Draw( ICanvas canvas )
        {
            canvas.SetColor( GetColor() );
            canvas.DrawLine( _leftTopVertex, new Point( _rightBottomVertex.X, _leftTopVertex.Y ) );
            canvas.DrawLine( new Point( _rightBottomVertex.X, _leftTopVertex.Y ), _rightBottomVertex );
            canvas.DrawLine( _rightBottomVertex, new Point( _leftTopVertex.X, _rightBottomVertex.Y ) );
            canvas.DrawLine( new Point( _leftTopVertex.X, _rightBottomVertex.Y ), _leftTopVertex );
        }

        public Point GetLeftTop()
        {
            return _leftTopVertex;
        }

        public Point GetRightBottom()
        {
            return _rightBottomVertex;
        }
    }
}
