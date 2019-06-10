using System.Drawing;
using Composite.Groups;
using Composite.Shape;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rectangle = Composite.Shape.Rectangle;
using Style = Composite.Style.Style;

namespace CompositeTest
{
    [TestClass]
    public class GroupStyleTest
    {
        [TestMethod]
        public void GetColorFromGroupWithoutShapes()
        {
            var group = new GroupShape();
            var fillStyle = group.GetFillStyle();
            Assert.AreEqual( fillStyle.GetColor(), Color.Empty );
        }

        [TestMethod]
        public void GetColorFromGroupWithShapesWithSameColor()
        {
            var fillStyle = new Style( Color.Green, true );
            var rectangleFrame = new Rect( 10, 10, 10, 10 );
            var ellipseFrame = new Rect( 12, 12, 12, 12 );
            var triangleFrame = new Rect( 15, 15, 15, 15 );

            var rectangle = new Rectangle( rectangleFrame, fillStyle );
            var ellipse = new Elipse( ellipseFrame, fillStyle );
            var triangle = new Triangle( triangleFrame, fillStyle );

            var group = new GroupShape();
            var triangleGroup = new GroupShape();

            triangleGroup.InsertShape( triangle, 0 );
            group.InsertShape( ellipse, 0 );
            group.InsertShape( triangleGroup, 0 );
            group.InsertShape( rectangle, 0 );

            var groupFillStyle = group.GetFillStyle();
            Assert.AreEqual( groupFillStyle.GetColor(), Color.Green );
        }

        [TestMethod]
        public void GetColorFromGroupWithShapesWithDifferentColor()
        {
            var fillStyle = new Style( Color.Green, true );
            var triangleFillStyle = new Style( Color.Yellow, true );
            var rectangleFrame = new Rect( 10, 10, 10, 10 );
            var ellipseFrame = new Rect( 12, 12, 12, 12 );
            var triangleFrame = new Rect( 15, 15, 15, 15 );

            var rectangle = new Rectangle( rectangleFrame, fillStyle );
            var ellipse = new Elipse( ellipseFrame, fillStyle );
            var triangle = new Triangle( triangleFrame, triangleFillStyle );

            var group = new GroupShape();
            var triangleGroup = new GroupShape();

            triangleGroup.InsertShape( triangle, 0 );
            group.InsertShape( ellipse, 0 );
            group.InsertShape( triangleGroup, 0 );
            group.InsertShape( rectangle, 0 );

            var groupFillStyle = group.GetFillStyle();
            Assert.AreEqual( groupFillStyle.GetColor(), Color.Empty );
        }

        [TestMethod]
        public void GetColorAfterRemovingShapeWithDifferentColor()
        {
            var fillStyle = new Style( Color.Green, true );
            var triangleFillStyle = new Style( Color.Yellow, true );
            var rectangleFrame = new Rect( 10, 10, 10, 10 );
            var ellipseFrame = new Rect( 12, 12, 12, 12 );
            var triangleFrame = new Rect( 15, 15, 15, 15 );

            var rectangle = new Rectangle( rectangleFrame, fillStyle );
            var ellipse = new Elipse( ellipseFrame, fillStyle );
            var triangle = new Triangle( triangleFrame, triangleFillStyle );

            var group = new GroupShape();
            var triangleGroup = new GroupShape();

            triangleGroup.InsertShape( triangle, 0 );
            group.InsertShape( ellipse, 0 );
            group.InsertShape( rectangle, 0 );
            group.InsertShape( triangleGroup, 0 );

            var groupFillStyle = group.GetFillStyle();
            Assert.AreEqual( groupFillStyle.GetColor(), Color.Empty );

            group.RemoveShapeAtIndex( 0 );
            Assert.AreEqual( Color.Green, groupFillStyle.GetColor() );
        }

