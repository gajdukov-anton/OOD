using System;
using System.Drawing;
using System.IO;
using Composite.Canvas;
using Composite.Drawable;
using Composite.Groups;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rectangle = Composite.Drawable.Rectangle;

namespace CompositeTest
{
    [TestClass]
    public class GroupShapeTest
    {
        //Style tests

        [TestMethod]
        public void GetFillStyleFromGroupWithoutShapes()
        {
            var group = new GroupShape();
            var fillStyle = group.GetFillStyle();

            Assert.AreEqual( fillStyle.GetColor(), Color.Empty );
            Assert.AreEqual( fillStyle.IsEnable(), false );
        }

        [TestMethod]
        public void GetOutLineStyleFromGroupWithoutShapes()
        {
            var group = new GroupShape();
            var outLineStyle = group.GetOutlineStyle();

            Assert.AreEqual( Color.Empty, outLineStyle.GetColor() );
            Assert.AreEqual( false, outLineStyle.IsEnable() );
            Assert.AreEqual( null, outLineStyle.GetLineWidth() );
        }

        [TestMethod]
        public void SetFillStyleToGroupWithoutShapes()
        {
            var group = new GroupShape();
            var fillStyle = group.GetFillStyle();

            fillStyle.SetColor( Color.Green );
            fillStyle.Enable( true );

            Assert.AreEqual( fillStyle.GetColor(), Color.Empty );
            Assert.AreEqual( fillStyle.IsEnable(), false );
        }

        [TestMethod]
        public void SetOutLineStyleToGroupWithoutShapes()
        {
            var group = new GroupShape();
            var outLineStyle = group.GetOutlineStyle();

            outLineStyle.SetColor( Color.Green );
            outLineStyle.Enable( true );
            outLineStyle.SetLineWidth( 10 );

            Assert.AreEqual( Color.Empty, outLineStyle.GetColor() );
            Assert.AreEqual( false, outLineStyle.IsEnable() );
            Assert.AreEqual( null, outLineStyle.GetLineWidth() );
        }

        [TestMethod]
        public void GetFillStyleFromGroupWithShapesWithSameFillStyle()
        {
            var fillStyle = new Style( Color.Green, true );
            var ellipseFillStyle = new Style( Color.Green, true );
            var rectangleFrame = new Rect( 10, 10, 10, 10 );
            var ellipseFrame = new Rect( 12, 12, 12, 12 );
            var triangleFrame = new Rect( 15, 15, 15, 15 );

            var rectangle = new Rectangle( rectangleFrame, fillStyle );
            var ellipse = new Elipse( ellipseFrame, ellipseFillStyle );
            var triangle = new Triangle( triangleFrame, fillStyle );

            var group = new GroupShape();
            var triangleGroup = new GroupShape();

            triangleGroup.InsertShape( triangle, 0 );
            group.InsertShape( ellipse, 0 );
            group.InsertShape( triangleGroup, 0 );
            group.InsertShape( rectangle, 0 );

            var groupFillStyle = group.GetFillStyle();
            var triangleGroupFillStyle = triangleGroup.GetFillStyle();

            Assert.AreEqual( groupFillStyle.GetColor(), Color.Green );
            Assert.AreEqual( groupFillStyle.IsEnable(), true );
            Assert.AreEqual( triangleGroupFillStyle.GetColor(), Color.Green );
            Assert.AreEqual( triangleGroupFillStyle.IsEnable(), true );
        }

        [TestMethod]
        public void GetFillStyleFromGroupWithShapesWithDifferentColorFillStyle()
        {
            var triangleFillStyle = new Style( Color.Green, true );
            var fillStyle = new Style( Color.Yellow, true );
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
            var triangleGroupFillStyle = triangleGroup.GetFillStyle();

            Assert.AreEqual( Color.Empty, groupFillStyle.GetColor() );
            Assert.AreEqual( true, groupFillStyle.IsEnable() );
            Assert.AreEqual( Color.Green, triangleGroupFillStyle.GetColor() );
            Assert.AreEqual( true, triangleGroupFillStyle.IsEnable() );
        }

