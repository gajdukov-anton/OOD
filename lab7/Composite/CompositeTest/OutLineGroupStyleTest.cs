using System.Drawing;
using Composite.Groups;
using Composite.Shape;
using Composite.Style;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rectangle = Composite.Shape.Rectangle;
using Style = Composite.Style.Style;

namespace CompositeTest
{
    [TestClass]
    public class OutLineGroupStyleTest
    {
        [TestMethod]
        public void GetColorFromGroupWithoutShapes()
        {
            var group = new GroupShape();
            var outLineStyle = group.GetOutlineStyle();
            Assert.AreEqual( outLineStyle.GetColor(), Color.Empty );
        }

        [TestMethod]
        public void GetColorFromGroupWithShapesWithSameColor()
        {
            var outLineStyle = new OutLineStyle( Color.Blue, true, 10 );
            var rectangleFrame = new Rect( 10, 10, 10, 10 );
            var ellipseFrame = new Rect( 12, 12, 12, 12 );
            var triangleFrame = new Rect( 15, 15, 15, 15 );

            var rectangle = new Rectangle( rectangleFrame, null, outLineStyle );
            var ellipse = new Elipse( ellipseFrame, null, outLineStyle );
            var triangle = new Triangle( triangleFrame, null, outLineStyle );

            var group = new GroupShape();
            var triangleGroup = new GroupShape();

            triangleGroup.InsertShape( triangle, 0 );
            group.InsertShape( ellipse, 0 );
            group.InsertShape( triangleGroup, 0 );
            group.InsertShape( rectangle, 0 );

            var groupOutLineStyle = group.GetOutlineStyle();
            Assert.AreEqual( groupOutLineStyle.GetColor(), Color.Blue );
        }

        [TestMethod]
        public void GetColorFromGroupWithShapesWithDifferentColor()
        {
            var outLineStyle = new OutLineStyle( Color.Blue, true, 10 );
            var triangleOutLineStyle = new OutLineStyle( Color.YellowGreen, true, 10 );
            var rectangleFrame = new Rect( 10, 10, 10, 10 );
            var ellipseFrame = new Rect( 12, 12, 12, 12 );
            var triangleFrame = new Rect( 15, 15, 15, 15 );

            var rectangle = new Rectangle( rectangleFrame, null, outLineStyle );
            var ellipse = new Elipse( ellipseFrame, null, outLineStyle );
            var triangle = new Triangle( triangleFrame, null, triangleOutLineStyle );

            var group = new GroupShape();
            var triangleGroup = new GroupShape();

            triangleGroup.InsertShape( triangle, 0 );
            group.InsertShape( ellipse, 0 );
            group.InsertShape( triangleGroup, 0 );
            group.InsertShape( rectangle, 0 );

            var groupOutLineStyle = group.GetOutlineStyle();
            Assert.AreEqual( groupOutLineStyle.GetColor(), Color.Empty );
        }

        [TestMethod]
        public void GetColorAfterRemovingShapeWithDifferentColor()
        {
            var outLineStyle = new OutLineStyle( Color.Blue, true, 10 );
            var triangleOutLineStyle = new OutLineStyle( Color.YellowGreen, true, 10 );
            var rectangleFrame = new Rect( 10, 10, 10, 10 );
            var ellipseFrame = new Rect( 12, 12, 12, 12 );
            var triangleFrame = new Rect( 15, 15, 15, 15 );

            var rectangle = new Rectangle( rectangleFrame, null, outLineStyle );
            var ellipse = new Elipse( ellipseFrame, null, outLineStyle );
            var triangle = new Triangle( triangleFrame, null, triangleOutLineStyle );

            var group = new GroupShape();
            var triangleGroup = new GroupShape();

            triangleGroup.InsertShape( triangle, 0 );
            group.InsertShape( ellipse, 0 );
            group.InsertShape( rectangle, 0 );
            group.InsertShape( triangleGroup, 0 );

            var groupOutLineStyle = group.GetOutlineStyle();
            Assert.AreEqual( groupOutLineStyle.GetColor(), Color.Empty );

            group.RemoveShapeAtIndex( 0 );        
            Assert.AreEqual( Color.Blue, groupOutLineStyle.GetColor() );
        }

        [TestMethod]
        public void GetColorAfterRemovingShapeWitSameColor()
        {
            var outLineStyle = new OutLineStyle( Color.Blue, true, 10 );
            var triangleOutLineStyle = new OutLineStyle( Color.Blue, true, 10 );
            var rectangleFrame = new Rect( 10, 10, 10, 10 );
            var ellipseFrame = new Rect( 12, 12, 12, 12 );
            var triangleFrame = new Rect( 15, 15, 15, 15 );

            var rectangle = new Rectangle( rectangleFrame, null, outLineStyle );
            var ellipse = new Elipse( ellipseFrame, null, outLineStyle );
            var triangle = new Triangle( triangleFrame, null, triangleOutLineStyle );

            var group = new GroupShape();
            var triangleGroup = new GroupShape();

            triangleGroup.InsertShape( triangle, 0 );
            group.InsertShape( ellipse, 0 );
            group.InsertShape( rectangle, 0 );
            group.InsertShape( triangleGroup, 0 );

            var groupOutLineStyle = group.GetOutlineStyle();
            Assert.AreEqual( groupOutLineStyle.GetColor(), Color.Blue );

            group.RemoveShapeAtIndex( 0 );
            Assert.AreEqual( Color.Blue, groupOutLineStyle.GetColor() );
        }