        [TestMethod]
        public void GetColorAfterRemovingShapeWitSameColor()
        {
            var fillStyle = new Style( Color.Green, true );
            var triangleFillStyle = new Style( Color.Green, true );
            var rectangleFrame = new Rect( 10, 10, 10, 10 );
            var ellipseFrame = new Rect( 12, 12, 12, 12 );
            var triangleFrame = new Rect( 15, 15, 15, 15 );

            var rectangle = new Rectangle( rectangleFrame, fillStyle );
            var ellipse = new Elipse( ellipseFrame, fillStyle );
            var triangle = new Triangle( triangleFrame, triangleFillStyle );

            var group = new GroupShape();
            var triangleGroup = new GroupShape();

            triangleGroup.InsertShape( triangle, 0 );
            group.InsertShape( ellipse, 0 );
            group.InsertShape( rectangle, 0 );
            group.InsertShape( triangleGroup, 0 );

            var groupFillStyle = group.GetFillStyle();
            Assert.AreEqual( groupFillStyle.GetColor(), Color.Green );

            group.RemoveShapeAtIndex( 0 );
            Assert.AreEqual( Color.Green, groupFillStyle.GetColor() );
        }

        [TestMethod]
        public void GetColorAfterAddingShapeWithDifferentColor()
        {
            var fillStyle = new Style( Color.Green, true );
            var triangleFillStyle = new Style( Color.Yellow, true );
            var rectangleFrame = new Rect( 10, 10, 10, 10 );
            var ellipseFrame = new Rect( 12, 12, 12, 12 );
            var triangleFrame = new Rect( 15, 15, 15, 15 );

            var rectangle = new Rectangle( rectangleFrame, fillStyle );
            var ellipse = new Elipse( ellipseFrame, fillStyle );
            var triangle = new Triangle( triangleFrame, triangleFillStyle );

            var group = new GroupShape();
            var triangleGroup = new GroupShape();

            triangleGroup.InsertShape( triangle, 0 );
            group.InsertShape( ellipse, 0 );
            group.InsertShape( rectangle, 0 );

            var groupFillStyle = group.GetFillStyle();
            Assert.AreEqual( Color.Green, groupFillStyle.GetColor() );

            group.InsertShape( triangleGroup, 0 );
            Assert.AreEqual( Color.Empty, groupFillStyle.GetColor() );
        }

        [TestMethod]
        public void GetColorAfterAddingShapeWithSameColor()
        {
            var fillStyle = new Style( Color.Green, true );
            var triangleFillStyle = new Style( Color.Green, true );
            var rectangleFrame = new Rect( 10, 10, 10, 10 );
            var ellipseFrame = new Rect( 12, 12, 12, 12 );
            var triangleFrame = new Rect( 15, 15, 15, 15 );

            var rectangle = new Rectangle( rectangleFrame, fillStyle );
            var ellipse = new Elipse( ellipseFrame, fillStyle );
            var triangle = new Triangle( triangleFrame, triangleFillStyle );

            var group = new GroupShape();
            var triangleGroup = new GroupShape();

            triangleGroup.InsertShape( triangle, 0 );
            group.InsertShape( ellipse, 0 );
            group.InsertShape( rectangle, 0 );

            var groupFillStyle = group.GetFillStyle();
            Assert.AreEqual( Color.Green, groupFillStyle.GetColor() );

            group.InsertShape( triangleGroup, 0 );
            Assert.AreEqual( Color.Green, groupFillStyle.GetColor() );
        }

        [TestMethod]
        public void GetColorFromGroupWithEmptyGroups()
        {
            var group = new GroupShape();
            var emptyGroupOne = new GroupShape();
            var emptyGroupTwo = new GroupShape();

            group.InsertShape( emptyGroupOne, 0 );
            group.InsertShape( emptyGroupTwo, 0 );

            Assert.AreEqual( Color.Empty, group.GetFillStyle().GetColor() );
            Assert.AreEqual( Color.Empty, emptyGroupOne.GetFillStyle().GetColor() );
        }

