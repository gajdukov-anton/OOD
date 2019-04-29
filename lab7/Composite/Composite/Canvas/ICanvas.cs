
using System.Collections.Generic;

namespace Composite.Canvas
{
    public interface ICanvas
    {
        void SetLineColor( int colorRGBA );
        void SetFillColor( int colorRGBA );
        void SetLineWidth( int width );

        void DrawLine( Point from, Point to );
        void DrawEllipse( Point center, double width, double height );

        void FillEllipse( Point center, double width, double height );
        void DrawFillShapeByPoints(List<Point> lines);
    }
}