        [TestMethod]
        public void GetColorAfterAddingShapeWithDifferentColor()
        {
            var outLineStyle = new OutLineStyle( Color.Blue, true, 10 );
            var triangleOutLineStyle = new OutLineStyle( Color.YellowGreen, true, 10 );
            var rectangleFrame = new Rect( 10, 10, 10, 10 );
            var ellipseFrame = new Rect( 12, 12, 12, 12 );
            var triangleFrame = new Rect( 15, 15, 15, 15 );

            var rectangle = new Rectangle( rectangleFrame, null, outLineStyle );
            var ellipse = new Elipse( ellipseFrame, null, outLineStyle );
            var triangle = new Triangle( triangleFrame, null, triangleOutLineStyle );

            var group = new GroupShape();
            var triangleGroup = new GroupShape();

            triangleGroup.InsertShape( triangle, 0 );
            group.InsertShape( ellipse, 0 );
            group.InsertShape( rectangle, 0 );

            var groupOutLineStyle = group.GetOutlineStyle();
            Assert.AreEqual( Color.Blue, groupOutLineStyle.GetColor() );

            group.InsertShape( triangleGroup, 0 );
            Assert.AreEqual( Color.Empty, groupOutLineStyle.GetColor() );
        }

        [TestMethod]
        public void GetColorAfterAddingShapeWithSameColor()
        {
            var outLineStyle = new OutLineStyle( Color.Blue, true, 10 );
            var triangleOutLineStyle = new OutLineStyle( Color.Blue, true, 10 );
            var rectangleFrame = new Rect( 10, 10, 10, 10 );
            var ellipseFrame = new Rect( 12, 12, 12, 12 );
            var triangleFrame = new Rect( 15, 15, 15, 15 );

            var rectangle = new Rectangle( rectangleFrame, null, outLineStyle );
            var ellipse = new Elipse( ellipseFrame, null, outLineStyle );
            var triangle = new Triangle( triangleFrame, null, triangleOutLineStyle );

            var group = new GroupShape();
            var triangleGroup = new GroupShape();

            triangleGroup.InsertShape( triangle, 0 );
            group.InsertShape( ellipse, 0 );
            group.InsertShape( rectangle, 0 );

            var groupOutLineStyle = group.GetOutlineStyle();
            Assert.AreEqual( Color.Blue, groupOutLineStyle.GetColor() );

            group.InsertShape( triangleGroup, 0 );
            Assert.AreEqual( Color.Blue, groupOutLineStyle.GetColor() );
        }

        [TestMethod]
        public void GetColorFromGroupWithEmptyGroups()
        {
            var group = new GroupShape();
            var emptyGroupOne = new GroupShape();
            var emptyGroupTwo = new GroupShape();

            group.InsertShape( emptyGroupOne, 0 );
            group.InsertShape( emptyGroupTwo, 0 );

            Assert.AreEqual( Color.Empty, group.GetOutlineStyle().GetColor() );
            Assert.AreEqual( Color.Empty, emptyGroupOne.GetOutlineStyle().GetColor() );
        }

        [TestMethod]
        public void GetColorFromGroupWithEmptyGroupsAndShapes()
        {
            var outLineStyle = new OutLineStyle( Color.Blue, true, 10 );
            var rectangleFrame = new Rect( 10, 10, 10, 10 );
            var ellipseFrame = new Rect( 12, 12, 12, 12 );
            var triangleFrame = new Rect( 15, 15, 15, 15 );

            var rectangle = new Rectangle( rectangleFrame, null, outLineStyle );
            var ellipse = new Elipse( ellipseFrame, null, outLineStyle );
            var triangle = new Triangle( triangleFrame, null, outLineStyle );

            var group = new GroupShape();
            var emptyGroup = new GroupShape();

            group.InsertShape( ellipse, 0 );
            group.InsertShape( rectangle, 0 );
            group.InsertShape( triangle, 0 );
            group.InsertShape( emptyGroup, 0 );

            Assert.AreEqual( Color.Empty, group.GetOutlineStyle().GetColor() );
        }

        [TestMethod]
        public void SetColorWithEmptyGroup()
        {
            var group = new GroupShape();
            var outLineStyle = group.GetOutlineStyle();

            outLineStyle.SetColor( Color.Beige );
            Assert.AreEqual( outLineStyle.GetColor(), Color.Empty );
        }

        [TestMethod]
        public void SetColorWithGroupWithShapeWithSameColor()
        {
            var outLineStyle = new OutLineStyle( Color.Green, true, 10 );
            var rectangleFrame = new Rect( 10, 10, 10, 10 );
            var ellipseFrame = new Rect( 12, 12, 12, 12 );
            var triangleFrame = new Rect( 15, 15, 15, 15 );

            var rectangle = new Rectangle( rectangleFrame,null, outLineStyle );
            var ellipse = new Elipse( ellipseFrame, null, outLineStyle );
            var triangle = new Triangle( triangleFrame,null, outLineStyle );

            var group = new GroupShape();
            var triangleGroup = new GroupShape();

            triangleGroup.InsertShape( triangle, 0 );
            group.InsertShape( ellipse, 0 );
            group.InsertShape( rectangle, 0 );

            var groupOutLineStyle = group.GetOutlineStyle();
            Assert.AreEqual( Color.Green, groupOutLineStyle.GetColor() );
            Assert.AreEqual( Color.Green, triangle.GetOutlineStyle().GetColor() );
            Assert.AreEqual( Color.Green, rectangle.GetOutlineStyle().GetColor() );
            Assert.AreEqual( Color.Green, ellipse.GetOutlineStyle().GetColor() );

            groupOutLineStyle.SetColor( Color.Blue );
            Assert.AreEqual( Color.Blue, triangle.GetOutlineStyle().GetColor() );
            Assert.AreEqual( Color.Blue, rectangle.GetOutlineStyle().GetColor() );
            Assert.AreEqual( Color.Blue, ellipse.GetOutlineStyle().GetColor() );

        }