        [TestMethod]
        public void GetColorFromGroupWithEmptyGroupsAndShapes()
        {
            var fillStyle = new Style( Color.Green, true );
            var rectangleFrame = new Rect( 10, 10, 10, 10 );
            var ellipseFrame = new Rect( 12, 12, 12, 12 );
            var triangleFrame = new Rect( 15, 15, 15, 15 );

            var rectangle = new Rectangle( rectangleFrame, fillStyle );
            var ellipse = new Elipse( ellipseFrame, fillStyle );
            var triangle = new Triangle( triangleFrame, fillStyle );

            var group = new GroupShape();
            var emptyGroup = new GroupShape();

            group.InsertShape( ellipse, 0 );
            group.InsertShape( rectangle, 0 );
            group.InsertShape( triangle, 0 );
            group.InsertShape( emptyGroup, 0 );

            Assert.AreEqual( Color.Empty, group.GetFillStyle().GetColor() );
        }

        [TestMethod]
        public void SetColorWithEmptyGroup()
        {
            var group = new GroupShape();
            var fillStyle = group.GetFillStyle();

            fillStyle.SetColor( Color.Beige );
            Assert.AreEqual( fillStyle.GetColor(), Color.Empty );
        }

        [TestMethod]
        public void SetColorWithGroupWithShapeWithSameColor()
        {
            var fillStyle = new Style( Color.Green, true );
            var rectangleFrame = new Rect( 10, 10, 10, 10 );
            var ellipseFrame = new Rect( 12, 12, 12, 12 );
            var triangleFrame = new Rect( 15, 15, 15, 15 );

            var rectangle = new Rectangle( rectangleFrame, fillStyle );
            var ellipse = new Elipse( ellipseFrame, fillStyle );
            var triangle = new Triangle( triangleFrame, fillStyle );

            var group = new GroupShape();
            var triangleGroup = new GroupShape();

            triangleGroup.InsertShape( triangle, 0 );
            group.InsertShape( ellipse, 0 );
            group.InsertShape( rectangle, 0 );

            var groupFillStyle = group.GetFillStyle();
            Assert.AreEqual( Color.Green, groupFillStyle.GetColor() );
            Assert.AreEqual( Color.Green, triangle.GetFillStyle().GetColor() );
            Assert.AreEqual( Color.Green, rectangle.GetFillStyle().GetColor() );
            Assert.AreEqual( Color.Green, ellipse.GetFillStyle().GetColor() );

            groupFillStyle.SetColor( Color.Blue );
            Assert.AreEqual( Color.Blue, groupFillStyle.GetColor() );
            Assert.AreEqual( Color.Blue, triangle.GetFillStyle().GetColor() );
            Assert.AreEqual( Color.Blue, rectangle.GetFillStyle().GetColor() );
            Assert.AreEqual( Color.Blue, ellipse.GetFillStyle().GetColor() );
        }

        [TestMethod]
        public void SetColorWithGroupWithShapeWithDifferentColor()
        {
            var fillStyle = new Style( Color.Green, true );
            var triangleFillStyle = new Style( Color.Blue, true );
            var rectangleFrame = new Rect( 10, 10, 10, 10 );
            var ellipseFrame = new Rect( 12, 12, 12, 12 );
            var triangleFrame = new Rect( 15, 15, 15, 15 );

            var rectangle = new Rectangle( rectangleFrame, fillStyle );
            var ellipse = new Elipse( ellipseFrame, fillStyle );
            var triangle = new Triangle( triangleFrame, triangleFillStyle );

            var group = new GroupShape();
            var triangleGroup = new GroupShape();
            var groupFillStyle = group.GetFillStyle();

            triangleGroup.InsertShape( triangle, 0 );
            group.InsertShape( ellipse, 0 );
            group.InsertShape( rectangle, 0 );
            group.InsertShape( triangleGroup, 0 );

            Assert.AreEqual( Color.Empty, groupFillStyle.GetColor() );
            Assert.AreEqual( Color.Blue, triangle.GetFillStyle().GetColor() );
            Assert.AreEqual( Color.Green, rectangle.GetFillStyle().GetColor() );
            Assert.AreEqual( Color.Green, ellipse.GetFillStyle().GetColor() );

            groupFillStyle.SetColor( Color.Red );
            Assert.AreEqual( Color.Red, groupFillStyle.GetColor() );
            Assert.AreEqual( Color.Red, triangle.GetFillStyle().GetColor() );
            Assert.AreEqual( Color.Red, rectangle.GetFillStyle().GetColor() );
            Assert.AreEqual( Color.Red, ellipse.GetFillStyle().GetColor() );
        }

