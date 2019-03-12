using Paint.UI;
using System;

namespace Paint.Shapes
{
    public class RegularPolygon : Shape
    {
        private int _vertexCount;
        private Point _center;
        private double _radius;

        public RegularPolygon( Point center, int vertexCount, double radius, Color color = Color.Black)
            :base(color)
        {
            _vertexCount = vertexCount;
            _center = center;
            _radius = radius;
        }

        public override void Draw( ICanvas canvas )
        {
            canvas.SetColor( GetColor() );
            double step = 2 * Math.PI / GetVertexCount();
            Point startPoint = new Point( _center.X + _radius * Math.Cos( 0 ), _center.Y );        
            for ( int i = 1; i <= GetVertexCount(); ++i )
            {
                Point point = new Point( _radius * Math.Cos( step * i ), _radius * Math.Sin( step * i ) );
                Point finishPoint = new Point( _center.X + point.X, _center.Y + point.Y );
                canvas.DrawLine( startPoint, finishPoint );
                startPoint = finishPoint;
            }
        }

        public int GetVertexCount()
        {
            return _vertexCount;
        }

        public Point GetCenter()
        {
            return _center;
        }

        public double GetRadius()
        {
            return _radius;
        }
    }
}