        [TestMethod]
        public void SetColorWithGroupWithShapeWithDifferentColor()
        {
            var outLineStyle = new OutLineStyle( Color.Green, true, 10 );
            var triangleOutLineStyle = new OutLineStyle( Color.Blue, true, 10 );
            var rectangleFrame = new Rect( 10, 10, 10, 10 );
            var ellipseFrame = new Rect( 12, 12, 12, 12 );
            var triangleFrame = new Rect( 15, 15, 15, 15 );

            var rectangle = new Rectangle( rectangleFrame,null, outLineStyle );
            var ellipse = new Elipse( ellipseFrame,null, outLineStyle );
            var triangle = new Triangle( triangleFrame,null, triangleOutLineStyle );

            var group = new GroupShape();
            var triangleGroup = new GroupShape();
            var groupOutLineStyle = group.GetOutlineStyle();

            triangleGroup.InsertShape( triangle, 0 );
            group.InsertShape( ellipse, 0 );
            group.InsertShape( rectangle, 0 );
            group.InsertShape( triangleGroup, 0 );

            Assert.AreEqual( Color.Empty, groupOutLineStyle.GetColor() );
            Assert.AreEqual( Color.Blue, triangle.GetOutlineStyle().GetColor() );
            Assert.AreEqual( Color.Green, rectangle.GetOutlineStyle().GetColor() );
            Assert.AreEqual( Color.Green, ellipse.GetOutlineStyle().GetColor() );

            groupOutLineStyle.SetColor( Color.Red );
            Assert.AreEqual( Color.Red, groupOutLineStyle.GetColor() );
            Assert.AreEqual( Color.Red, triangle.GetOutlineStyle().GetColor() );
            Assert.AreEqual( Color.Red, rectangle.GetOutlineStyle().GetColor() );
            Assert.AreEqual( Color.Red, ellipse.GetOutlineStyle().GetColor() );
        }

        [TestMethod]
        public void SetColorWithGroupWithEmptyGroupsAndShapes()
        {
            var outLineStyle = new OutLineStyle( Color.Green, true, 10 );
            var rectangleFrame = new Rect( 10, 10, 10, 10 );
            var ellipseFrame = new Rect( 12, 12, 12, 12 );
            var triangleFrame = new Rect( 15, 15, 15, 15 );

            var rectangle = new Rectangle( rectangleFrame, null, outLineStyle );
            var ellipse = new Elipse( ellipseFrame, null, outLineStyle );
            var triangle = new Triangle( triangleFrame, null, outLineStyle );

            var group = new GroupShape();
            var emptyGroup = new GroupShape();
            var groupOutLineStyle = group.GetOutlineStyle();

            group.InsertShape( ellipse, 0 );
            group.InsertShape( rectangle, 0 );
            group.InsertShape( triangle, 0 );
            group.InsertShape( emptyGroup, 0 );

            Assert.AreEqual( Color.Empty, groupOutLineStyle.GetColor() );
            Assert.AreEqual( Color.Green, triangle.GetOutlineStyle().GetColor() );
            Assert.AreEqual( Color.Green, rectangle.GetOutlineStyle().GetColor() );
            Assert.AreEqual( Color.Green, ellipse.GetOutlineStyle().GetColor() );

            groupOutLineStyle.SetColor( Color.Black );
            Assert.AreEqual( Color.Empty, groupOutLineStyle.GetColor() );
            Assert.AreEqual( Color.Black, triangle.GetOutlineStyle().GetColor() );
            Assert.AreEqual( Color.Black, rectangle.GetOutlineStyle().GetColor() );
            Assert.AreEqual( Color.Black, ellipse.GetOutlineStyle().GetColor() );
        }

        [TestMethod]
        public void IsEnabledTestFromGroupWithoutShapes()
        {
            var group = new GroupShape();
            var groupOutLineStyle = group.GetOutlineStyle();
            Assert.IsFalse( groupOutLineStyle.IsEnabled() );
        }

        [TestMethod]
        public void IsEnabledTestForGroupWithShapesWithSameValueIsEnabled()
        {
            var outLineStyle = new OutLineStyle( Color.Blue, true, 10 );
            var rectangleFrame = new Rect( 10, 10, 10, 10 );
            var ellipseFrame = new Rect( 12, 12, 12, 12 );
            var triangleFrame = new Rect( 15, 15, 15, 15 );

            var rectangle = new Rectangle( rectangleFrame, null, outLineStyle );
            var ellipse = new Elipse( ellipseFrame, null, outLineStyle );
            var triangle = new Triangle( triangleFrame, null, outLineStyle );

            var group = new GroupShape();
            var triangleGroup = new GroupShape();

            triangleGroup.InsertShape( triangle, 0 );
            group.InsertShape( ellipse, 0 );
            group.InsertShape( triangleGroup, 0 );
            group.InsertShape( rectangle, 0 );

            var groupOutLineStyle = group.GetOutlineStyle();
            Assert.IsTrue( groupOutLineStyle.IsEnabled() );
        }

