using System;
using Composite.Groups;
using Composite.Shape;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rectangle = Composite.Shape.Rectangle;

namespace CompositeTest
{
    [TestClass]
    public class GroupShapeTest
    {
       //Frame tests

        [TestMethod]
        public void GetFrameFromGroupWithoutShapes()
        {
            var group = new GroupShape();

            Assert.AreEqual( null, group.GetFrame() );
        }

        [TestMethod]
        public void GetFrameFromGroupWithOneShape()
        {
            var rectangleFrame = new Rect( 200, 200, 200, 150 );
            var rectangle = new Rectangle( rectangleFrame, null, null );
            var group = new GroupShape();

            group.InsertShape( rectangle, 0 );

            Assert.IsTrue( IsEqualFrame( rectangleFrame, group.GetFrame().Value ) );
        }

        [TestMethod]
        public void GetFrameFromGroupWithShapes()
        {
            var rectangleFrame = new Rect( 200, 200, 200, 150 );
            var ellipseFrame = new Rect( 450, 100, 100, 100 );
            var triangleFrame = new Rect( 100, 100, 250, 100 );
            var resultFrame = new Rect( 100, 450, 100, 250 );

            var rectangle = new Rectangle( rectangleFrame, null, null );
            var ellipse = new Elipse( ellipseFrame, null, null );
            var triangle = new Triangle( triangleFrame, null, null );

            var group = new GroupShape();
            var triangleGroup = new GroupShape();

            triangleGroup.InsertShape( triangle, 0 );
            group.InsertShape( rectangle, 0 );
            group.InsertShape( ellipse, 0 );
            group.InsertShape( triangleGroup, 0 );

            Assert.IsTrue( IsEqualFrame( resultFrame, group.GetFrame().Value ) );
            Assert.IsTrue( IsEqualFrame( triangleFrame, triangleGroup.GetFrame().Value ) );
        }

        [TestMethod]
        public void GetFrameFromGroupWithShapesWithNegativeLeftTop()
        {
            var rectangleFrame = new Rect( 0, 200, 0, 150 );
            var ellipseFrame = new Rect( 250, 100, -100, 100 );
            var triangleFrame = new Rect( -100, 100, 50, 100 );
            var resultFrame = new Rect( -100, 450, -100, 250 );

            var rectangle = new Rectangle( rectangleFrame, null, null );
            var ellipse = new Elipse( ellipseFrame, null, null );
            var triangle = new Triangle( triangleFrame, null, null );

            var group = new GroupShape();
            var triangleGroup = new GroupShape();

            triangleGroup.InsertShape( triangle, 0 );
            group.InsertShape( rectangle, 0 );
            group.InsertShape( ellipse, 0 );
            group.InsertShape( triangleGroup, 0 );

            Assert.IsTrue( IsEqualFrame( resultFrame, group.GetFrame().Value ) );
            Assert.IsTrue( IsEqualFrame( triangleFrame, triangleGroup.GetFrame().Value ) );
        }

        [TestMethod]
        public void GetFrameFromGroupWithEmptyGroups()
        {
            var group = new GroupShape();
            var emptyGroupOne = new GroupShape();
            var emptyGroupTwo = new GroupShape();

            group.InsertShape( emptyGroupOne, 0 );
            group.InsertShape( emptyGroupTwo, 0 );

            Assert.IsNull( group.GetFrame() );
        }

        [TestMethod]
        public void GetFrameFromGroupWithShapesAndOneEmptyGroup()
        {
            var rectangleFrame = new Rect( 0, 200, 0, 150 );
            var ellipseFrame = new Rect( 250, 100, -100, 100 );
            var resultFrame = new Rect( 0, 350, -100, 250 );

            var rectangle = new Rectangle( rectangleFrame, null, null );
            var ellipse = new Elipse( ellipseFrame, null, null );

            var group = new GroupShape();
            var emptyGroup = new GroupShape();

            group.InsertShape( rectangle, 0 );
            group.InsertShape( ellipse, 0 );
            group.InsertShape( emptyGroup, 0 );

            Assert.IsTrue( IsEqualFrame( resultFrame, group.GetFrame().Value ) );
            Assert.IsNull( emptyGroup.GetFrame() );
        }

