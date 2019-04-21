
using Composite.Canvas;
using Composite.Drawable;
using Composite.Groups;
using System;
using System.Drawing;
using Rectangle = Composite.Drawable.Rectangle;

namespace Composite
{
    class Program
    {
        static void Main( string [] args )
        {
            ICanvas canvas = new Canvas.Canvas( Console.Out );
            canvas.MoveTo( 10, 10 );
            canvas.LineTo( 250, 250 );
            
           /* Rect<double> elipseFrame = new Rect<double>( 1, 10, 10, 10 );
            Elipse elipse = new Elipse( elipseFrame, new Style( Color.FromArgb( 0xff0000 ), true ), new Style( Color.FromArgb( 0xffff00 ), true ) );
            Rect<double> rectangleFrame = new Rect<double>( 1, 100, 100, 100 );
            Rectangle rectangle = new Rectangle( rectangleFrame, new Style( Color.FromArgb( 0xff0000 ), true ), new Style( Color.FromArgb( 0xffff00 ), true ) );
            GroupShape group = new GroupShape( new Style( Color.FromArgb( 0xffffff ), true ), new Style( Color.FromArgb( 0xffffff ), true ) );
            group.InsertShape( elipse, 0 );
            group.InsertShape( rectangle, 0 );*/

          /*  var fillStyleOne = new Style( Color.FromArgb( 0xff0000 ), true );
            var fillStyleTwo = new Style( Color.FromArgb( 0xffff00 ), true );
            var outLineStyleOne = new Style( Color.FromArgb( 0xffff00 ), true );
            var outLineStyleTwo = new Style( Color.FromArgb( 0x00ff00 ), true );
            var emptyStyle = new Style();

            var elipseFrame = new Rect<double>( 1, 1000, 10, 500 );
            var elipse = new Elipse( elipseFrame, fillStyleOne, outLineStyleOne );
            var rectangleFrame = new Rect<double>( 1, 100, 100, 100 );
            var rectangle = new Composite.Drawable.Rectangle( rectangleFrame, fillStyleOne, outLineStyleOne );
            var triangleFrame = new Rect<double>( 10, 10, 10, 10 );
            var triangle = new Triangle( triangleFrame, fillStyleTwo, outLineStyleTwo );

            var group = new GroupShape();
            var triangleGroup = new GroupShape();
            var currentFillStyle = group.GetFillStyle();
            var currentOutLineStyle = group.GetOutlineStyle();

            triangleGroup.InsertShape( triangle, 0 );
            group.InsertShape( triangleGroup, 0 );
            group.InsertShape( elipse, 0 );

            Slide slide = new Slide( 1000, 1000 );
            slide.GetShapes().InsertShape( group, 0 );*/
        }

        private static void PrintFrame( Rect<double> frame )
        {
            Console.WriteLine( "----------------------" );
            Console.WriteLine( $"Left: {frame.Left}" );
            Console.WriteLine( $"Top: {frame.Top}" );
            Console.WriteLine( $"Width: {frame.Width}" );
            Console.WriteLine( $"Height: {frame.Height}" );
            Console.WriteLine( "----------------------" );
        }
    }
}