        [TestMethod]
        public void IsEnabledTestForGroupWithShapesWithDifferentValueIsEnabled()
        {
            var outLineStyle = new OutLineStyle( Color.Blue, true, 10 );
            var triangleOutLineStyle = new OutLineStyle( Color.Blue, false, 10 );
            var rectangleFrame = new Rect( 10, 10, 10, 10 );
            var ellipseFrame = new Rect( 12, 12, 12, 12 );
            var triangleFrame = new Rect( 15, 15, 15, 15 );

            var rectangle = new Rectangle( rectangleFrame, null, outLineStyle );
            var ellipse = new Elipse( ellipseFrame, null, outLineStyle );
            var triangle = new Triangle( triangleFrame, null, triangleOutLineStyle );

            var group = new GroupShape();
            var triangleGroup = new GroupShape();

            triangleGroup.InsertShape( triangle, 0 );
            group.InsertShape( ellipse, 0 );
            group.InsertShape( triangleGroup, 0 );
            group.InsertShape( rectangle, 0 );

            var groupOutLineStyle = group.GetOutlineStyle();
            Assert.IsFalse( groupOutLineStyle.IsEnabled() );
        }

        [TestMethod]
        public void IsEnabledTestForGroupAfterRemovingShapeWithDifferentValueIsEnabled()
        {
            var outLineStyle = new OutLineStyle( Color.Blue, true, 10 );
            var triangleOutLineStyle = new OutLineStyle( Color.Blue, false, 10 );
            var rectangleFrame = new Rect( 10, 10, 10, 10 );
            var ellipseFrame = new Rect( 12, 12, 12, 12 );
            var triangleFrame = new Rect( 15, 15, 15, 15 );

            var rectangle = new Rectangle( rectangleFrame, null, outLineStyle );
            var ellipse = new Elipse( ellipseFrame, null, outLineStyle );
            var triangle = new Triangle( triangleFrame, null, triangleOutLineStyle );

            var group = new GroupShape();
            var triangleGroup = new GroupShape();

            triangleGroup.InsertShape( triangle, 0 );
            group.InsertShape( ellipse, 0 );
            group.InsertShape( rectangle, 0 );
            group.InsertShape( triangleGroup, 0 );

            var groupOutLineStyle = group.GetOutlineStyle();
            Assert.IsFalse( groupOutLineStyle.IsEnabled() );

            group.RemoveShapeAtIndex( 0 );
            Assert.IsTrue( groupOutLineStyle.IsEnabled() );
        }

        [TestMethod]
        public void IsEnabledTestForGroupAfterRemovingShapeWithSameValueIsEnabled()
        {
            var outLineStyle = new OutLineStyle( Color.Blue, true, 10 );
            var triangleOutLineStyle = new OutLineStyle( Color.Blue, true, 10 );
            var rectangleFrame = new Rect( 10, 10, 10, 10 );
            var ellipseFrame = new Rect( 12, 12, 12, 12 );
            var triangleFrame = new Rect( 15, 15, 15, 15 );

            var rectangle = new Rectangle( rectangleFrame, null, outLineStyle );
            var ellipse = new Elipse( ellipseFrame, null, outLineStyle );
            var triangle = new Triangle( triangleFrame, null, triangleOutLineStyle );

            var group = new GroupShape();
            var triangleGroup = new GroupShape();

            triangleGroup.InsertShape( triangle, 0 );
            group.InsertShape( ellipse, 0 );
            group.InsertShape( rectangle, 0 );
            group.InsertShape( triangleGroup, 0 );

            var groupOutLineStyle = group.GetOutlineStyle();
            Assert.IsTrue( groupOutLineStyle.IsEnabled() );

            group.RemoveShapeAtIndex( 0 );
            Assert.IsTrue( groupOutLineStyle.IsEnabled() );
        }

        [TestMethod]
        public void IsEnabledTestAfterAddingShapeWithDifferentValueIsEnabled()
        {
            var outLineStyle = new OutLineStyle( Color.Blue, true, 10 );
            var triangleOutLineStyle = new OutLineStyle( Color.Blue, false, 10 );
            var rectangleFrame = new Rect( 10, 10, 10, 10 );
            var ellipseFrame = new Rect( 12, 12, 12, 12 );
            var triangleFrame = new Rect( 15, 15, 15, 15 );

            var rectangle = new Rectangle( rectangleFrame, null, outLineStyle );
            var ellipse = new Elipse( ellipseFrame, null, outLineStyle );
            var triangle = new Triangle( triangleFrame, null, triangleOutLineStyle );

            var group = new GroupShape();
            var triangleGroup = new GroupShape();

            triangleGroup.InsertShape( triangle, 0 );
            group.InsertShape( ellipse, 0 );
            group.InsertShape( rectangle, 0 );

            var groupOutLineStyle = group.GetOutlineStyle();
            Assert.IsTrue( groupOutLineStyle.IsEnabled() );

            group.InsertShape( triangleGroup, 0 );
            Assert.IsFalse( groupOutLineStyle.IsEnabled() );
        }

        [TestMethod]
        public void IsEnabledTestAfterAddingShapeWithSameValueIsEnabled()
        {
            var outLineStyle = new OutLineStyle( Color.Blue, true, 10 );
            var triangleOutLineStyle = new OutLineStyle( Color.Blue, true, 10 );
            var rectangleFrame = new Rect( 10, 10, 10, 10 );
            var ellipseFrame = new Rect( 12, 12, 12, 12 );
            var triangleFrame = new Rect( 15, 15, 15, 15 );

            var rectangle = new Rectangle( rectangleFrame, null, outLineStyle );
            var ellipse = new Elipse( ellipseFrame, null, outLineStyle );
            var triangle = new Triangle( triangleFrame, null, triangleOutLineStyle );

            var group = new GroupShape();
            var triangleGroup = new GroupShape();

            triangleGroup.InsertShape( triangle, 0 );
            group.InsertShape( ellipse, 0 );
            group.InsertShape( rectangle, 0 );

            var groupOutLineStyle = group.GetOutlineStyle();
            Assert.IsTrue( groupOutLineStyle.IsEnabled() );

            group.InsertShape( triangleGroup, 0 );
            Assert.IsTrue( groupOutLineStyle.IsEnabled() );
        }