        [TestMethod]
        public void SetColorWithGroupWithEmptyGroupsAndShapes()
        {
            var fillStyle = new Style( Color.Green, true );
            var rectangleFrame = new Rect( 10, 10, 10, 10 );
            var ellipseFrame = new Rect( 12, 12, 12, 12 );
            var triangleFrame = new Rect( 15, 15, 15, 15 );

            var rectangle = new Rectangle( rectangleFrame, fillStyle );
            var ellipse = new Elipse( ellipseFrame, fillStyle );
            var triangle = new Triangle( triangleFrame, fillStyle );

            var group = new GroupShape();
            var emptyGroup = new GroupShape();
            var groupFillStyle = group.GetFillStyle();

            group.InsertShape( ellipse, 0 );
            group.InsertShape( rectangle, 0 );
            group.InsertShape( triangle, 0 );
            group.InsertShape( emptyGroup, 0 );

            Assert.AreEqual( Color.Empty, group.GetFillStyle().GetColor() );
            Assert.AreEqual( Color.Green, triangle.GetFillStyle().GetColor() );
            Assert.AreEqual( Color.Green, rectangle.GetFillStyle().GetColor() );
            Assert.AreEqual( Color.Green, ellipse.GetFillStyle().GetColor() );
            Assert.AreEqual( Color.Empty, emptyGroup.GetFillStyle().GetColor() );

            groupFillStyle.SetColor( Color.Black );
            Assert.AreEqual( Color.Empty, group.GetFillStyle().GetColor() );
            Assert.AreEqual( Color.Black, triangle.GetFillStyle().GetColor() );
            Assert.AreEqual( Color.Black, rectangle.GetFillStyle().GetColor() );
            Assert.AreEqual( Color.Black, ellipse.GetFillStyle().GetColor() );
            Assert.AreEqual( Color.Empty, emptyGroup.GetFillStyle().GetColor() );
        }

        [TestMethod]
        public void IsEnabledTestFromGroupWithoutShapes()
        {
            var group = new GroupShape();
            var groupFillStyle = group.GetFillStyle();
            Assert.IsFalse( groupFillStyle.IsEnabled() );
        }

        [TestMethod]
        public void IsEnabledTestForGroupWithShapesWithSameValueIsEnabled()
        {
            var fillStyle = new Style( Color.Green, true );
            var rectangleFrame = new Rect( 10, 10, 10, 10 );
            var ellipseFrame = new Rect( 12, 12, 12, 12 );
            var triangleFrame = new Rect( 15, 15, 15, 15 );

            var rectangle = new Rectangle( rectangleFrame, fillStyle );
            var ellipse = new Elipse( ellipseFrame, fillStyle );
            var triangle = new Triangle( triangleFrame, fillStyle );

            var group = new GroupShape();
            var triangleGroup = new GroupShape();

            triangleGroup.InsertShape( triangle, 0 );
            group.InsertShape( ellipse, 0 );
            group.InsertShape( triangleGroup, 0 );
            group.InsertShape( rectangle, 0 );

            var groupFillStyle = group.GetFillStyle();
            Assert.IsTrue( groupFillStyle.IsEnabled() );
        }