        [TestMethod]
        public void GetFillStyleFromGroupWithShapesWithDifferentEnableFillStyle()
        {
            var rectangleFillStyle = new Style( Color.Yellow, false );
            var fillStyle = new Style( Color.Yellow, true );
            var rectangleFrame = new Rect( 10, 10, 10, 10 );
            var ellipseFrame = new Rect( 12, 12, 12, 12 );
            var triangleFrame = new Rect( 15, 15, 15, 15 );

            var rectangle = new Rectangle( rectangleFrame, rectangleFillStyle );
            var ellipse = new Elipse( ellipseFrame, fillStyle );
            var triangle = new Triangle( triangleFrame, fillStyle );

            var group = new GroupShape();
            var triangleGroup = new GroupShape();

            triangleGroup.InsertShape( triangle, 0 );
            group.InsertShape( ellipse, 0 );
            group.InsertShape( triangleGroup, 0 );
            group.InsertShape( rectangle, 0 );

            var groupFillStyle = group.GetFillStyle();
            var triangleGroupFillStyle = triangleGroup.GetFillStyle();

            Assert.AreEqual( Color.Yellow, groupFillStyle.GetColor() );
            Assert.AreEqual( false, groupFillStyle.IsEnable() );
            Assert.AreEqual( Color.Yellow, triangleGroupFillStyle.GetColor() );
            Assert.AreEqual( true, triangleGroupFillStyle.IsEnable() );
        }

        [TestMethod]
        public void GetOutLineStyleFromGroupWithShapesWithSameStyle()
        {
            var outLineStyle = new OutLineStyle( Color.Yellow, true, 10 );
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
            var triangleGroupOutLineStyle = triangleGroup.GetOutlineStyle();

            Assert.AreEqual( Color.Yellow, groupOutLineStyle.GetColor() );
            Assert.AreEqual( true, groupOutLineStyle.IsEnable() );
            Assert.AreEqual( 10, groupOutLineStyle.GetLineWidth() );
            Assert.AreEqual( Color.Yellow, triangleGroupOutLineStyle.GetColor() );
            Assert.AreEqual( true, triangleGroupOutLineStyle.IsEnable() );
            Assert.AreEqual( 10, triangleGroupOutLineStyle.GetLineWidth() );
        }

        [TestMethod]
        public void GetOutLineStyleFromGroupWithDifferentColorInSecondLvl()
        {
            var outLineStyle = new OutLineStyle( Color.Yellow, true, 10 );
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
            group.InsertShape( triangleGroup, 0 );
            group.InsertShape( rectangle, 0 );

            var groupOutLineStyle = group.GetOutlineStyle();
            var triangleGroupOutLineStyle = triangleGroup.GetOutlineStyle();

            Assert.AreEqual( Color.Empty, groupOutLineStyle.GetColor() );
            Assert.AreEqual( true, groupOutLineStyle.IsEnable() );
            Assert.AreEqual( 10, groupOutLineStyle.GetLineWidth() );
            Assert.AreEqual( Color.Blue, triangleGroupOutLineStyle.GetColor() );
            Assert.AreEqual( true, triangleGroupOutLineStyle.IsEnable() );
            Assert.AreEqual( 10, triangleGroupOutLineStyle.GetLineWidth() );
        }