        [TestMethod]
        public void IsEnabledTestFromGroupWithEmptyGroups()
        {
            var group = new GroupShape();
            var emptyGroupOne = new GroupShape();
            var emptyGroupTwo = new GroupShape();
            var groupOutLineStyle = group.GetOutlineStyle();

            group.InsertShape( emptyGroupOne, 0 );
            group.InsertShape( emptyGroupTwo, 0 );

            Assert.IsFalse( groupOutLineStyle.IsEnabled() );
            Assert.IsFalse( groupOutLineStyle.IsEnabled() );
        }

        [TestMethod]
        public void IsEnabledTestFromGroupWithEmptyGroupsAndShapes()
        {
            var outLineStyle = new OutLineStyle( Color.Blue, true, 10 );
            var rectangleFrame = new Rect( 10, 10, 10, 10 );
            var ellipseFrame = new Rect( 12, 12, 12, 12 );
            var triangleFrame = new Rect( 15, 15, 15, 15 );

            var rectangle = new Rectangle( rectangleFrame, null, outLineStyle );
            var ellipse = new Elipse( ellipseFrame, null, outLineStyle );
            var triangle = new Triangle( triangleFrame, null, outLineStyle );

            var group = new GroupShape();
            var emptyGroup = new GroupShape();

            group.InsertShape( ellipse, 0 );
            group.InsertShape( rectangle, 0 );
            group.InsertShape( triangle, 0 );
            group.InsertShape( emptyGroup, 0 );

            Assert.IsFalse( group.GetOutlineStyle().IsEnabled() );
        }

        [TestMethod]
        public void EnableTestWithEmptyGroup()
        {
            var group = new GroupShape();
            var outLineGroupStyle = group.GetOutlineStyle();

            outLineGroupStyle.Enable( true );
            Assert.IsFalse( outLineGroupStyle.IsEnabled() );
            var rectangleFrame = new Rect( 10, 10, 10, 10 );
            var outLineStyle = new OutLineStyle( Color.Blue, true, 10 );

            var rectangle = new Rectangle( rectangleFrame, null, outLineStyle );
            group.InsertShape( rectangle, 0 );
            Assert.IsTrue( outLineGroupStyle.GetColor() == Color.Blue );

        }

        [TestMethod]
        public void EnableTestWithEmptyGroup1()
        {
            var group = new GroupShape();
            var outLineStyle = group.GetOutlineStyle();

            outLineStyle.Enable( true );
            Assert.IsFalse( outLineStyle.IsEnabled() );

        }

        [TestMethod]
        public void EnableTestColorWithGroupWithShapeWithSameIsEnabledValue()
        {
            var outLineStyle = new OutLineStyle( Color.Green, true, 10 );
            var rectangleFrame = new Rect( 10, 10, 10, 10 );
            var ellipseFrame = new Rect( 12, 12, 12, 12 );
            var triangleFrame = new Rect( 15, 15, 15, 15 );

            var rectangle = new Rectangle( rectangleFrame, null, outLineStyle );
            var ellipse = new Elipse( ellipseFrame,null,  outLineStyle );
            var triangle = new Triangle( triangleFrame,null, outLineStyle );

            var group = new GroupShape();
            var triangleGroup = new GroupShape();

            triangleGroup.InsertShape( triangle, 0 );
            group.InsertShape( ellipse, 0 );
            group.InsertShape( rectangle, 0 );

            var groupOutLineStyle = group.GetOutlineStyle();
            Assert.IsTrue( groupOutLineStyle.IsEnabled() );
            Assert.IsTrue( triangle.GetOutlineStyle().IsEnabled() );
            Assert.IsTrue( rectangle.GetOutlineStyle().IsEnabled() );
            Assert.IsTrue( ellipse.GetOutlineStyle().IsEnabled() );

            groupOutLineStyle.Enable( false );
            Assert.IsFalse( groupOutLineStyle.IsEnabled() );
            Assert.IsFalse( triangle.GetOutlineStyle().IsEnabled() );
            Assert.IsFalse( rectangle.GetOutlineStyle().IsEnabled() );
            Assert.IsFalse( ellipse.GetOutlineStyle().IsEnabled() );
        }

        [TestMethod]
        public void EnableTestColorWithGroupWithShapeWithDifferentIsEnabledValue()
        {
            var outLineStyle = new OutLineStyle( Color.Green, true, 10 );
            var triangleOutLineStyle = new OutLineStyle( Color.Green, false, 15 );
            var rectangleFrame = new Rect( 10, 10, 10, 10 );
            var ellipseFrame = new Rect( 12, 12, 12, 12 );
            var triangleFrame = new Rect( 15, 15, 15, 15 );

            var rectangle = new Rectangle( rectangleFrame, null, outLineStyle );
            var ellipse = new Elipse( ellipseFrame,null, outLineStyle );
            var triangle = new Triangle( triangleFrame, null,triangleOutLineStyle );

            var group = new GroupShape();
            var triangleGroup = new GroupShape();
            var groupOutLineStyle = group.GetOutlineStyle();

            triangleGroup.InsertShape( triangle, 0 );
            group.InsertShape( ellipse, 0 );
            group.InsertShape( rectangle, 0 );
            group.InsertShape( triangleGroup, 0 );

            Assert.IsFalse( groupOutLineStyle.IsEnabled() );
            Assert.IsFalse( triangle.GetOutlineStyle().IsEnabled() );
            Assert.IsTrue( rectangle.GetOutlineStyle().IsEnabled() );
            Assert.IsTrue( ellipse.GetOutlineStyle().IsEnabled() );

            groupOutLineStyle.Enable( true );
            Assert.IsTrue( groupOutLineStyle.IsEnabled() );
            Assert.IsTrue( triangle.GetOutlineStyle().IsEnabled() );
            Assert.IsTrue( rectangle.GetOutlineStyle().IsEnabled() );
            Assert.IsTrue( ellipse.GetOutlineStyle().IsEnabled() );
        }

