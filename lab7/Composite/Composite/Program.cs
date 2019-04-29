
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
            /*   var canvas = new Canvas.Canvas( Console.Out );
               var fillStyle = new Style( Color.FromArgb( 0xff0000 ), true );
               var outLineStyle = new OutLineStyle( Color.FromArgb( 0xffff00 ), true, 2 );
               var unableFillStyle = new Style( Color.FromArgb( 0xff0000 ), false );

               var elipseFrame = new Rect<double>( 5, 7, 10, 8 );
               var elipse = new Elipse( elipseFrame, fillStyle, outLineStyle );
               var rectangleFrame = new Rect<double>( 10, 12, 12, 11 );
               var rectangle = new Rectangle( rectangleFrame, fillStyle, outLineStyle );
               var triangleFrame = new Rect<double>( 5, 17, 12, 16 );
               var triangle = new Triangle( triangleFrame, unableFillStyle, outLineStyle );

               var group = new GroupShape();
               var triangleGroup = new GroupShape();

               group.InsertShape( elipse, 0 );
               group.InsertShape( rectangle, 0 );
               triangleGroup.InsertShape( triangle, 0 );
               group.InsertShape( triangleGroup, 0 );

               var slide = new Slide( 1000, 1000 );
               slide.GetShapes().InsertShape( group, 0 );
               slide.Draw( canvas );*/
            var canvas = new Canvas.Canvas( Console.Out, 1000, 1000 );

            var fillStyle = new Style( Color.Red, false );
            var outLineStyle = new OutLineStyle( Color.Green, true, 5 );

            var triangleFrame = new Rect<double>( 80, 60, 50, 90 );
            var triangle = new Triangle( triangleFrame, fillStyle, outLineStyle );

            var rectangleFrame = new Rect<double>( 100, 50, 150, 50 );
            var rectangle = new Rectangle( rectangleFrame, fillStyle, outLineStyle );

            var ellipseFrame = new Rect<double>( 150, 50, 250, 50 );
            var ellipse = new Elipse( ellipseFrame, fillStyle, outLineStyle );

            rectangle.Draw( canvas );
            triangle.Draw( canvas );
            ellipse.Draw( canvas );

            canvas.Save( "E:\\учёба\\test.png" );
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
