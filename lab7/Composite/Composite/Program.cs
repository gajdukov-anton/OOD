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
            var canvas = new Canvas.Canvas( Console.Out, 1000, 1000 );

            var slide = new Slide( 1000, 1000 );

            var sunFillStyle = new Style( Color.Yellow, true );
            var sunOutLineStyle = new OutLineStyle( Color.Orange, true, 5 );
            var firstFloorFillStyle = new Style( Color.Brown, true );
            var firstFloorOutLineStyle = new OutLineStyle( Color.Red, true, 5 );
            var secondFloorFillStyle = new Style( Color.Green, true );
            var secondFloorOutLineStyle = new OutLineStyle( Color.GreenYellow, true, 5 );

            var roofFrame = new Rect( 200, 200, 95, 100 );
            var roof = new Triangle( roofFrame, secondFloorFillStyle, secondFloorOutLineStyle );

            var porchFrame = new Rect( 100, 100, 250, 100 );
            var porch = new Rectangle( porchFrame, firstFloorFillStyle, firstFloorOutLineStyle );
            var rectangleFrameTwo = new Rect( 200, 200, 200, 150 );
            var rectangleTwo = new Rectangle( rectangleFrameTwo, firstFloorFillStyle, firstFloorOutLineStyle );

            var ellipseFrame = new Rect( 450, 100, 100, 100 );
            var ellipse = new Elipse( ellipseFrame, sunFillStyle, sunOutLineStyle );

            var home = new GroupShape();
            var sky = new GroupShape();
            var picture = new GroupShape();

            slide.SetBackgroundColor( Color.Black.ToArgb() );
            home.InsertShape( porch, 0 );
            home.InsertShape( rectangleTwo, 0 );
            home.InsertShape( roof, 0 );
            sky.InsertShape( ellipse, 0 );
            picture.InsertShape( home, 0 );
            picture.InsertShape( sky, 0 );
            slide.GetShapes().InsertShape( picture, 0 );
            slide.Draw( canvas );
            PrintFrame( picture.GetFrame().Value );
            canvas.Save( "E:\\учёба\\test1.png" );

            var newGroupFrame = new Rect( 0, 900, 0, 510 );
            picture.SetFrame( newGroupFrame );
            var pictureStyle = picture.GetFillStyle();
            pictureStyle.SetColor( Color.Azure );
            slide.Draw( canvas );
            PrintFrame( ellipse.GetFrame().Value );
            canvas.Save( "E:\\учёба\\test2.png" );

        }

        private static void PrintFrame( Rect frame )
        {
            Console.WriteLine( "----------------------" );
            Console.WriteLine( $"Left: {frame.left}" );
            Console.WriteLine( $"Top: {frame.top}" );
            Console.WriteLine( $"Width: {frame.width}" );
            Console.WriteLine( $"Height: {frame.height}" );
            Console.WriteLine( "----------------------" );
        }
    }
}