        [TestMethod]
        public void GetOutLineStyleFromGroupWithDifferentColorInFirstLvl()
        {
            var outLineStyle = new OutLineStyle( Color.Yellow, true, 10 );
            var ellipseOutLineStyle = new OutLineStyle( Color.Blue, true, 10 );
            var rectangleFrame = new Rect( 10, 10, 10, 10 );
            var ellipseFrame = new Rect( 12, 12, 12, 12 );
            var triangleFrame = new Rect( 15, 15, 15, 15 );

            var rectangle = new Rectangle( rectangleFrame, null, outLineStyle );
            var ellipse = new Elipse( ellipseFrame, null, ellipseOutLineStyle );
            var triangle = new Triangle( triangleFrame, null, outLineStyle );

            var group = new GroupShape();
            var triangleGroup = new GroupShape();

            triangleGroup.InsertShape( triangle, 0 );
            group.InsertShape( ellipse, 0 );
            group.InsertShape( triangleGroup, 0 );
            group.InsertShape( rectangle, 0 );

            var groupOutLineStyle = group.GetOutlineStyle();
            var triangleGroupOutLineStyle = triangleGroup.GetOutlineStyle();

            Assert.AreEqual( Color.Empty, groupOutLineStyle.GetColor() );
            Assert.AreEqual( true, groupOutLineStyle.IsEnable() );
            Assert.AreEqual( 10, groupOutLineStyle.GetLineWidth() );
            Assert.AreEqual( Color.Yellow, triangleGroupOutLineStyle.GetColor() );
            Assert.AreEqual( true, triangleGroupOutLineStyle.IsEnable() );
            Assert.AreEqual( 10, triangleGroupOutLineStyle.GetLineWidth() );
        }

        [TestMethod]
        public void GetOutLineStyleFromGroupWithDifferentEnableInFirstLvl()
        {
            var outLineStyle = new OutLineStyle( Color.Yellow, true, 10 );
            var ellipseOutLineStyle = new OutLineStyle( Color.Yellow, false, 10 );
            var rectangleFrame = new Rect( 10, 10, 10, 10 );
            var ellipseFrame = new Rect( 12, 12, 12, 12 );
            var triangleFrame = new Rect( 15, 15, 15, 15 );

            var rectangle = new Rectangle( rectangleFrame, null, outLineStyle );
            var ellipse = new Elipse( ellipseFrame, null, ellipseOutLineStyle );
            var triangle = new Triangle( triangleFrame, null, outLineStyle );

            var group = new GroupShape();
            var triangleGroup = new GroupShape();

            triangleGroup.InsertShape( triangle, 0 );
            group.InsertShape( ellipse, 0 );
            group.InsertShape( triangleGroup, 0 );
            group.InsertShape( rectangle, 0 );

            var groupOutLineStyle = group.GetOutlineStyle();
            var triangleGroupOutLineStyle = triangleGroup.GetOutlineStyle();

            Assert.AreEqual( Color.Yellow, groupOutLineStyle.GetColor() );
            Assert.AreEqual( false, groupOutLineStyle.IsEnable() );
            Assert.AreEqual( 10, groupOutLineStyle.GetLineWidth() );
            Assert.AreEqual( Color.Yellow, triangleGroupOutLineStyle.GetColor() );
            Assert.AreEqual( true, triangleGroupOutLineStyle.IsEnable() );
            Assert.AreEqual( 10, triangleGroupOutLineStyle.GetLineWidth() );
        }

        [TestMethod]
        public void GetOutLineStyleFromGroupWithDifferentEnableInSecondLvl()
        {
            var outLineStyle = new OutLineStyle( Color.Yellow, true, 10 );
            var triangleOutLineStyle = new OutLineStyle( Color.Yellow, false, 10 );
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
            var triangleGroupOutLineStyle = triangleGroup.GetOutlineStyle();

            Assert.AreEqual( Color.Yellow, groupOutLineStyle.GetColor() );
            Assert.AreEqual( false, groupOutLineStyle.IsEnable() );
            Assert.AreEqual( 10, groupOutLineStyle.GetLineWidth() );
            Assert.AreEqual( Color.Yellow, triangleGroupOutLineStyle.GetColor() );
            Assert.AreEqual( false, triangleGroupOutLineStyle.IsEnable() );
            Assert.AreEqual( 10, triangleGroupOutLineStyle.GetLineWidth() );
        }

