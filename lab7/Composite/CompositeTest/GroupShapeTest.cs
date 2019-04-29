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
            var outLineStyle = new OutLineStyle( Color.FromArgb( 0xffff00 ), true, 2 );

            var elipseFrame = new Rect<double>( 5, 7, 10, 7 );
            var elipse = new Elipse( elipseFrame, fillStyle, outLineStyle );
            var rectangleFrame = new Rect<double>( 10, 12, 12, 10 );
            var rectangle = new Composite.Drawable.Rectangle( rectangleFrame, fillStyle, outLineStyle );
            var triangleFrame = new Rect<double>( 8, 6, 5, 9 );
            var triangle = new Triangle( triangleFrame, fillStyle, outLineStyle );

            var triangleGroup = new GroupShape();
            var group = new GroupShape();

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
            var group = new GroupShape();
            Assert.IsNull( group.GetFrame() );
        }

        [TestMethod]
        public void SetFrameWithNoShapesTest()
        {
            var group = new GroupShape();
            group.SetFrame( new Rect<double>( 1, 1, 1, 1 ) );
        }

        [TestMethod]
        public void SetFrameTest()
        {
            var fillStyle = new Style( Color.FromArgb( 0xff0000 ), true );
            var outLineStyle = new OutLineStyle( Color.FromArgb( 0xffff00 ), true, 2 );

            var elipseFrame = new Rect<double>( 5, 7, 10, 7 );
            var elipse = new Elipse( elipseFrame, fillStyle, outLineStyle );
            var rectangleFrame = new Rect<double>( 10, 12, 12, 10 );
            var rectangle = new Composite.Drawable.Rectangle( rectangleFrame, fillStyle, outLineStyle );
            var triangleFrame = new Rect<double>( 8, 6, 5, 9 );
            var triangle = new Triangle( triangleFrame, fillStyle, outLineStyle );

            var group = new GroupShape();
            var triangleGroup = new GroupShape();

            group.InsertShape( elipse, 0 );
            group.InsertShape( rectangle, 0 );
            triangleGroup.InsertShape( triangle, 0 );
            group.InsertShape( triangleGroup, 0 );

            var newGroupFrame = new Rect<double>( 8, 34, -5, 32 );
            group.SetFrame( newGroupFrame );

            Assert.IsTrue( CompareFrame( newGroupFrame, group.GetFrame() ) );
            Assert.AreEqual( 14, group.GetShapeAtIndex( 0 ).GetFrame().Left );
            Assert.AreEqual( 12, group.GetShapeAtIndex( 0 ).GetFrame().Width );
            Assert.AreEqual( -19, group.GetShapeAtIndex( 0 ).GetFrame().Top );
            Assert.AreEqual( 18, group.GetShapeAtIndex( 0 ).GetFrame().Height );
            Assert.AreEqual( 18, group.GetShapeAtIndex( 1 ).GetFrame().Left );
            Assert.AreEqual( 24, group.GetShapeAtIndex( 1 ).GetFrame().Width );
            Assert.AreEqual( -5, group.GetShapeAtIndex( 1 ).GetFrame().Top );
            Assert.AreEqual( 20, group.GetShapeAtIndex( 1 ).GetFrame().Height );
            Assert.AreEqual( 8, group.GetShapeAtIndex( 2 ).GetFrame().Left );
            Assert.AreEqual( 14, group.GetShapeAtIndex( 2 ).GetFrame().Width );
            Assert.AreEqual( -9, group.GetShapeAtIndex( 2 ).GetFrame().Top );
            Assert.AreEqual( 14, group.GetShapeAtIndex( 2 ).GetFrame().Height );
        }

        [TestMethod]
        public void SetIncorrectFrameTest()
        {
            var fillStyle = new Style( Color.FromArgb( 0xff0000 ), true );
            var outLineStyle = new OutLineStyle( Color.FromArgb( 0xffff00 ), true, 2 );

            var elipseFrame = new Rect<double>( 1, 1000, 10, 500 );
            var elipse = new Elipse( elipseFrame, fillStyle, outLineStyle );
            var group = new GroupShape();

            Assert.ThrowsException<ArgumentException>( () => group.SetFrame( new Rect<double>( 1, -1000, 10, 500 ) ) );
            Assert.ThrowsException<ArgumentException>( () => group.SetFrame( new Rect<double>( 1, 1000, 10, -500 ) ) );
        }

        [TestMethod]
        public void DrawTest()
        {
            StringWriter stringWriter = new StringWriter();
            ICanvas canvas = new Canvas( stringWriter );
            Rect<double> elipseFrame = new Rect<double>( 1, 1000, 10, 500 );
            Elipse elipse = new Elipse( elipseFrame, new Style( Color.FromArgb( 0xff0000 ), true ), new OutLineStyle( Color.FromArgb( 0xffff00 ), true, 2 ) );
            Rect<double> rectangleFrame = new Rect<double>( 1, 100, 100, 100 );
            Composite.Drawable.Rectangle rectangle = new Composite.Drawable.Rectangle( rectangleFrame, new Style( Color.FromArgb( 0xff0000 ), true ), new OutLineStyle( Color.FromArgb( 0xffff00 ), true, 2 ) );
            GroupShape group = new GroupShape();
            group.InsertShape( elipse, 0 );
            group.InsertShape( rectangle, 0 );
            group.Draw( canvas );
            StringWriter result = new StringWriter();
            result.WriteLine( "Begin fill" );
            result.WriteLine( "Move to x: 1 y: 100" );
            result.WriteLine( "Line to x: 1 y: 0 line color: ff0000 line width: 2" );
            result.WriteLine( "Line to x: 101 y: 0 line color: ff0000 line width: 2" );
            result.WriteLine( "Line to x: 101 y: 100 line color: ff0000 line width: 2" );
            result.WriteLine( "Line to x: 1 y: 100 line color: ff0000 line width: 2" );
            result.WriteLine( "End fill" );
            result.WriteLine( "Begin fill" );
            result.WriteLine( "Draw ellipse left: 1 top: 10 width: 1000 height: 500 line color: ff0000 line width: 2" );
            result.WriteLine( "End fill" );
            Assert.AreEqual( result.ToString(), stringWriter.ToString() );
        }

        [TestMethod]
        public void ChangeGroupStyleTest()
        {
            var fillStyle = new Style( Color.FromArgb( 0xff0000 ), true );
            var outLineStyle = new OutLineStyle( Color.FromArgb( 0xffff00 ), true, 2 );
            var newFillStyle = new Style( Color.FromArgb( 0xffffff ), false );
            var newOutLineStyle = new OutLineStyle( Color.FromArgb( 0xffffff ), false, 3 );

            var elipseFrame = new Rect<double>( 1, 1000, 10, 500 );
            var elipse = new Elipse( elipseFrame, fillStyle, outLineStyle );
            var rectangleFrame = new Rect<double>( 1, 100, 100, 100 );
            var rectangle = new Composite.Drawable.Rectangle( rectangleFrame, fillStyle, outLineStyle );
            var triangleFrame = new Rect<double>( 1, 10, 10, 10 );
            var triabgle = new Triangle( triangleFrame, fillStyle, outLineStyle );

            var triangleGroup = new GroupShape();
            var group = new GroupShape();

            group.InsertShape( elipse, 0 );
            group.InsertShape( rectangle, 0 );
            triangleGroup.InsertShape( triabgle, 0 );
            group.InsertShape( triangleGroup, 0 );

            var currentFillStyle = group.GetFillStyle();
            var currentOutLineStyle = group.GetOutlineStyle();

            Assert.IsTrue( CompareStyle( fillStyle, group.GetFillStyle() ) );
            Assert.IsTrue( CompareOutLineStyle( outLineStyle, group.GetOutlineStyle() ) );
            Assert.IsTrue( CompareStyle( currentFillStyle, fillStyle ) );
            Assert.IsTrue( CompareOutLineStyle( currentOutLineStyle, outLineStyle ) );
            Assert.IsTrue( CompareStyle( fillStyle, group.GetShapeAtIndex( 0 ).GetFillStyle() ) );
            Assert.IsTrue( CompareOutLineStyle( outLineStyle, group.GetShapeAtIndex( 0 ).GetOutlineStyle() ) );
            Assert.IsTrue( CompareStyle( fillStyle, ( ( IGroupShape ) group.GetShapeAtIndex( 0 ) ).GetShapeAtIndex( 0 ).GetFillStyle() ) );
            Assert.IsTrue( CompareOutLineStyle( outLineStyle, ( ( IGroupShape ) group.GetShapeAtIndex( 0 ) ).GetShapeAtIndex( 0 ).GetOutlineStyle() ) );
            Assert.IsTrue( CompareStyle( fillStyle, group.GetShapeAtIndex( 1 ).GetFillStyle() ) );
            Assert.IsTrue( CompareOutLineStyle( outLineStyle, group.GetShapeAtIndex( 1 ).GetOutlineStyle() ) );
            Assert.IsTrue( CompareStyle( fillStyle, group.GetShapeAtIndex( 2 ).GetFillStyle() ) );
            Assert.IsTrue( CompareOutLineStyle( outLineStyle, group.GetShapeAtIndex( 2 ).GetOutlineStyle() ) );

            currentFillStyle.SetColor( newFillStyle.GetColor() );
            currentFillStyle.Enable( newFillStyle.IsEnable() );
            currentOutLineStyle.SetColor( newOutLineStyle.GetColor() );
            currentOutLineStyle.Enable( newOutLineStyle.IsEnable() );
            currentOutLineStyle.SetLineWidth( newOutLineStyle.GetLineWidth() ?? 0 );

            Assert.IsTrue( CompareStyle( newFillStyle, group.GetFillStyle() ) );
            Assert.IsTrue( CompareOutLineStyle( newOutLineStyle, group.GetOutlineStyle() ) );
            Assert.IsTrue( CompareStyle( currentFillStyle, group.GetFillStyle() ) );
            Assert.IsTrue( CompareOutLineStyle( currentOutLineStyle, group.GetOutlineStyle() ) );
            Assert.IsTrue( CompareStyle( newFillStyle, group.GetShapeAtIndex( 0 ).GetFillStyle() ) );
            Assert.IsTrue( CompareOutLineStyle( newOutLineStyle, group.GetShapeAtIndex( 0 ).GetOutlineStyle() ) );
            Assert.IsTrue( CompareStyle( newFillStyle, group.GetShapeAtIndex( 1 ).GetFillStyle() ) );
            Assert.IsTrue( CompareOutLineStyle( newOutLineStyle, group.GetShapeAtIndex( 1 ).GetOutlineStyle() ) );
            Assert.IsTrue( CompareStyle( newFillStyle, group.GetShapeAtIndex( 2 ).GetFillStyle() ) );
            Assert.IsTrue( CompareOutLineStyle( newOutLineStyle, group.GetShapeAtIndex( 2 ).GetOutlineStyle() ) );
            Assert.IsTrue( CompareStyle( newFillStyle, ( ( IGroupShape ) group.GetShapeAtIndex( 0 ) ).GetShapeAtIndex( 0 ).GetFillStyle() ) );
            Assert.IsTrue( CompareOutLineStyle( newOutLineStyle, ( ( IGroupShape ) group.GetShapeAtIndex( 0 ) ).GetShapeAtIndex( 0 ).GetOutlineStyle() ) );
        }

        [TestMethod]
        public void SetStyleWithOutShapes()
        {
            var fillStyle = new Style( Color.FromArgb( 0xff0000 ), true );
            var outLineStyle = new OutLineStyle( Color.FromArgb( 0xffff00 ), true, 2 );
            var emptyStyle = new Style();
            var emptyOutLineStyle = new OutLineStyle();
            var group = new GroupShape();

            var currentFillStyle = group.GetFillStyle();
            var currentOutLineStyle = group.GetOutlineStyle();

            Assert.IsTrue( CompareStyle( emptyStyle, group.GetFillStyle() ) );
            Assert.IsTrue( CompareOutLineStyle( emptyOutLineStyle, group.GetOutlineStyle() ) );
        }

        [TestMethod]
        public void GetColorFromDifferentShapesTest()
        {
            var fillStyleOne = new Style( Color.FromArgb( 0xff0000 ), true );
            var fillStyleTwo = new Style( Color.FromArgb( 0xffff00 ), true );
            var outLineStyleOne = new OutLineStyle( Color.FromArgb( 0xffff00 ), true, 3 );
            var outLineStyleTwo = new OutLineStyle( Color.FromArgb( 0x00ff00 ), true, 3 );

            var elipseFrame = new Rect<double>( 1, 1000, 10, 500 );
            var elipse = new Elipse( elipseFrame, fillStyleOne, outLineStyleOne );
            var rectangleFrame = new Rect<double>( 1, 100, 100, 100 );
            var rectangle = new Composite.Drawable.Rectangle( rectangleFrame, fillStyleOne, outLineStyleOne );
            var triangleFrame = new Rect<double>( 1, 10, 10, 10 );
            var triangle = new Triangle( triangleFrame, fillStyleTwo, outLineStyleTwo );

            var triangleGroup = new GroupShape();
            var group = new GroupShape();

            group.InsertShape( elipse, 0 );
            group.InsertShape( rectangle, 0 );
            triangleGroup.InsertShape( triangle, 0 );
            group.InsertShape( triangleGroup, 0 );

            Assert.AreEqual( Color.Empty, group.GetFillStyle().GetColor() );
            Assert.AreEqual( Color.Empty, group.GetOutlineStyle().GetColor() );
        }

        [TestMethod]
        public void GetEnableFromDifferentShapesTest()
        {
            var fillStyleOne = new Style( Color.FromArgb( 0xff0000 ), false );
            var fillStyleTwo = new Style( Color.FromArgb( 0xff0000 ), true );
            var outLineStyleOne = new OutLineStyle( Color.FromArgb( 0xff0000 ), false, 3 );
            var outLineStyleTwo = new OutLineStyle( Color.FromArgb( 0xff0000 ), true, 3 );

            var elipseFrame = new Rect<double>( 1, 1000, 10, 500 );
            var elipse = new Elipse( elipseFrame, fillStyleOne, outLineStyleOne );
            var rectangleFrame = new Rect<double>( 1, 100, 100, 100 );
            var rectangle = new Composite.Drawable.Rectangle( rectangleFrame, fillStyleOne, outLineStyleOne );
            var triangleFrame = new Rect<double>( 1, 10, 10, 10 );
            var triabgle = new Triangle( triangleFrame, fillStyleTwo, outLineStyleTwo );

            var triangleGroup = new GroupShape();
            var group = new GroupShape();

            group.InsertShape( elipse, 0 );
            group.InsertShape( rectangle, 0 );

            Assert.AreEqual( false, group.GetFillStyle().IsEnable() );
            Assert.AreEqual( false, group.GetOutlineStyle().IsEnable() );
        }

        [TestMethod]
        public void GetLineWidthFromDifferentShapesTest()
        {
            var fillStyle = new Style( Color.FromArgb( 0xff0000 ), false );
            var outLineStyleOne = new OutLineStyle( Color.FromArgb( 0xff0000 ), true, 2 );
            var outLineStyleTwo = new OutLineStyle( Color.FromArgb( 0xff0000 ), true, 3 );

            var elipseFrame = new Rect<double>( 1, 1000, 10, 500 );
            var elipse = new Elipse( elipseFrame, fillStyle, outLineStyleOne );
            var rectangleFrame = new Rect<double>( 1, 100, 100, 100 );
            var rectangle = new Composite.Drawable.Rectangle( rectangleFrame, fillStyle, outLineStyleOne );
            var triangleFrame = new Rect<double>( 1, 10, 10, 10 );
            var triabgle = new Triangle( triangleFrame, fillStyle, outLineStyleTwo );

            var triangleGroup = new GroupShape();
            var group = new GroupShape();

            group.InsertShape( elipse, 0 );
            group.InsertShape( rectangle, 0 );

            Assert.AreEqual( 2, group.GetOutlineStyle().GetLineWidth() );

            group.InsertShape( triangleGroup, 0 );

            Assert.AreEqual( null, group.GetOutlineStyle().GetLineWidth() );
        }

        [TestMethod]
        public void GetStyleFromSameThenDiffernetShapesTest()
        {
            var fillStyleOne = new Style( Color.FromArgb( 0xff0000 ), false );
            var fillStyleTwo = new Style( Color.FromArgb( 0xffff00 ), true );
            var outLineStyleOne = new OutLineStyle( Color.FromArgb( 0xfff000 ), false, 2 );
            var outLineStyleTwo = new OutLineStyle( Color.FromArgb( 0xff0000 ), true, 3 );

            var elipseFrame = new Rect<double>( 1, 1000, 10, 500 );
            var elipse = new Elipse( elipseFrame, fillStyleOne, outLineStyleOne );
            var rectangleFrame = new Rect<double>( 1, 100, 100, 100 );
            var rectangle = new Composite.Drawable.Rectangle( rectangleFrame, fillStyleOne, outLineStyleOne );
            var triangleFrame = new Rect<double>( 1, 10, 10, 10 );
            var triangle = new Triangle( triangleFrame, fillStyleTwo, outLineStyleTwo );

            var triangleGroup = new GroupShape();
            var group = new GroupShape();

            var currentFillStyle = group.GetFillStyle();
            var currentOutLineStyle = group.GetOutlineStyle();

            group.InsertShape( elipse, 0 );

            Assert.IsTrue( CompareStyle( fillStyleOne, group.GetFillStyle() ) );
            Assert.IsTrue( CompareStyle( outLineStyleOne, group.GetOutlineStyle() ) );
            Assert.IsTrue( CompareStyle( currentFillStyle, fillStyleOne ) );
            Assert.IsTrue( CompareStyle( currentOutLineStyle, outLineStyleOne ) );

            group.InsertShape( rectangle, 0 );

            Assert.IsTrue( CompareStyle( fillStyleOne, group.GetFillStyle() ) );
            Assert.IsTrue( CompareStyle( outLineStyleOne, group.GetOutlineStyle() ) );
            Assert.IsTrue( CompareStyle( currentFillStyle, fillStyleOne ) );
            Assert.IsTrue( CompareStyle( currentOutLineStyle, outLineStyleOne ) );

            triangleGroup.InsertShape( triangle, 0 );
            group.InsertShape( triangleGroup, 0 );

            Assert.AreEqual( Color.Empty, group.GetFillStyle().GetColor() );
            Assert.AreEqual( Color.Empty, group.GetOutlineStyle().GetColor() );
            Assert.AreEqual( fillStyleOne.IsEnable(), group.GetFillStyle().IsEnable() );
            Assert.AreEqual( outLineStyleOne.IsEnable(), group.GetOutlineStyle().IsEnable() );
            Assert.AreEqual( null, group.GetOutlineStyle().GetLineWidth() );

            Assert.AreEqual( Color.Empty, currentFillStyle.GetColor() );
            Assert.AreEqual( Color.Empty, currentOutLineStyle.GetColor() );
            Assert.AreEqual( fillStyleOne.IsEnable(), currentFillStyle.IsEnable() );
            Assert.AreEqual( outLineStyleOne.IsEnable(), currentOutLineStyle.IsEnable() );
            Assert.AreEqual( null, currentOutLineStyle.GetLineWidth() );
        }

        private bool CompareStyle( IStyle styleOne, IStyle styleTwo )
        {
            return styleOne.GetColor() == styleTwo.GetColor() && styleOne.IsEnable() == styleTwo.IsEnable();
        }

        private bool CompareOutLineStyle( IOutLineStyle styleOne, IOutLineStyle styleTwo )
        {
            return styleOne.GetColor() == styleTwo.GetColor() && styleOne.IsEnable() == styleTwo.IsEnable() && styleOne.GetLineWidth() == styleTwo.GetLineWidth();
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
