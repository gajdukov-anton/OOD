using System;
using System.Drawing;
using System.IO;
using Composite.Canvas;
using Composite.Drawable;
using Composite.Groups;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CompositeTest
{
    [TestClass]
    public class GroupShapeTest
    {
        [TestMethod]
        public void GetFrameTest()
        {
            var fillStyle = new Style( Color.FromArgb( 0xff0000 ), true );
            var outLineStyle = new Style( Color.FromArgb( 0xffff00 ), true );

            var elipseFrame = new Rect<double>( 5, 7, 10, 7 );
            var elipse = new Elipse( elipseFrame, fillStyle, outLineStyle );
            var rectangleFrame = new Rect<double>( 10, 12, 12, 10 );
            var rectangle = new Composite.Drawable.Rectangle( rectangleFrame, fillStyle, outLineStyle );
            var triangleFrame = new Rect<double>( 8, 6, 5, 9 );
            var triangle = new Triangle( triangleFrame, fillStyle, outLineStyle );

            var triangleGroup = new GroupShape();
            var group = new GroupShape( new Style( Color.FromArgb( 0xffffff ), true ), new Style( Color.FromArgb( 0xffffff ), true ) );

            group.InsertShape( elipse, 0 );
            group.InsertShape( rectangle, 0 );
            triangleGroup.InsertShape( triangle, 0 );

            Assert.AreEqual( 5, group.GetFrame().Left );
            Assert.AreEqual( 12, group.GetFrame().Top );
            Assert.AreEqual( 17, group.GetFrame().Width );
            Assert.AreEqual( 10, group.GetFrame().Height );

            group.InsertShape( triangleGroup, 0 );

            Assert.AreEqual( 5, group.GetFrame().Left );
            Assert.AreEqual( 12, group.GetFrame().Top );
            Assert.AreEqual( 17, group.GetFrame().Width );
            Assert.AreEqual( 16, group.GetFrame().Height );

            group.RemoveShapeAtIndex( 2 );

            Assert.AreEqual( 8, group.GetFrame().Left );
            Assert.AreEqual( 12, group.GetFrame().Top );
            Assert.AreEqual( 14, group.GetFrame().Width );
            Assert.AreEqual( 16, group.GetFrame().Height );

            group.RemoveShapeAtIndex( 0 );

            Assert.AreEqual( 10, group.GetFrame().Left );
            Assert.AreEqual( 12, group.GetFrame().Top );
            Assert.AreEqual( 12, group.GetFrame().Width );
            Assert.AreEqual( 10, group.GetFrame().Height );
        }

        [TestMethod]
        public void GetFrameWithNoShapesTest()
        {
            var group = new GroupShape( new Style( Color.FromArgb( 0xffffff ), true ), new Style( Color.FromArgb( 0xffffff ), true ) );
            Assert.IsNull( group.GetFrame() );
        }

        [TestMethod]
        public void SetFrameWithNoShapesTest()
        {
            var group = new GroupShape( new Style( Color.FromArgb( 0xffffff ), true ), new Style( Color.FromArgb( 0xffffff ), true ) );
            group.SetFrame( new Rect<double>( 1, 1, 1, 1 ) );
        }

        [TestMethod]
        public void SetFrameTest()
        {
            var fillStyle = new Style( Color.FromArgb( 0xff0000 ), true );
            var outLineStyle = new Style( Color.FromArgb( 0xffff00 ), true );

            var elipseFrame = new Rect<double>( 5, 7, 10, 7 );
            var elipse = new Elipse( elipseFrame, fillStyle, outLineStyle );
            var rectangleFrame = new Rect<double>( 10, 12, 12, 10 );
            var rectangle = new Composite.Drawable.Rectangle( rectangleFrame, fillStyle, outLineStyle );
            var triangleFrame = new Rect<double>( 8, 6, 5, 9 );
            var triangle = new Triangle( triangleFrame, fillStyle, outLineStyle );

            var group = new GroupShape( fillStyle, outLineStyle );
            var triangleGroup = new GroupShape();

            group.InsertShape( elipse, 0 );
            group.InsertShape( rectangle, 0 );
            triangleGroup.InsertShape( triangle, 0 );
            group.InsertShape( triangleGroup, 0 );

            var newGroupFrame = new Rect<double>( 10, 34, 24, 32 );
            group.SetFrame( newGroupFrame );

            Assert.IsTrue( CompareFrame( newGroupFrame, group.GetFrame() ) );
            Assert.AreEqual( 16, group.GetShapeAtIndex( 0 ).GetFrame().Left );
            Assert.AreEqual( 12, group.GetShapeAtIndex( 0 ).GetFrame().Width );
            Assert.AreEqual( 10, group.GetShapeAtIndex( 0 ).GetFrame().Top );
            Assert.AreEqual( 18, group.GetShapeAtIndex( 0 ).GetFrame().Height );
            Assert.AreEqual( 20, group.GetShapeAtIndex( 1 ).GetFrame().Left );
            Assert.AreEqual( 24, group.GetShapeAtIndex( 1 ).GetFrame().Width );
            Assert.AreEqual( 24, group.GetShapeAtIndex( 1 ).GetFrame().Top );
            Assert.AreEqual( 20, group.GetShapeAtIndex( 1 ).GetFrame().Height );
        }

        [TestMethod]
        public void SetIncorrectFrameTest()
        {
            var elipseFrame = new Rect<double>( 1, 1000, 10, 500 );
            var elipse = new Elipse( elipseFrame, new Style( Color.FromArgb( 0xff0000 ), true ), new Style( Color.FromArgb( 0xffff00 ), true ) );
            var group = new GroupShape( new Style( Color.FromArgb( 0xffffff ), true ), new Style( Color.FromArgb( 0xffffff ), true ) );

            Assert.ThrowsException<ArgumentException>( () => group.SetFrame( new Rect<double>( -1, 1000, 10, 500 ) ) );
            Assert.ThrowsException<ArgumentException>( () => group.SetFrame( new Rect<double>( 1, -1000, 10, 500 ) ) );
            Assert.ThrowsException<ArgumentException>( () => group.SetFrame( new Rect<double>( 1, 1000, -10, 500 ) ) );
            Assert.ThrowsException<ArgumentException>( () => group.SetFrame( new Rect<double>( 1, 1000, 10, -500 ) ) );
        }

        [TestMethod]
        public void DrawTest()
        {
            StringWriter stringWriter = new StringWriter();
            ICanvas canvas = new Canvas( stringWriter );
            Rect<double> elipseFrame = new Rect<double>( 1, 1000, 10, 500 );
            Elipse elipse = new Elipse( elipseFrame, new Style( Color.FromArgb( 0xff0000 ), true ), new Style( Color.FromArgb( 0xffff00 ), true ) );
            Rect<double> rectangleFrame = new Rect<double>( 1, 100, 100, 100 );
            Composite.Drawable.Rectangle rectangle = new Composite.Drawable.Rectangle( rectangleFrame, new Style( Color.FromArgb( 0xff0000 ), true ), new Style( Color.FromArgb( 0xffff00 ), true ) );
            GroupShape group = new GroupShape( new Style( Color.FromArgb( 0xffffff ), true ), new Style( Color.FromArgb( 0xffffff ), true ) );
            group.InsertShape( elipse, 0 );
            group.InsertShape( rectangle, 0 );
            group.Draw( canvas );
            StringWriter result = new StringWriter();
            result.WriteLine( "Begin fill" );
            result.WriteLine( "Move to x: 1 y: 100" );
            result.WriteLine( "Line to x: 1 y: 0 line color: ff0000" );
            result.WriteLine( "Line to x: 101 y: 0 line color: ff0000" );
            result.WriteLine( "Line to x: 101 y: 100 line color: ff0000" );
            result.WriteLine( "Line to x: 1 y: 100 line color: ff0000" );
            result.WriteLine( "End fill" );
            result.WriteLine( "Begin fill" );
            result.WriteLine( "Draw ellipse left: 1 top: 10 width: 1000 height: 500 line color: ff0000" );
            result.WriteLine( "End fill" );
            Assert.AreEqual( result.ToString(), stringWriter.ToString() );
        }

        [TestMethod]
        public void SetStyleOnOneLvlGroupTest()
        {
            var fillStyle = new Style( Color.FromArgb( 0xff0000 ), true );
            var outLineStyle = new Style( Color.FromArgb( 0xffff00 ), true );
            var newFillStyle = new Style( Color.FromArgb( 0xffffff ), true );
            var newOutLineStyle = new Style( Color.FromArgb( 0xffffff ), true );

            var elipseFrame = new Rect<double>( 1, 1000, 10, 500 );
            var elipse = new Elipse( elipseFrame, fillStyle, outLineStyle );
            var rectangleFrame = new Rect<double>( 1, 100, 100, 100 );
            var rectangle = new Composite.Drawable.Rectangle( rectangleFrame, fillStyle, outLineStyle );
            var group = new GroupShape();

            group.InsertShape( elipse, 0 );
            group.InsertShape( rectangle, 0 );

            var currentFillStyle = group.GetFillStyle();
            var currentOutLineStyle = group.GetOutlineStyle();

            Assert.IsTrue( CompareStyle( fillStyle, group.GetFillStyle() ) );
            Assert.IsTrue( CompareStyle( outLineStyle, group.GetOutlineStyle() ) );
            Assert.IsTrue( CompareStyle( currentFillStyle, group.GetFillStyle() ) );
            Assert.IsTrue( CompareStyle( currentOutLineStyle, group.GetOutlineStyle() ) );
            Assert.IsTrue( CompareStyle( fillStyle, group.GetShapeAtIndex( 0 ).GetFillStyle() ) );
            Assert.IsTrue( CompareStyle( outLineStyle, group.GetShapeAtIndex( 0 ).GetOutlineStyle() ) );
            Assert.IsTrue( CompareStyle( fillStyle, group.GetShapeAtIndex( 1 ).GetFillStyle() ) );
            Assert.IsTrue( CompareStyle( outLineStyle, group.GetShapeAtIndex( 1 ).GetOutlineStyle() ) );

            group.SetFillStyle( newFillStyle );
            group.SetOutlineStyle( newOutLineStyle );

            Assert.IsTrue( CompareStyle( newFillStyle, group.GetFillStyle() ) );
            Assert.IsTrue( CompareStyle( newOutLineStyle, group.GetOutlineStyle() ) );
            Assert.IsTrue( CompareStyle( currentFillStyle, group.GetFillStyle() ) );
            Assert.IsTrue( CompareStyle( currentOutLineStyle, group.GetOutlineStyle() ) );
            Assert.IsTrue( CompareStyle( newFillStyle, group.GetShapeAtIndex( 0 ).GetFillStyle() ) );
            Assert.IsTrue( CompareStyle( newOutLineStyle, group.GetShapeAtIndex( 0 ).GetOutlineStyle() ) );
            Assert.IsTrue( CompareStyle( newFillStyle, group.GetShapeAtIndex( 1 ).GetFillStyle() ) );
            Assert.IsTrue( CompareStyle( newOutLineStyle, group.GetShapeAtIndex( 1 ).GetOutlineStyle() ) );
        }

        [TestMethod]
        public void SetStyleOnSomeLvlGroupTest()
        {
            var fillStyle = new Style( Color.FromArgb( 0xff0000 ), true );
            var outLineStyle = new Style( Color.FromArgb( 0xffff00 ), true );
            var newFillStyle = new Style( Color.FromArgb( 0xffffff ), true );
            var newOutLineStyle = new Style( Color.FromArgb( 0xffffff ), true );

            var elipseFrame = new Rect<double>( 1, 1000, 10, 500 );
            var elipse = new Elipse( elipseFrame, fillStyle, outLineStyle );
            var rectangleFrame = new Rect<double>( 1, 100, 100, 100 );
            var rectangle = new Composite.Drawable.Rectangle( rectangleFrame, fillStyle, outLineStyle );
            var triangleFrame = new Rect<double>( 10, 10, 10, 10 );
            var triangle = new Triangle( triangleFrame, fillStyle, outLineStyle );

            var triangleGroup = new GroupShape();
            var group = new GroupShape();

            triangleGroup.InsertShape( triangle, 0 );
            group.InsertShape( elipse, 0 );
            group.InsertShape( rectangle, 0 );
            group.InsertShape( triangleGroup, 0 );

            var currentFillStyle = group.GetFillStyle();
            var currentOutLineStyle = group.GetOutlineStyle();

            Assert.IsTrue( CompareStyle( fillStyle, group.GetFillStyle() ) );
            Assert.IsTrue( CompareStyle( outLineStyle, group.GetOutlineStyle() ) );
            Assert.IsTrue( CompareStyle( currentFillStyle, group.GetFillStyle() ) );
            Assert.IsTrue( CompareStyle( currentOutLineStyle, group.GetOutlineStyle() ) );
            Assert.IsTrue( CompareStyle( fillStyle, group.GetShapeAtIndex( 0 ).GetFillStyle() ) );
            Assert.IsTrue( CompareStyle( outLineStyle, group.GetShapeAtIndex( 0 ).GetOutlineStyle() ) );
            Assert.IsTrue( CompareStyle( fillStyle, ( ( IGroupShape ) group.GetShapeAtIndex( 0 ) ).GetShapeAtIndex( 0 ).GetFillStyle() ) );
            Assert.IsTrue( CompareStyle( outLineStyle, ( ( IGroupShape ) group.GetShapeAtIndex( 0 ) ).GetShapeAtIndex( 0 ).GetOutlineStyle() ) );
            Assert.IsTrue( CompareStyle( fillStyle, group.GetShapeAtIndex( 1 ).GetFillStyle() ) );
            Assert.IsTrue( CompareStyle( outLineStyle, group.GetShapeAtIndex( 1 ).GetOutlineStyle() ) );
            Assert.IsTrue( CompareStyle( fillStyle, group.GetShapeAtIndex( 2 ).GetFillStyle() ) );
            Assert.IsTrue( CompareStyle( outLineStyle, group.GetShapeAtIndex( 2 ).GetOutlineStyle() ) );

            group.SetFillStyle( newFillStyle );
            group.SetOutlineStyle( newOutLineStyle );

            Assert.IsTrue( CompareStyle( newFillStyle, group.GetFillStyle() ) );
            Assert.IsTrue( CompareStyle( newOutLineStyle, group.GetOutlineStyle() ) );
            Assert.IsTrue( CompareStyle( currentFillStyle, group.GetFillStyle() ) );
            Assert.IsTrue( CompareStyle( currentOutLineStyle, group.GetOutlineStyle() ) );
            Assert.IsTrue( CompareStyle( newFillStyle, group.GetShapeAtIndex( 0 ).GetFillStyle() ) );
            Assert.IsTrue( CompareStyle( newOutLineStyle, group.GetShapeAtIndex( 0 ).GetOutlineStyle() ) );
            Assert.IsTrue( CompareStyle( newFillStyle, ( ( IGroupShape ) group.GetShapeAtIndex( 0 ) ).GetShapeAtIndex( 0 ).GetFillStyle() ) );
            Assert.IsTrue( CompareStyle( newOutLineStyle, ( ( IGroupShape ) group.GetShapeAtIndex( 0 ) ).GetShapeAtIndex( 0 ).GetOutlineStyle() ) );
            Assert.IsTrue( CompareStyle( newFillStyle, group.GetShapeAtIndex( 1 ).GetFillStyle() ) );
            Assert.IsTrue( CompareStyle( newOutLineStyle, group.GetShapeAtIndex( 1 ).GetOutlineStyle() ) );
            Assert.IsTrue( CompareStyle( newFillStyle, group.GetShapeAtIndex( 2 ).GetFillStyle() ) );
            Assert.IsTrue( CompareStyle( newOutLineStyle, group.GetShapeAtIndex( 2 ).GetOutlineStyle() ) );
        }

        [TestMethod]
        public void SetStyleWithOutShapes()
        {
            var fillStyle = new Style( Color.FromArgb( 0xff0000 ), true );
            var outLineStyle = new Style( Color.FromArgb( 0xffff00 ), true );
            var emptyStyle = new Style();
            var group = new GroupShape();

            group.SetFillStyle( fillStyle );
            group.SetOutlineStyle( outLineStyle );

            Assert.IsTrue( CompareStyle( emptyStyle, group.GetFillStyle() ) );
            Assert.IsTrue( CompareStyle( emptyStyle, group.GetOutlineStyle() ) );
        }

        [TestMethod]
        public void GetStyleFromDifferentShapesTest()
        {
            var fillStyleOne = new Style( Color.FromArgb( 0xff0000 ), true );
            var fillStyleTwo = new Style( Color.FromArgb( 0xffff00 ), true );
            var outLineStyleOne = new Style( Color.FromArgb( 0xffff00 ), true );
            var outLineStyleTwo = new Style( Color.FromArgb( 0x00ff00 ), true );
            var emptyStyle = new Style();
            var elipseFrame = new Rect<double>( 1, 1000, 10, 500 );
            var elipse = new Elipse( elipseFrame, fillStyleOne, outLineStyleOne );
            var rectangleFrame = new Rect<double>( 1, 100, 100, 100 );
            var rectangle = new Composite.Drawable.Rectangle( rectangleFrame, fillStyleTwo, outLineStyleTwo );
            var group = new GroupShape();

            group.InsertShape( elipse, 0 );
            group.InsertShape( rectangle, 0 );

            Assert.IsTrue( CompareStyle( emptyStyle, group.GetFillStyle() ) );
            Assert.IsTrue( CompareStyle( emptyStyle, group.GetOutlineStyle() ) );
        }

        [TestMethod]
        public void GetStyleFromSameShapesTest()
        {
            var fillStyle = new Style( Color.FromArgb( 0xff0000 ), true );
            var outLineStyle = new Style( Color.FromArgb( 0xffff00 ), true );
            var elipseFrame = new Rect<double>( 1, 1000, 10, 500 );
            var elipse = new Elipse( elipseFrame, fillStyle, outLineStyle );
            var rectangleFrame = new Rect<double>( 1, 100, 100, 100 );
            var rectangle = new Composite.Drawable.Rectangle( rectangleFrame, fillStyle, outLineStyle );
            var group = new GroupShape();

            group.InsertShape( elipse, 0 );
            group.InsertShape( rectangle, 0 );

            Assert.IsTrue( CompareStyle( fillStyle, group.GetFillStyle() ) );
            Assert.IsTrue( CompareStyle( outLineStyle, group.GetOutlineStyle() ) );

            var triangleFrame = new Rect<double>( 10, 10, 10, 10 );
            var triangle = new Triangle( triangleFrame, fillStyle, outLineStyle );
            var triangleGroup = new GroupShape();

            triangleGroup.InsertShape( triangle, 0 );
            group.InsertShape( triangleGroup, 0 );

            Assert.IsTrue( CompareStyle( fillStyle, group.GetFillStyle() ) );
            Assert.IsTrue( CompareStyle( outLineStyle, group.GetOutlineStyle() ) );
        }

        [TestMethod]
        public void GetStyleFirstFromDifferentShapesThenFromSameTest()
        {
            var fillStyleOne = new Style( Color.FromArgb( 0xff0000 ), true );
            var fillStyleTwo = new Style( Color.FromArgb( 0xffff00 ), true );
            var outLineStyleOne = new Style( Color.FromArgb( 0xffff00 ), true );
            var outLineStyleTwo = new Style( Color.FromArgb( 0x00ff00 ), true );
            var emptyStyle = new Style();

            var elipseFrame = new Rect<double>( 1, 1000, 10, 500 );
            var elipse = new Elipse( elipseFrame, fillStyleOne, outLineStyleOne );
            var rectangleFrame = new Rect<double>( 1, 100, 100, 100 );
            var rectangle = new Composite.Drawable.Rectangle( rectangleFrame, fillStyleTwo, outLineStyleTwo );
            var triangleFrame = new Rect<double>( 10, 10, 10, 10 );
            var triangle = new Triangle( triangleFrame, fillStyleOne, outLineStyleOne );

            var group = new GroupShape();
            var triangleGroup = new GroupShape();
            var currentFillStyle = group.GetFillStyle();
            var currentOutLineStyle = group.GetOutlineStyle();

            triangleGroup.InsertShape( triangle, 0 );
            group.InsertShape( triangleGroup, 0 );
            group.InsertShape( elipse, 0 );

            Assert.IsTrue( CompareStyle( fillStyleOne, group.GetFillStyle() ) );
            Assert.IsTrue( CompareStyle( outLineStyleOne, group.GetOutlineStyle() ) );
            Assert.IsTrue( CompareStyle( fillStyleOne, currentFillStyle ) );
            Assert.IsTrue( CompareStyle( outLineStyleOne, currentOutLineStyle ) );

            group.InsertShape( rectangle, 0 );

            Assert.IsTrue( CompareStyle( emptyStyle, group.GetFillStyle() ) );
            Assert.IsTrue( CompareStyle( emptyStyle, group.GetOutlineStyle() ) );
            Assert.IsTrue( CompareStyle( emptyStyle, currentFillStyle ) );
            Assert.IsTrue( CompareStyle( emptyStyle, currentOutLineStyle ) );

            rectangle.SetFillStyle( fillStyleOne );
            rectangle.SetOutlineStyle( outLineStyleOne );

            Assert.IsTrue( CompareStyle( fillStyleOne, group.GetFillStyle() ) );
            Assert.IsTrue( CompareStyle( outLineStyleOne, group.GetOutlineStyle() ) );
            Assert.IsTrue( CompareStyle( fillStyleOne, currentFillStyle ) );
            Assert.IsTrue( CompareStyle( outLineStyleOne, currentOutLineStyle ) );

            triangle.SetFillStyle( fillStyleTwo );
            triangle.SetOutlineStyle( outLineStyleTwo );

            Assert.IsTrue( CompareStyle( emptyStyle, group.GetFillStyle() ) );
            Assert.IsTrue( CompareStyle( emptyStyle, group.GetOutlineStyle() ) );
            Assert.IsTrue( CompareStyle( emptyStyle, currentFillStyle ) );
            Assert.IsTrue( CompareStyle( emptyStyle, currentOutLineStyle ) );

            triangle.SetFillStyle( fillStyleOne );
            triangle.SetOutlineStyle( outLineStyleOne );

            Assert.IsTrue( CompareStyle( fillStyleOne, group.GetFillStyle() ) );
            Assert.IsTrue( CompareStyle( outLineStyleOne, group.GetOutlineStyle() ) );
            Assert.IsTrue( CompareStyle( fillStyleOne, currentFillStyle ) );
            Assert.IsTrue( CompareStyle( outLineStyleOne, currentOutLineStyle ) );
        }

        [TestMethod]
        public void GetStyleFirstFromSameShapesThenFromDifferentTest()
        {
            var fillStyleOne = new Style( Color.FromArgb( 0xff0000 ), true );
            var fillStyleTwo = new Style( Color.FromArgb( 0xffff00 ), true );
            var outLineStyleOne = new Style( Color.FromArgb( 0xffff00 ), true );
            var outLineStyleTwo = new Style( Color.FromArgb( 0x00ff00 ), true );
            var emptyStyle = new Style();
            var elipseFrame = new Rect<double>( 1, 1000, 10, 500 );
            var elipse = new Elipse( elipseFrame, fillStyleOne, outLineStyleOne );
            var rectangleFrame = new Rect<double>( 1, 100, 100, 100 );
            var rectangle = new Composite.Drawable.Rectangle( rectangleFrame, fillStyleOne, outLineStyleOne );
            var group = new GroupShape();
            group.InsertShape( elipse, 0 );
            group.InsertShape( rectangle, 0 );
            var currentGroupFillStyle = group.GetFillStyle();
            var currentGroupOutLineStyle = group.GetOutlineStyle();
            Assert.IsTrue( CompareStyle( fillStyleOne, group.GetFillStyle() ) );
            Assert.IsTrue( CompareStyle( outLineStyleOne, group.GetOutlineStyle() ) );
            Assert.IsTrue( CompareStyle( currentGroupFillStyle, fillStyleOne ) );
            Assert.IsTrue( CompareStyle( currentGroupOutLineStyle, outLineStyleOne ) );
            rectangle.SetFillStyle( fillStyleTwo );
            rectangle.SetOutlineStyle( outLineStyleTwo );
            Assert.IsTrue( CompareStyle( emptyStyle, group.GetFillStyle() ) );
            Assert.IsTrue( CompareStyle( emptyStyle, group.GetOutlineStyle() ) );
            Assert.IsTrue( CompareStyle( emptyStyle, currentGroupFillStyle ) );
            Assert.IsTrue( CompareStyle( emptyStyle, currentGroupOutLineStyle ) );
        }

        private bool CompareStyle( IStyle styleOne, IStyle styleTwo )
        {
            return styleOne.GetColor() == styleTwo.GetColor() && styleOne.IsEnable() == styleTwo.IsEnable();
        }

        private bool CompareFrame( Rect<double> frameOne, Rect<double> frameTwo )
        {
            return frameOne.Height == frameTwo.Height
                && frameOne.Left == frameTwo.Left
                && frameOne.Top == frameTwo.Top
                && frameOne.Width == frameTwo.Width;
        }
    }
}