        [TestMethod]
        public void IsEnabledTestForGroupWithShapesWithDifferentValueIsEnabled()
        {
            var fillStyle = new Style( Color.Green, true );
            var triangleFillStyle = new Style( Color.Green, false );
            var rectangleFrame = new Rect( 10, 10, 10, 10 );
            var ellipseFrame = new Rect( 12, 12, 12, 12 );
            var triangleFrame = new Rect( 15, 15, 15, 15 );

            var rectangle = new Rectangle( rectangleFrame, fillStyle );
            var ellipse = new Elipse( ellipseFrame, fillStyle );
            var triangle = new Triangle( triangleFrame, triangleFillStyle );

            var group = new GroupShape();
            var triangleGroup = new GroupShape();

            triangleGroup.InsertShape( triangle, 0 );
            group.InsertShape( ellipse, 0 );
            group.InsertShape( triangleGroup, 0 );
            group.InsertShape( rectangle, 0 );

            var groupFillStyle = group.GetFillStyle();
            Assert.IsFalse( groupFillStyle.IsEnabled() );
        }

        [TestMethod]
        public void IsEnabledTestForGroupAfterRemovingShapeWithDifferentValueIsEnabled()
        {
            var fillStyle = new Style( Color.Green, true );
            var triangleFillStyle = new Style( Color.Green, false );
            var rectangleFrame = new Rect( 10, 10, 10, 10 );
            var ellipseFrame = new Rect( 12, 12, 12, 12 );
            var triangleFrame = new Rect( 15, 15, 15, 15 );

            var rectangle = new Rectangle( rectangleFrame, fillStyle );
            var ellipse = new Elipse( ellipseFrame, fillStyle );
            var triangle = new Triangle( triangleFrame, triangleFillStyle );

            var group = new GroupShape();
            var triangleGroup = new GroupShape();

            triangleGroup.InsertShape( triangle, 0 );
            group.InsertShape( ellipse, 0 );
            group.InsertShape( rectangle, 0 );
            group.InsertShape( triangleGroup, 0 );

            var groupFillStyle = group.GetFillStyle();
            Assert.IsFalse( groupFillStyle.IsEnabled() );

            group.RemoveShapeAtIndex( 0 );
            Assert.IsTrue( groupFillStyle.IsEnabled() );
        }

        [TestMethod]
        public void IsEnabledTestForGroupAfterRemovingShapeWithSameValueIsEnabled()
        {
            var fillStyle = new Style( Color.Green, true );
            var triangleFillStyle = new Style( Color.Green, true );
            var rectangleFrame = new Rect( 10, 10, 10, 10 );
            var ellipseFrame = new Rect( 12, 12, 12, 12 );
            var triangleFrame = new Rect( 15, 15, 15, 15 );

            var rectangle = new Rectangle( rectangleFrame, fillStyle );
            var ellipse = new Elipse( ellipseFrame, fillStyle );
            var triangle = new Triangle( triangleFrame, triangleFillStyle );

            var group = new GroupShape();
            var triangleGroup = new GroupShape();

            triangleGroup.InsertShape( triangle, 0 );
            group.InsertShape( ellipse, 0 );
            group.InsertShape( rectangle, 0 );
            group.InsertShape( triangleGroup, 0 );

            var groupFillStyle = group.GetFillStyle();
            Assert.IsTrue( groupFillStyle.IsEnabled() );

            group.RemoveShapeAtIndex( 0 );
            Assert.IsTrue( groupFillStyle.IsEnabled() );
        }

        [TestMethod]
        public void IsEnabledTestAfterAddingShapeWithDifferentValueIsEnabled()
        {
            var fillStyle = new Style( Color.Green, true );
            var triangleFillStyle = new Style( Color.Green, false );
            var rectangleFrame = new Rect( 10, 10, 10, 10 );
            var ellipseFrame = new Rect( 12, 12, 12, 12 );
            var triangleFrame = new Rect( 15, 15, 15, 15 );

            var rectangle = new Rectangle( rectangleFrame, fillStyle );
            var ellipse = new Elipse( ellipseFrame, fillStyle );
            var triangle = new Triangle( triangleFrame, triangleFillStyle );

            var group = new GroupShape();
            var triangleGroup = new GroupShape();

            triangleGroup.InsertShape( triangle, 0 );
            group.InsertShape( ellipse, 0 );
            group.InsertShape( rectangle, 0 );

            var groupFillStyle = group.GetFillStyle();
            Assert.IsTrue( groupFillStyle.IsEnabled() );

            group.InsertShape( triangleGroup, 0 );
            Assert.IsFalse( groupFillStyle.IsEnabled() );
        }