        [TestMethod]
        public void GetOutLineStyleFromGroupWithDifferentWidthInFirstLvl()
        {
            var outLineStyle = new OutLineStyle( Color.Yellow, true, 10 );
            var ellipseOutLineStyle = new OutLineStyle( Color.Yellow, true, 11 );
            var rectangleFrame = new Rect( 10, 10, 10, 10 );
            var ellipseFrame = new Rect( 12, 12, 12, 12 );
            var triangleFrame = new Rect( 15, 15, 15, 15 );

            var rectangle = new Rectangle( rectangleFrame, null, outLineStyle );
            var ellipse = new Elipse( ellipseFrame, null, ellipseOutLineStyle );
            var triangle = new Triangle( triangleFrame, null, outLineStyle );

            var group = new GroupShape();
            var triangleGroup = new GroupShape();

            triangleGroup.InsertShape( triangle, 0 );
            group.InsertShape( ellipse, 0 );
            group.InsertShape( triangleGroup, 0 );
            group.InsertShape( rectangle, 0 );

            var groupOutLineStyle = group.GetOutlineStyle();
            var triangleGroupOutLineStyle = triangleGroup.GetOutlineStyle();

            Assert.AreEqual( Color.Yellow, groupOutLineStyle.GetColor() );
            Assert.AreEqual( true, groupOutLineStyle.IsEnable() );
            Assert.AreEqual( null, groupOutLineStyle.GetLineWidth() );
            Assert.AreEqual( Color.Yellow, triangleGroupOutLineStyle.GetColor() );
            Assert.AreEqual( true, triangleGroupOutLineStyle.IsEnable() );
            Assert.AreEqual( 10, triangleGroupOutLineStyle.GetLineWidth() );
        }

        [TestMethod]
        public void GetOutLineStyleFromGroupWithDifferentWidthInSecondLvl()
        {
            var outLineStyle = new OutLineStyle( Color.Yellow, true, 10 );
            var triangleOutLineStyle = new OutLineStyle( Color.Yellow, true, 11 );
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
            var triangleGroupOutLineStyle = triangleGroup.GetOutlineStyle();

            Assert.AreEqual( Color.Yellow, groupOutLineStyle.GetColor() );
            Assert.AreEqual( true, groupOutLineStyle.IsEnable() );
            Assert.AreEqual( null, groupOutLineStyle.GetLineWidth() );
            Assert.AreEqual( Color.Yellow, triangleGroupOutLineStyle.GetColor() );
            Assert.AreEqual( true, triangleGroupOutLineStyle.IsEnable() );
            Assert.AreEqual( 11, triangleGroupOutLineStyle.GetLineWidth() );
        }

        [TestMethod]
        public void SetColorToFillStyleToGroupWithSameStyles()
        {
            var fillStyle = new Style( Color.Yellow, true );
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
            var triangleGroupFillStyle = triangleGroup.GetFillStyle();

            groupFillStyle.SetColor( Color.Black );

            Assert.AreEqual( Color.Black, groupFillStyle.GetColor() );
            Assert.AreEqual( true, groupFillStyle.IsEnable() );
            Assert.AreEqual( Color.Black, triangleGroupFillStyle.GetColor() );
            Assert.AreEqual( true, triangleGroupFillStyle.IsEnable() );
        }

        [TestMethod]
        public void SetEnableToFillStyleToGroupWithSameStyles()
        {
            var fillStyle = new Style( Color.Yellow, true );
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
            var triangleGroupFillStyle = triangleGroup.GetFillStyle();

            groupFillStyle.Enable( false );

            Assert.AreEqual( Color.Yellow, groupFillStyle.GetColor() );
            Assert.AreEqual( false, groupFillStyle.IsEnable() );
            Assert.AreEqual( Color.Yellow, triangleGroupFillStyle.GetColor() );
            Assert.AreEqual( false, triangleGroupFillStyle.IsEnable() );
        }

