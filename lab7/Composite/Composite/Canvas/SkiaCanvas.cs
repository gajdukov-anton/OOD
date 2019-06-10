using SkiaSharp;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace Composite.Canvas
{
    public class SkiaCanvas : ICanvas
    {
        private SKBitmap _skBitmap;
        private SKCanvas _skCanvas;
        private SKPaint _linePaint;
        private SKPaint _fillPaint;

        public SkiaCanvas( int width, int height )
        {
            _skBitmap = new SKBitmap( width, height );
            _skCanvas = new SKCanvas( _skBitmap );
            _linePaint = new SKPaint
            {
                IsAntialias = true,
                Style = SKPaintStyle.Stroke
            };
            _fillPaint = new SKPaint
            {
                IsAntialias = true,
                Style = SKPaintStyle.Fill
            };
        }

        public void SetLineColor( int colorRGBA )
        {
            var lineColor = Color.FromArgb( colorRGBA );
            _linePaint.Color = new SKColor( lineColor.R, lineColor.G, lineColor.B, lineColor.A );
        }

        public void SetLineWidth( int width )
        {
            _linePaint.StrokeWidth = width;
        }

        public void SetFillColor( int colorRGBA )
        {
            var fillColor = Color.FromArgb( colorRGBA );
            _fillPaint.Color = new SKColor( fillColor.R, fillColor.G, fillColor.B, fillColor.A );
        }

        public void FillPolygon( List<Point> vertices )
        {
            if (vertices == null || vertices.Count == 0)
            {
                return;
            }
            using ( var path = new SKPath() )
            {
                path.AddPoly( GetSKPoints( vertices ) );
                _skCanvas.DrawPath( path, _fillPaint );
            }
        }

        public void DrawLine( Point from, Point to )
        {
            using ( var path = new SKPath() )
            {
                path.MoveTo( ( float ) from.X, ( float ) from.Y );
                path.LineTo( ( float ) to.X, ( float ) to.Y );
                _skCanvas.DrawPath( path, _linePaint );
            }
        }

        public void FillEllipse( Point center, double width, double height )
        {
            _skCanvas.DrawOval( ( float ) center.X, ( float ) center.Y, ( float ) width, ( float ) height, _fillPaint );
        }

        public void DrawEllipse( Point center, double width, double height )
        {
            _skCanvas.DrawOval( ( float ) center.X, ( float ) center.Y, ( float ) width, (float) height, _linePaint );
        }

        public void Save( string path )
        {
            using ( var stream = File.Create( path ) )
            using ( var skiaStream = new SKManagedWStream( stream ) )
            {
                SKPixmap.Encode( skiaStream, _skBitmap, SKEncodedImageFormat.Png, 100 );
            }
        }

        private SKPoint[] GetSKPoints(List<Point> points)
        {
            var result = new SKPoint[ points.Count ];
            for ( int i = 0; i < points.Count; i++ )
            {
                result[i] = new SKPoint((float)points[i].X, (float)points[i].Y );
            }
            return result;
        }
    }
}