        [TestMethod]
        public void IsEnabledTestAfterAddingShapeWithSameValueIsEnabled()
        {
            var fillStyle = new Style( Color.Green, true );
            var triangleFillStyle = new Style( Color.Green, true );
            var rectangleFrame = new Rect( 10, 10, 10, 10 );
            var ellipseFrame = new Rect( 12, 12, 12, 12 );
            var triangleFrame = new Rect( 15, 15, 15, 15 );

            var rectangle = new Rectangle( rectangleFrame, fillStyle );
            var ellipse = new Elipse( ellipseFrame, fillStyle );
            var triangle = new Triangle( triangleFrame, triangleFillStyle );

            var group = new GroupShape();
            var triangleGroup = new GroupShape();

            triangleGroup.InsertShape( triangle, 0 );
            group.InsertShape( ellipse, 0 );
            group.InsertShape( rectangle, 0 );

            var groupFillStyle = group.GetFillStyle();
            Assert.IsTrue( groupFillStyle.IsEnabled() );

            group.InsertShape( triangleGroup, 0 );
            Assert.IsTrue( groupFillStyle.IsEnabled() );
        }

        [TestMethod]
        public void IsEnabledTestFromGroupWithEmptyGroups()
        {
            var group = new GroupShape();
            var emptyGroupOne = new GroupShape();
            var emptyGroupTwo = new GroupShape();

            group.InsertShape( emptyGroupOne, 0 );
            group.InsertShape( emptyGroupTwo, 0 );

            Assert.IsFalse( group.GetFillStyle().IsEnabled() );
            Assert.IsFalse( emptyGroupOne.GetFillStyle().IsEnabled() );
        }

        [TestMethod]
        public void IsEnabledTestFromGroupWithEmptyGroupsAndShapes()
        {
            var fillStyle = new Style( Color.Green, true );
            var rectangleFrame = new Rect( 10, 10, 10, 10 );
            var ellipseFrame = new Rect( 12, 12, 12, 12 );
            var triangleFrame = new Rect( 15, 15, 15, 15 );

            var rectangle = new Rectangle( rectangleFrame, fillStyle );
            var ellipse = new Elipse( ellipseFrame, fillStyle );
            var triangle = new Triangle( triangleFrame, fillStyle );

            var group = new GroupShape();
            var emptyGroup = new GroupShape();

            group.InsertShape( ellipse, 0 );
            group.InsertShape( rectangle, 0 );
            group.InsertShape( triangle, 0 );
            group.InsertShape( emptyGroup, 0 );

            Assert.IsFalse( group.GetFillStyle().IsEnabled() );
        }

        [TestMethod]
        public void EnableTestWithEmptyGroup()
        {
            var group = new GroupShape();
            var fillStyle = group.GetFillStyle();

            fillStyle.Enable( true );
            Assert.IsFalse( fillStyle.IsEnabled() );
        }

        [TestMethod]
        public void EnableTestColorWithGroupWithShapeWithSameIsEnabledValue()
        {
            var fillStyle = new Style( Color.Green, true );
            var rectangleFrame = new Rect( 10, 10, 10, 10 );
            var ellipseFrame = new Rect( 12, 12, 12, 12 );
            var triangleFrame = new Rect( 15, 15, 15, 15 );

            var rectangle = new Rectangle( rectangleFrame, fillStyle );
            var ellipse = new Elipse( ellipseFrame, fillStyle );
            var triangle = new Triangle( triangleFrame, fillStyle );

            var group = new GroupShape();
            var triangleGroup = new GroupShape();

            triangleGroup.InsertShape( triangle, 0 );
            group.InsertShape( ellipse, 0 );
            group.InsertShape( rectangle, 0 );

            var groupFillStyle = group.GetFillStyle();
            Assert.IsTrue( groupFillStyle.IsEnabled() );
            Assert.IsTrue( triangle.GetFillStyle().IsEnabled() );
            Assert.IsTrue( rectangle.GetFillStyle().IsEnabled() );
            Assert.IsTrue( ellipse.GetFillStyle().IsEnabled() );

            groupFillStyle.Enable( false );
            Assert.IsFalse( groupFillStyle.IsEnabled() );
            Assert.IsFalse( triangle.GetFillStyle().IsEnabled() );
            Assert.IsFalse( rectangle.GetFillStyle().IsEnabled() );
            Assert.IsFalse( ellipse.GetFillStyle().IsEnabled() );
        }