        [TestMethod]
        public void EnableTestColorWithGroupWithEmptyGroupsAndShapes()
        {
            var outLineStyle = new OutLineStyle( Color.Green, true, 10 );
            var rectangleFrame = new Rect( 10, 10, 10, 10 );
            var ellipseFrame = new Rect( 12, 12, 12, 12 );
            var triangleFrame = new Rect( 15, 15, 15, 15 );

            var rectangle = new Rectangle( rectangleFrame, null, outLineStyle );
            var ellipse = new Elipse( ellipseFrame, null, outLineStyle );
            var triangle = new Triangle( triangleFrame, null, outLineStyle );

            var group = new GroupShape();
            var emptyGroup = new GroupShape();
            var groupOutLineStyle = group.GetOutlineStyle();

            group.InsertShape( ellipse, 0 );
            group.InsertShape( rectangle, 0 );
            group.InsertShape( triangle, 0 );
            group.InsertShape( emptyGroup, 0 );

            Assert.IsFalse( groupOutLineStyle.IsEnabled() );
            Assert.IsTrue( triangle.GetOutlineStyle().IsEnabled() );
            Assert.IsTrue( rectangle.GetOutlineStyle().IsEnabled() );
            Assert.IsTrue( ellipse.GetOutlineStyle().IsEnabled() );
            Assert.IsFalse( emptyGroup.GetOutlineStyle().IsEnabled() );

            groupOutLineStyle.Enable( true );
            Assert.IsFalse( groupOutLineStyle.IsEnabled() );
            Assert.IsTrue( triangle.GetOutlineStyle().IsEnabled() );
            Assert.IsTrue( rectangle.GetOutlineStyle().IsEnabled() );
            Assert.IsTrue( ellipse.GetOutlineStyle().IsEnabled() );
            Assert.IsFalse( emptyGroup.GetOutlineStyle().IsEnabled() );

        }

        [TestMethod]
        public void GetLineWidthFromGroupWithoutShapes()
        {
            var group = new GroupShape();
            var outLineStyle = group.GetOutlineStyle();

            Assert.AreEqual( null, outLineStyle.GetLineWidth() );
        }

        [TestMethod]
        public void GetLineWidthFromGroupWithShapesWithSameLineWidth()
        {
            var outLineStyle = new OutLineStyle( Color.Blue, true, 10 );
            var rectangleFrame = new Rect( 10, 10, 10, 10 );
            var ellipseFrame = new Rect( 12, 12, 12, 12 );
            var triangleFrame = new Rect( 15, 15, 15, 15 );

            var rectangle = new Rectangle( rectangleFrame, null, outLineStyle );
            var ellipse = new Elipse( ellipseFrame, null, outLineStyle );
            var triangle = new Triangle( triangleFrame, null, outLineStyle );

            var group = new GroupShape();
            var triangleGroup = new GroupShape();

            triangleGroup.InsertShape( triangle, 0 );
            group.InsertShape( ellipse, 0 );
            group.InsertShape( triangleGroup, 0 );
            group.InsertShape( rectangle, 0 );

            var groupOutLineStyle = group.GetOutlineStyle();

            Assert.AreEqual( 10, groupOutLineStyle.GetLineWidth() );
        }

        [TestMethod]
        public void GetLineWidthFromGroupWithShapesWithDifferentLineWidth()
        {
            var outLineStyle = new OutLineStyle( Color.Blue, true, 10 );
            var triangleOutLineStyle = new OutLineStyle( Color.Blue, true, 15 );
            var rectangleFrame = new Rect( 10, 10, 10, 10 );
            var ellipseFrame = new Rect( 12, 12, 12, 12 );
            var triangleFrame = new Rect( 15, 15, 15, 15 );

            var rectangle = new Rectangle( rectangleFrame, null, outLineStyle );
            var ellipse = new Elipse( ellipseFrame, null, outLineStyle );
            var triangle = new Triangle( triangleFrame, null, triangleOutLineStyle );

            var group = new GroupShape();
            var triangleGroup = new GroupShape();

            triangleGroup.InsertShape( triangle, 0 );
            group.InsertShape( ellipse, 0 );
            group.InsertShape( triangleGroup, 0 );
            group.InsertShape( rectangle, 0 );

            var groupOutLineStyle = group.GetOutlineStyle();

            Assert.AreEqual( null, groupOutLineStyle.GetLineWidth() );
        }

        [TestMethod]
        public void GetLineWidthAfterRemovingShapeWithDifferentLineWidth()
        {
            var outLineStyle = new OutLineStyle( Color.Blue, true, 10 );
            var triangleOutLineStyle = new OutLineStyle( Color.Blue, true, 15 );
            var rectangleFrame = new Rect( 10, 10, 10, 10 );
            var ellipseFrame = new Rect( 12, 12, 12, 12 );
            var triangleFrame = new Rect( 15, 15, 15, 15 );

            var rectangle = new Rectangle( rectangleFrame, null, outLineStyle );
            var ellipse = new Elipse( ellipseFrame, null, outLineStyle );
            var triangle = new Triangle( triangleFrame, null, triangleOutLineStyle );

            var group = new GroupShape();
            var triangleGroup = new GroupShape();

            triangleGroup.InsertShape( triangle, 0 );
            group.InsertShape( ellipse, 0 );
            group.InsertShape( rectangle, 0 );
            group.InsertShape( triangleGroup, 0 );

            var groupOutLineStyle = group.GetOutlineStyle();
            Assert.AreEqual( null, groupOutLineStyle.GetLineWidth() );

            group.RemoveShapeAtIndex( 0 );
            Assert.AreEqual( 10, groupOutLineStyle.GetLineWidth() );
        }