        [TestMethod]
        public void GetFrameFromGroupWithShapesAfterRemovingShapeFromGroupWithOneShape()
        {
            var rectangleFrame = new Rect( 0, 200, 0, 150 );
            var ellipseFrame = new Rect( 250, 100, -100, 100 );
            var triangleFrame = new Rect( -100, 100, 50, 100 );
            var resultFrame = new Rect( -100, 450, -100, 250 );
            var resultFrameAfterRemoving = new Rect( 0, 350, -100, 250 );

            var rectangle = new Rectangle( rectangleFrame, null, null );
            var ellipse = new Elipse( ellipseFrame, null, null );
            var triangle = new Triangle( triangleFrame );

            var group = new GroupShape();
            var triangleGroup = new GroupShape();

            group.InsertShape( rectangle, 0 );
            group.InsertShape( ellipse, 0 );
            group.InsertShape( triangleGroup, 0 );
            triangleGroup.InsertShape( triangle, 0 );

            Assert.IsTrue( IsEqualFrame( resultFrame, group.GetFrame().Value ) );
            Assert.IsTrue( IsEqualFrame( triangleFrame, triangle.GetFrame().Value ) );

            triangleGroup.RemoveShapeAtIndex( 0 );

            Assert.IsTrue( IsEqualFrame( resultFrameAfterRemoving, group.GetFrame().Value ) );
            Assert.IsNull( triangleGroup.GetFrame() );
        }

        [TestMethod]
        public void GetFrameFromGroupWithShapesAfterAddingEmptyGroup()
        {
            var rectangleFrame = new Rect( 0, 200, 0, 150 );
            var ellipseFrame = new Rect( 250, 100, -100, 100 );
            var resultFrame = new Rect( 0, 350, -100, 250 );

            var rectangle = new Rectangle( rectangleFrame, null, null );
            var ellipse = new Elipse( ellipseFrame, null, null );

            var group = new GroupShape();
            var emptyGroup = new GroupShape();

            group.InsertShape( rectangle, 0 );
            group.InsertShape( ellipse, 0 );

            Assert.IsTrue( IsEqualFrame( resultFrame, group.GetFrame().Value ) );

            group.InsertShape( emptyGroup, 0 );

            Assert.IsTrue( IsEqualFrame( resultFrame, group.GetFrame().Value ) );
            Assert.IsNull( emptyGroup.GetFrame() );
        }

        [TestMethod]
        public void SetFrameToGroupWithoutShapes()
        {
            var group = new GroupShape();
            var frame = new Rect( -100, 450, -100, 250 );

            group.SetFrame( frame );

            Assert.AreEqual( null, group.GetFrame() );
        }

        [TestMethod]
        public void SetNewFrameWithDoubleBiggerWidthAndHeightToGroupWithShapes()
        {
            var rectangleFrame = new Rect( 200, 200, 200, 150 );
            var ellipseFrame = new Rect( 450, 100, 100, 100 );
            var triangleFrame = new Rect( 100, 100, 250, 100 );
            var groupFrame = new Rect( 100, 450, 100, 250 );

            var newRectangleFrame = new Rect( 300, 400, 300, 300 );
            var newEllipseFrame = new Rect( 800, 200, 100, 200 );
            var newTriangleFrame = new Rect( 100, 200, 400, 200 );
            var newGroupFrame = new Rect( 100, 900, 100, 500 );

            var rectangle = new Rectangle( rectangleFrame, null, null );
            var ellipse = new Elipse( ellipseFrame, null, null );
            var triangle = new Triangle( triangleFrame, null, null );

            var group = new GroupShape();
            var triangleGroup = new GroupShape();

            triangleGroup.InsertShape( triangle, 0 );
            group.InsertShape( rectangle, 0 );
            group.InsertShape( ellipse, 0 );
            group.InsertShape( triangleGroup, 0 );

            Assert.IsTrue( IsEqualFrame( rectangleFrame, rectangle.GetFrame().Value ) );
            Assert.IsTrue( IsEqualFrame( triangleFrame, triangle.GetFrame().Value ) );
            Assert.IsTrue( IsEqualFrame( ellipseFrame, ellipse.GetFrame().Value ) );
            Assert.IsTrue( IsEqualFrame( groupFrame, group.GetFrame().Value ) );

            group.SetFrame( newGroupFrame );

            Assert.IsTrue( IsEqualFrame( newRectangleFrame, rectangle.GetFrame().Value ) );
            Assert.IsTrue( IsEqualFrame( newTriangleFrame, triangle.GetFrame().Value ) );
            Assert.IsTrue( IsEqualFrame( newEllipseFrame, ellipse.GetFrame().Value ) );
            Assert.IsTrue( IsEqualFrame( newGroupFrame, group.GetFrame().Value ) );
        }

