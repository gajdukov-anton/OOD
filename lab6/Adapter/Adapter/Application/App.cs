using Adapter.GraphicsLib;
using Adapter.ModernGraphicsLib;
using Adapter.ShapeDrawingLib;
using System;

namespace Adapter.Application
{
    public class App
    {
        public static void PaintPicture( CanvasPainter painter )
        {
            var triangle = new Triangle( new ShapeDrawingLib.Point( 10, 15 ), new ShapeDrawingLib.Point( 100, 200 ), new ShapeDrawingLib.Point( 15, 200 ), 0x98FB98 );
            var rectangle = new Rectangle( new ShapeDrawingLib.Point( 30, 40 ), 18, 24, 0xADFF2F );
            painter.Draw( triangle );
            painter.Draw( rectangle );
        }

        public static void PaintPictureOnCanvas()
        {
            ICanvas canvas = new Canvas();
            CanvasPainter painter = new CanvasPainter( canvas );
            PaintPicture( painter );
        }

        public static void PaintPictureOnModernGraphicsRenderer( bool useClassAdapter = false)
        {
            ModernGraphicsRenderer renderer = new ModernGraphicsRenderer( Console.Out );
            if ( useClassAdapter )
            {
                using ( var adapter =  new MGREndererClassAdapter( Console.Out ) )
                {
                    CanvasPainter painter = new CanvasPainter( adapter );
                    adapter.BeginDraw();
                    PaintPicture( painter );
                }
            }
            else
            {
                using ( var adapter =  new MGRendererAdapter( renderer ) )
                {
                    CanvasPainter painter = new CanvasPainter( adapter );
                    adapter.BeginDraw();
                    PaintPicture( painter );
                }
            }
        }
    }
}