        [TestMethod]
        public void SetColorToFillStyleToGroupWithDifferentColor()
        {
            var fillStyle = new Style( Color.Yellow, true );
            var triangleFillStyle = new Style( Color.Blue, true );
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
            var triangleGroupFillStyle = triangleGroup.GetFillStyle();

            groupFillStyle.SetColor( Color.Black );

            Assert.AreEqual( Color.Black, groupFillStyle.GetColor() );
            Assert.AreEqual( true, groupFillStyle.IsEnable() );
            Assert.AreEqual( Color.Black, triangleGroupFillStyle.GetColor() );
            Assert.AreEqual( true, triangleGroupFillStyle.IsEnable() );
        }

        [TestMethod]
        public void SetEnableToFillStyleToGroupWithDifferentEnable()
        {
            var fillStyle = new Style( Color.Yellow, true );
            var triangleFillStyle = new Style( Color.Yellow, false );
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
            var triangleGroupFillStyle = triangleGroup.GetFillStyle();

            groupFillStyle.Enable( true );

            Assert.AreEqual( Color.Yellow, groupFillStyle.GetColor() );
            Assert.AreEqual( true, groupFillStyle.IsEnable() );
            Assert.AreEqual( Color.Yellow, triangleGroupFillStyle.GetColor() );
            Assert.AreEqual( true, triangleGroupFillStyle.IsEnable() );
        }

        [TestMethod]
        public void SetWithToOutLineStyleToGroupWithSameWidth()
        {
            var outLineStyle = new OutLineStyle( Color.Yellow, true, 10 );
            var triangleOutLineStyle = new OutLineStyle( Color.Yellow, true, 10 );
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
            var triangleGroupOutLineStyle = triangleGroup.GetOutlineStyle();

            groupOutLineStyle.SetLineWidth( 12 );

            Assert.AreEqual( Color.Yellow, groupOutLineStyle.GetColor() );
            Assert.AreEqual( true, groupOutLineStyle.IsEnable() );
            Assert.AreEqual( 12, groupOutLineStyle.GetLineWidth() );
            Assert.AreEqual( Color.Yellow, triangleGroupOutLineStyle.GetColor() );
            Assert.AreEqual( true, triangleGroupOutLineStyle.IsEnable() );
            Assert.AreEqual( 12, groupOutLineStyle.GetLineWidth() );
        }

        [TestMethod]
        public void VerifyChangeColorToEmptyOnGroupFillStyleAfterAddingNewShape()
        {
            var fillStyle = new Style( Color.Yellow, true );
            var triangleFillStyle = new Style( Color.Black, true );
            var rectangleFrame = new Rect( 10, 10, 10, 10 );
            var ellipseFrame = new Rect( 12, 12, 12, 12 );
            var triangleFrame = new Rect( 15, 15, 15, 15 );

            var rectangle = new Rectangle( rectangleFrame, fillStyle );
            var ellipse = new Elipse( ellipseFrame, fillStyle );
            var triangle = new Triangle( triangleFrame, triangleFillStyle );

            var group = new GroupShape();
            var triangleGroup = new GroupShape();
            var groupFillStyle = group.GetFillStyle();
            var triangleGroupOutLineStyle = triangleGroup.GetFillStyle();

            triangleGroup.InsertShape( triangle, 0 );

            Assert.AreEqual( Color.Empty, groupFillStyle.GetColor() );
            Assert.AreEqual( false, groupFillStyle.IsEnable() );

            group.InsertShape( ellipse, 0 );

            Assert.AreEqual( Color.Yellow, groupFillStyle.GetColor() );
            Assert.AreEqual( true, groupFillStyle.IsEnable() );

            group.InsertShape( rectangle, 0 );

            Assert.AreEqual( Color.Yellow, groupFillStyle.GetColor() );
            Assert.AreEqual( true, groupFillStyle.IsEnable() );

            group.InsertShape( triangleGroup, 0 );

            Assert.AreEqual( Color.Empty, groupFillStyle.GetColor() );
            Assert.AreEqual( true, groupFillStyle.IsEnable() );
            Assert.AreEqual( Color.Black, triangleGroupOutLineStyle.GetColor() );
            Assert.AreEqual( true, triangleGroupOutLineStyle.IsEnable() );
        }