        [TestMethod]
        public void GetLineWidthAfterRemovingShapeWitSameLineWidth()
        {
            var outLineStyle = new OutLineStyle( Color.Blue, true, 10 );
            var triangleOutLineStyle = new OutLineStyle( Color.Blue, true, 10 );
            var rectangleFrame = new Rect( 10, 10, 10, 10 );
            var ellipseFrame = new Rect( 12, 12, 12, 12 );
            var triangleFrame = new Rect( 15, 15, 15, 15 );

            var rectangle = new Rectangle( rectangleFrame, null, outLineStyle );
            var ellipse = new Elipse( ellipseFrame, null, outLineStyle );
            var triangle = new Triangle( triangleFrame, null, triangleOutLineStyle );

            var group = new GroupShape();
            var triangleGroup = new GroupShape();

            triangleGroup.InsertShape( triangle, 0 );
            group.InsertShape( ellipse, 0 );
            group.InsertShape( rectangle, 0 );
            group.InsertShape( triangleGroup, 0 );

            var groupOutLineStyle = group.GetOutlineStyle();
            Assert.AreEqual( 10, groupOutLineStyle.GetLineWidth() );

            group.RemoveShapeAtIndex( 0 );
            Assert.AreEqual( 10, groupOutLineStyle.GetLineWidth() );
        }

        [TestMethod]
        public void GetLineWidthAfterAddingShapeWithDifferentLineWidth()
        {
            var outLineStyle = new OutLineStyle( Color.Blue, true, 10 );
            var triangleOutLineStyle = new OutLineStyle( Color.Blue, true, 15 );
            var rectangleFrame = new Rect( 10, 10, 10, 10 );
            var ellipseFrame = new Rect( 12, 12, 12, 12 );
            var triangleFrame = new Rect( 15, 15, 15, 15 );

            var rectangle = new Rectangle( rectangleFrame, null, outLineStyle );
            var ellipse = new Elipse( ellipseFrame, null, outLineStyle );
            var triangle = new Triangle( triangleFrame, null, triangleOutLineStyle );

            var group = new GroupShape();
            var triangleGroup = new GroupShape();

            triangleGroup.InsertShape( triangle, 0 );
            group.InsertShape( ellipse, 0 );
            group.InsertShape( rectangle, 0 );

            var groupOutLineStyle = group.GetOutlineStyle();
            Assert.AreEqual( 10, groupOutLineStyle.GetLineWidth() );

            group.InsertShape( triangleGroup, 0 );
            Assert.AreEqual( null, groupOutLineStyle.GetLineWidth() );
        }

        [TestMethod]
        public void GetLineWidthAfterAddingShapeWithSameLineWidth()
        {
            var outLineStyle = new OutLineStyle( Color.Blue, true, 10 );
            var triangleOutLineStyle = new OutLineStyle( Color.Blue, true, 10 );
            var rectangleFrame = new Rect( 10, 10, 10, 10 );
            var ellipseFrame = new Rect( 12, 12, 12, 12 );
            var triangleFrame = new Rect( 15, 15, 15, 15 );

            var rectangle = new Rectangle( rectangleFrame, null, outLineStyle );
            var ellipse = new Elipse( ellipseFrame, null, outLineStyle );
            var triangle = new Triangle( triangleFrame, null, triangleOutLineStyle );

            var group = new GroupShape();
            var triangleGroup = new GroupShape();

            triangleGroup.InsertShape( triangle, 0 );
            group.InsertShape( ellipse, 0 );
            group.InsertShape( rectangle, 0 );

            var groupOutLineStyle = group.GetOutlineStyle();
            Assert.AreEqual( 10, groupOutLineStyle.GetLineWidth() );

            group.InsertShape( triangleGroup, 0 );
            Assert.AreEqual( 10, groupOutLineStyle.GetLineWidth() );
        }

        [TestMethod]
        public void GetLineWidthFromGroupWithEmptyGroups()
        {
            var group = new GroupShape();
            var emptyGroupOne = new GroupShape();
            var emptyGroupTwo = new GroupShape();

            group.InsertShape( emptyGroupOne, 0 );
            group.InsertShape( emptyGroupTwo, 0 );

            Assert.AreEqual( null, group.GetOutlineStyle().GetLineWidth() );
            Assert.AreEqual( null, emptyGroupOne.GetOutlineStyle().GetLineWidth() );
        }

        [TestMethod]
        public void GetLineWidthFromGroupWithEmptyGroupsAndShapes()
        {
            var outLineStyle = new OutLineStyle( Color.Blue, true, 10 );
            var rectangleFrame = new Rect( 10, 10, 10, 10 );
            var ellipseFrame = new Rect( 12, 12, 12, 12 );
            var triangleFrame = new Rect( 15, 15, 15, 15 );

            var rectangle = new Rectangle( rectangleFrame, null, outLineStyle );
            var ellipse = new Elipse( ellipseFrame, null, outLineStyle );
            var triangle = new Triangle( triangleFrame, null, outLineStyle );

            var group = new GroupShape();
            var emptyGroup = new GroupShape();

            group.InsertShape( ellipse, 0 );
            group.InsertShape( rectangle, 0 );
            group.InsertShape( triangle, 0 );
            group.InsertShape( emptyGroup, 0 );

            Assert.AreEqual( null, group.GetOutlineStyle().GetLineWidth() );
        }