        [TestMethod]
        public void SetFrameWithDoubleSmallerWidthAndHeightAndNegativeLeftTopToGroupWithShapes()
        {
            var rectangleFrame = new Rect( 200, 200, 200, 150 );
            var ellipseFrame = new Rect( 450, 100, 100, 100 );
            var triangleFrame = new Rect( 100, 100, 250, 100 );
            var groupFrame = new Rect( 100, 450, 100, 250 );

            var newRectangleFrame = new Rect( -50, 100, -50, 75 );
            var newEllipseFrame = new Rect( 75, 50, -100, 50 );
            var newTriangleFrame = new Rect( -100, 50, -25, 50 );
            var newGroupFrame = new Rect( -100, 225, -100, 125 );

            var rectangle = new Rectangle( rectangleFrame, null, null );
            var ellipse = new Elipse( ellipseFrame, null, null );
            var triangle = new Triangle( triangleFrame, null, null );

            var group = new GroupShape();
            var triangleGroup = new GroupShape();

            triangleGroup.InsertShape( triangle, 0 );
            group.InsertShape( rectangle, 0 );
            group.InsertShape( ellipse, 0 );
            group.InsertShape( triangleGroup, 0 );

            Assert.IsTrue( IsEqualFrame( rectangleFrame, rectangle.GetFrame().Value ) );
            Assert.IsTrue( IsEqualFrame( triangleFrame, triangle.GetFrame().Value ) );
            Assert.IsTrue( IsEqualFrame( ellipseFrame, ellipse.GetFrame().Value ) );
            Assert.IsTrue( IsEqualFrame( groupFrame, group.GetFrame().Value ) );

            group.SetFrame( newGroupFrame );

            Assert.IsTrue( IsEqualFrame( newRectangleFrame, rectangle.GetFrame().Value ) );
            Assert.IsTrue( IsEqualFrame( newTriangleFrame, triangle.GetFrame().Value ) );
            Assert.IsTrue( IsEqualFrame( newEllipseFrame, ellipse.GetFrame().Value ) );
            Assert.IsTrue( IsEqualFrame( newGroupFrame, group.GetFrame().Value ) );
        }

        [TestMethod]
        public void SetFrameWithNegativeHeightWidth()
        {
            var group = new GroupShape();
            var frame = new Rect( 100, -450, 100, -250 );

            Assert.ThrowsException<ArgumentException>( () => group.SetFrame( frame ) );
        }

        [TestMethod]
        public void SetFrameWithZeroHeightWidth()
        {
            var group = new GroupShape();
            var frame = new Rect( 100, 0, 100, 0 );

            Assert.ThrowsException<ArgumentException>( () => group.SetFrame( frame ) );
        }

        [TestMethod]
        public void SetFrameToGroupWithEmptyGroups()
        {
            var group = new GroupShape();
            var emptyGroupOne = new GroupShape();
            var emptyGroupTwo = new GroupShape();

            group.InsertShape( emptyGroupOne, 0 );
            group.InsertShape( emptyGroupTwo, 0 );
            group.SetFrame( new Rect( 10, 10, 10, 10 ) );

            Assert.IsNull( group.GetFrame() );
        }

        [TestMethod]
        public void SetFrameToGroupWithShapesAndEmptyGroup()
        {
            var rectangleFrame = new Rect( 0, 200, 0, 150 );
            var ellipseFrame = new Rect( 250, 100, -100, 100 );
            var resultFrame = new Rect( 0, 350, -100, 250 );

            var rectangle = new Rectangle( rectangleFrame, null, null );
            var ellipse = new Elipse( ellipseFrame, null, null );

            var group = new GroupShape();
            var emptyGroup = new GroupShape();

            group.InsertShape( rectangle, 0 );
            group.InsertShape( ellipse, 0 );
            group.InsertShape( emptyGroup, 0 );

            Assert.IsTrue( IsEqualFrame( resultFrame, group.GetFrame().Value ) );

            group.SetFrame( new Rect(0, 700, 0, 125) );

            Assert.IsTrue( IsEqualFrame( new Rect( 0, 700, 0, 125 ), group.GetFrame().Value ) );
        }

        [TestMethod]
        public void InsertShape()
        {
            var rectangleFrame = new Rect( 200, 200, 200, 150 );
            var ellipseFrame = new Rect( 450, 100, 100, 100 );
            var triangleFrame = new Rect( 100, 100, 250, 100 );

            var rectangle = new Rectangle( rectangleFrame, null, null );
            var ellipse = new Elipse( ellipseFrame, null, null );
            var triangle = new Triangle( triangleFrame, null, null );
            var group = new GroupShape();

            group.InsertShape( rectangle, 0 );
            Assert.AreEqual( 1, group.GetShapesCount() );
            Assert.ThrowsException<IndexOutOfRangeException>( () => group.InsertShape( triangle, -1 ) );
            Assert.ThrowsException<IndexOutOfRangeException>( () => group.InsertShape( ellipse, 2 ) );
            group.InsertShape( ellipse, 1 );
            Assert.AreEqual( 2, group.GetShapesCount() );
        }

        private bool IsEqualFrame( Rect frameOne, Rect frameTwo )
        {
            return frameOne.height == frameTwo.height
                && frameOne.left == frameTwo.left
                && frameOne.top == frameTwo.top
                && frameOne.width == frameTwo.width;
        }
    }
}