        [TestMethod]
        public void VerifyNotChangePropertiesOnGroupFillStyleAfterAddingNewShape()
        {
            var fillStyle = new Style( Color.Yellow, true );
            var triangleFillStyle = new Style( Color.Yellow, true );
            var rectangleFrame = new Rect( 10, 10, 10, 10 );
            var ellipseFrame = new Rect( 12, 12, 12, 12 );
            var triangleFrame = new Rect( 15, 15, 15, 15 );

            var rectangle = new Rectangle( rectangleFrame, fillStyle );
            var ellipse = new Elipse( ellipseFrame, fillStyle );
            var triangle = new Triangle( triangleFrame, triangleFillStyle );

            var group = new GroupShape();
            var triangleGroup = new GroupShape();
            var triangleGroupOutLineStyle = triangleGroup.GetFillStyle();
            var groupFillStyle = group.GetFillStyle();

            triangleGroup.InsertShape( triangle, 0 );
            Assert.AreEqual( Color.Empty, groupFillStyle.GetColor() );
            Assert.AreEqual( false, groupFillStyle.IsEnable() );

            group.InsertShape( ellipse, 0 );

            Assert.AreEqual( Color.Yellow, groupFillStyle.GetColor() );
            Assert.AreEqual( true, groupFillStyle.IsEnable() );

            group.InsertShape( rectangle, 0 );

            Assert.AreEqual( Color.Yellow, groupFillStyle.GetColor() );
            Assert.AreEqual( true, groupFillStyle.IsEnable() );

            group.InsertShape( triangleGroup, 0 );

            Assert.AreEqual( Color.Yellow, groupFillStyle.GetColor() );
            Assert.AreEqual( true, groupFillStyle.IsEnable() );
            Assert.AreEqual( Color.Yellow, triangleGroupOutLineStyle.GetColor() );
            Assert.AreEqual( true, triangleGroupOutLineStyle.IsEnable() );
        }

        [TestMethod]
        public void VerifyChangeEnableToEmptyOnGroupFillStyleAfterAddingNewShape()
        {
            var fillStyle = new Style( Color.Yellow, true );
            var triangleFillStyle = new Style( Color.Yellow, false );
            var rectangleFrame = new Rect( 10, 10, 10, 10 );
            var ellipseFrame = new Rect( 12, 12, 12, 12 );
            var triangleFrame = new Rect( 15, 15, 15, 15 );

            var rectangle = new Rectangle( rectangleFrame, fillStyle );
            var ellipse = new Elipse( ellipseFrame, fillStyle );
            var triangle = new Triangle( triangleFrame, triangleFillStyle );

            var group = new GroupShape();
            var triangleGroup = new GroupShape();
            var groupFillStyle = group.GetFillStyle();
            var triangleGroupOutLineStyle = triangleGroup.GetFillStyle();

            triangleGroup.InsertShape( triangle, 0 );

            Assert.AreEqual( Color.Empty, groupFillStyle.GetColor() );
            Assert.AreEqual( false, groupFillStyle.IsEnable() );

            group.InsertShape( ellipse, 0 );

            Assert.AreEqual( Color.Yellow, groupFillStyle.GetColor() );
            Assert.AreEqual( true, groupFillStyle.IsEnable() );

            group.InsertShape( rectangle, 0 );

            Assert.AreEqual( Color.Yellow, groupFillStyle.GetColor() );
            Assert.AreEqual( true, groupFillStyle.IsEnable() );

            group.InsertShape( triangleGroup, 0 );

            Assert.AreEqual( Color.Yellow, groupFillStyle.GetColor() );
            Assert.AreEqual( false, groupFillStyle.IsEnable() );
            Assert.AreEqual( Color.Yellow, triangleGroupOutLineStyle.GetColor() );
            Assert.AreEqual( false, triangleGroupOutLineStyle.IsEnable() );
        }