        [TestMethod]
        public void SetLineWidthWithEmptyGroup()
        {
            var group = new GroupShape();
            var outLineStyle = group.GetOutlineStyle();

            outLineStyle.SetLineWidth( 12 );
            Assert.AreEqual( null, outLineStyle.GetLineWidth() );
        }

        [TestMethod]
        public void SetLineWidthWithGroupWithShapeWithSameLineWidth()
        {
            var outLineStyle = new OutLineStyle( Color.Green, true, 10 );
            var rectangleFrame = new Rect( 10, 10, 10, 10 );
            var ellipseFrame = new Rect( 12, 12, 12, 12 );
            var triangleFrame = new Rect( 15, 15, 15, 15 );

            var rectangle = new Rectangle( rectangleFrame, null, outLineStyle );
            var ellipse = new Elipse( ellipseFrame, null, outLineStyle );
            var triangle = new Triangle( triangleFrame, null, outLineStyle );

            var group = new GroupShape();
            var triangleGroup = new GroupShape();

            triangleGroup.InsertShape( triangle, 0 );
            group.InsertShape( ellipse, 0 );
            group.InsertShape( rectangle, 0 );

            var groupOutLineStyle = group.GetOutlineStyle();
            Assert.AreEqual( 10, groupOutLineStyle.GetLineWidth() );
            Assert.AreEqual( 10, triangle.GetOutlineStyle().GetLineWidth() );
            Assert.AreEqual( 10, rectangle.GetOutlineStyle().GetLineWidth() );
            Assert.AreEqual( 10, ellipse.GetOutlineStyle().GetLineWidth() );

            groupOutLineStyle.SetLineWidth( 12 );
            Assert.AreEqual( 12, groupOutLineStyle.GetLineWidth() );
            Assert.AreEqual( 12, triangle.GetOutlineStyle().GetLineWidth() );
            Assert.AreEqual( 12, rectangle.GetOutlineStyle().GetLineWidth() );
            Assert.AreEqual( 12, ellipse.GetOutlineStyle().GetLineWidth() );
        }

        [TestMethod]
        public void SetLineWidthWithGroupWithShapeWithDifferentColor()
        {
            var outLineStyle = new OutLineStyle( Color.Green, true, 10 );
            var triangleOutLineStyle = new OutLineStyle( Color.Green, true, 15 );
            var rectangleFrame = new Rect( 10, 10, 10, 10 );
            var ellipseFrame = new Rect( 12, 12, 12, 12 );
            var triangleFrame = new Rect( 15, 15, 15, 15 );

            var rectangle = new Rectangle( rectangleFrame, null, outLineStyle );
            var ellipse = new Elipse( ellipseFrame, null, outLineStyle );
            var triangle = new Triangle( triangleFrame, null, triangleOutLineStyle );

            var group = new GroupShape();
            var triangleGroup = new GroupShape();
            var groupOutLineStyle = group.GetOutlineStyle();

            triangleGroup.InsertShape( triangle, 0 );
            group.InsertShape( ellipse, 0 );
            group.InsertShape( rectangle, 0 );
            group.InsertShape( triangleGroup, 0 );

            Assert.AreEqual( null, groupOutLineStyle.GetLineWidth() );
            Assert.AreEqual( 15, triangle.GetOutlineStyle().GetLineWidth() );
            Assert.AreEqual( 10, rectangle.GetOutlineStyle().GetLineWidth() );
            Assert.AreEqual( 10, ellipse.GetOutlineStyle().GetLineWidth() );

            groupOutLineStyle.SetLineWidth( 12 );
            Assert.AreEqual( 12, groupOutLineStyle.GetLineWidth() );
            Assert.AreEqual( 12, triangle.GetOutlineStyle().GetLineWidth() );
            Assert.AreEqual( 12, rectangle.GetOutlineStyle().GetLineWidth() );
            Assert.AreEqual( 12, ellipse.GetOutlineStyle().GetLineWidth() );
        }

        [TestMethod]
        public void SetLineWidthGroupWithEmptyGroupsAndShapes()
        {
            var outLineStyle = new OutLineStyle( Color.Green, true, 10 );
            var rectangleFrame = new Rect( 10, 10, 10, 10 );
            var ellipseFrame = new Rect( 12, 12, 12, 12 );
            var triangleFrame = new Rect( 15, 15, 15, 15 );

            var rectangle = new Rectangle( rectangleFrame, null, outLineStyle );
            var ellipse = new Elipse( ellipseFrame, null, outLineStyle );
            var triangle = new Triangle( triangleFrame, null, outLineStyle );

            var group = new GroupShape();
            var emptyGroup = new GroupShape();
            var groupOutLineStyle = group.GetOutlineStyle();

            group.InsertShape( ellipse, 0 );
            group.InsertShape( rectangle, 0 );
            group.InsertShape( triangle, 0 );
            group.InsertShape( emptyGroup, 0 );

            Assert.AreEqual( null, groupOutLineStyle.GetLineWidth() );
            Assert.AreEqual( 10, triangle.GetOutlineStyle().GetLineWidth() );
            Assert.AreEqual( 10, rectangle.GetOutlineStyle().GetLineWidth() );
            Assert.AreEqual( 10, ellipse.GetOutlineStyle().GetLineWidth() );

            groupOutLineStyle.SetLineWidth( 12 );
            Assert.AreEqual( null, groupOutLineStyle.GetLineWidth() );
            Assert.AreEqual( 12, triangle.GetOutlineStyle().GetLineWidth() );
            Assert.AreEqual( 12, rectangle.GetOutlineStyle().GetLineWidth() );
            Assert.AreEqual( 12, ellipse.GetOutlineStyle().GetLineWidth() );
        }
    }
}
