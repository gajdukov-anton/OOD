using Paint.UI;
using System;

namespace Paint.Shapes
{
    public class Ellipse : Shape
    {
        private Point _center;
        private double _horizontalRadius;
        private double _verticalRadius;

        public Ellipse(Point center, double horizontalRadius, double verticalRadius, Color color = Color.Black)
            :base(color)
        {
            _horizontalRadius = horizontalRadius;
            _verticalRadius = verticalRadius;
            _center = center;
        }

        public override void Draw( ICanvas canvas )
        {
            canvas.SetColor( GetColor() );
            canvas.DrawEllipse( _center.X, _center.Y, 2 * _horizontalRadius, 2 * _verticalRadius );
        }

        public Point GetCenter()
        {
            return _center;
        }

        public double GetHorizontalRadius()
        {
            return _horizontalRadius;
        }

        public double GetVerticalRadius()
        {
            return _verticalRadius;
        }
    }
}