        [TestMethod]
        public void EnableTestColorWithGroupWithShapeWithDifferentIsEnabledValue()
        {
            var fillStyle = new Style( Color.Green, true );
            var triangleFillStyle = new Style( Color.Green, false );
            var rectangleFrame = new Rect( 10, 10, 10, 10 );
            var ellipseFrame = new Rect( 12, 12, 12, 12 );
            var triangleFrame = new Rect( 15, 15, 15, 15 );

            var rectangle = new Rectangle( rectangleFrame, fillStyle );
            var ellipse = new Elipse( ellipseFrame, fillStyle );
            var triangle = new Triangle( triangleFrame, triangleFillStyle );

            var group = new GroupShape();
            var triangleGroup = new GroupShape();
            var groupFillStyle = group.GetFillStyle();

            triangleGroup.InsertShape( triangle, 0 );
            group.InsertShape( ellipse, 0 );
            group.InsertShape( rectangle, 0 );
            group.InsertShape( triangleGroup, 0 );

            Assert.IsFalse( groupFillStyle.IsEnabled() );
            Assert.IsFalse( triangle.GetFillStyle().IsEnabled() );
            Assert.IsTrue( rectangle.GetFillStyle().IsEnabled() );
            Assert.IsTrue( ellipse.GetFillStyle().IsEnabled() );

            groupFillStyle.Enable( true );
            Assert.IsTrue( groupFillStyle.IsEnabled() );
            Assert.IsTrue( triangle.GetFillStyle().IsEnabled() );
            Assert.IsTrue( rectangle.GetFillStyle().IsEnabled() );
            Assert.IsTrue( ellipse.GetFillStyle().IsEnabled() );
        }

        [TestMethod]
        public void EnableTestColorWithGroupWithEmptyGroupsAndShapes()
        {
            var fillStyle = new Style( Color.Green, true );
            var rectangleFrame = new Rect( 10, 10, 10, 10 );
            var ellipseFrame = new Rect( 12, 12, 12, 12 );
            var triangleFrame = new Rect( 15, 15, 15, 15 );

            var rectangle = new Rectangle( rectangleFrame, fillStyle );
            var ellipse = new Elipse( ellipseFrame, fillStyle );
            var triangle = new Triangle( triangleFrame, fillStyle );

            var group = new GroupShape();
            var emptyGroup = new GroupShape();
            var groupFillStyle = group.GetFillStyle();

            group.InsertShape( ellipse, 0 );
            group.InsertShape( rectangle, 0 );
            group.InsertShape( triangle, 0 );
            group.InsertShape( emptyGroup, 0 );

            Assert.IsFalse( groupFillStyle.IsEnabled() );
            Assert.IsTrue( triangle.GetFillStyle().IsEnabled() );
            Assert.IsTrue( rectangle.GetFillStyle().IsEnabled() );
            Assert.IsTrue( ellipse.GetFillStyle().IsEnabled() );
            Assert.IsFalse( emptyGroup.GetFillStyle().IsEnabled() );

            groupFillStyle.Enable( true );
            Assert.IsFalse( groupFillStyle.IsEnabled() );
            Assert.IsTrue( triangle.GetFillStyle().IsEnabled() );
            Assert.IsTrue( rectangle.GetFillStyle().IsEnabled() );
            Assert.IsTrue( ellipse.GetFillStyle().IsEnabled() );
            Assert.IsFalse( emptyGroup.GetFillStyle().IsEnabled() );
        }
    }
}