        [TestMethod]
        public void VerifyChangeWidthOnOutlineStyleAfterAddingNewShape()
        {
            var outLineStyle = new OutLineStyle( Color.Yellow, true, 10 );
            var triangleOutLineStyle = new OutLineStyle( Color.Yellow, true, 12 );
            var rectangleFrame = new Rect( 10, 10, 10, 10 );
            var ellipseFrame = new Rect( 12, 12, 12, 12 );
            var triangleFrame = new Rect( 15, 15, 15, 15 );

            var rectangle = new Rectangle( rectangleFrame, null, outLineStyle );
            var ellipse = new Elipse( ellipseFrame, null, outLineStyle );
            var triangle = new Triangle( triangleFrame, null, triangleOutLineStyle );

            var group = new GroupShape();
            var triangleGroup = new GroupShape();
            var triangleGroupOutLineStyle = triangleGroup.GetOutlineStyle();
            var groupOutLineStyle = group.GetOutlineStyle();

            triangleGroup.InsertShape( triangle, 0 );
            Assert.AreEqual( Color.Empty, groupOutLineStyle.GetColor() );
            Assert.AreEqual( false, groupOutLineStyle.IsEnable() );
            Assert.AreEqual( null, groupOutLineStyle.GetLineWidth() );

            group.InsertShape( ellipse, 0 );

            Assert.AreEqual( Color.Yellow, groupOutLineStyle.GetColor() );
            Assert.AreEqual( true, groupOutLineStyle.IsEnable() );
            Assert.AreEqual( 10, groupOutLineStyle.GetLineWidth() );

            group.InsertShape( rectangle, 0 );

            Assert.AreEqual( Color.Yellow, groupOutLineStyle.GetColor() );
            Assert.AreEqual( true, groupOutLineStyle.IsEnable() );
            Assert.AreEqual( 10, groupOutLineStyle.GetLineWidth() );

            group.InsertShape( triangleGroup, 0 );

            Assert.AreEqual( Color.Yellow, groupOutLineStyle.GetColor() );
            Assert.AreEqual( true, groupOutLineStyle.IsEnable() );
            Assert.AreEqual( null, groupOutLineStyle.GetLineWidth() );
            Assert.AreEqual( Color.Yellow, triangleGroupOutLineStyle.GetColor() );
            Assert.AreEqual( true, triangleGroupOutLineStyle.IsEnable() );
            Assert.AreEqual( 12, triangleGroupOutLineStyle.GetLineWidth() );
        }

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
        public void GetFrameFromGroupWithShapesWithStandartRect()
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
        public void SetFrameToGroupWithoutShapes()
        {
            var group = new GroupShape();
            var frame = new Rect( -100, 450, -100, 250 );

            group.SetFrame( frame );

            Assert.AreEqual( null, group.GetFrame() );
        }

        [TestMethod]
        public void SetFrameWithDoubleBiggerWidthHeightToGroupWithShapes()
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
        public void SetFrameWithDoubleSmallerWidthHeightAndNegativeLeftTopToGroupWithShapes()
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

            Assert.ThrowsException<ArgumentException>( () => group.SetFrame(frame) );
        }

        [TestMethod]
        public void SetFrameWithZeroHeightWidth()
        {
            var group = new GroupShape();
            var frame = new Rect( 100, 0, 100, 0 );

            Assert.ThrowsException<ArgumentException>( () => group.SetFrame( frame ) );
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
