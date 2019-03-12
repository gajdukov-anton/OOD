using Paint.Factory;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Paint.Shapes;
using System;

namespace PaintUnitTest
{
    [TestClass]
    public class ShapeFactoryUnitTest
    {
        [TestMethod]
        public void CreateShapeTest_CreateTriangle()
        {
            string triangleDescription = "Triangle black 12 22 31 42 57 55";
            ShapeFactory shapeFactory = new ShapeFactory();
            Shape triangle = shapeFactory.CreateShape( triangleDescription );
            Triangle triangleExample = new Triangle(
                new Point( 12.0, 22.0 ),
                new Point( 31.0, 42.0 ),
                new Point( 57.0, 55.0 ) );
            Assert.IsTrue( AreSameTriangles( ( Triangle ) triangle, triangleExample ) );
        }

        [TestMethod]
        public void CreateShapeTest_CreateTriangleWithIncorrectParams()
        {
            string triangleDescription = "Triangle  12 22 31 42 57 55";
            ShapeFactory shapeFactory = new ShapeFactory();
            Assert.ThrowsException<ArgumentException>( () => shapeFactory.CreateShape( triangleDescription ) );
            triangleDescription = "Triangle blackccc 12 22 31 42 57 55";
            shapeFactory = new ShapeFactory();
            Assert.ThrowsException<ArgumentException>( () => shapeFactory.CreateShape( triangleDescription ) );
            triangleDescription = "Triangle blackccc 12 qw 31 42 57 55";
            shapeFactory = new ShapeFactory();
            Assert.ThrowsException<ArgumentException>( () => shapeFactory.CreateShape( triangleDescription ) );
        }

        [TestMethod]
        public void CreateShapeTest_CreateRectangle()
        {
            string rectangleDescription = "Rectangle black 12 22 31 42";
            ShapeFactory shapeFactory = new ShapeFactory();
            Shape rectangle = shapeFactory.CreateShape( rectangleDescription );
            Rectangle rectangleExample = new Rectangle(
                new Point( 12.0, 22.0 ),
                new Point( 31.0, 42.0 ) );
            Assert.IsTrue( AreSameRectangle( ( Rectangle ) rectangle, rectangleExample ) );
        }

        [TestMethod]
        public void CreateShapeTest_CreateRectangleWithIncorrectParams()
        {
            string rectangleDescription = "Rectangle  12 22 31 42";
            ShapeFactory shapeFactory = new ShapeFactory();
            Assert.ThrowsException<ArgumentException>( () => shapeFactory.CreateShape( rectangleDescription ) );
            rectangleDescription = "Rectangle advdav 12 22 31 42";
            shapeFactory = new ShapeFactory();
            Assert.ThrowsException<ArgumentException>( () => shapeFactory.CreateShape( rectangleDescription ) );
            rectangleDescription = "Rectangle black w 22 31 42";
            shapeFactory = new ShapeFactory();
            Assert.ThrowsException<FormatException>( () => shapeFactory.CreateShape( rectangleDescription ) );
        }

        [TestMethod]
        public void CreateShapeTest_CreateEllipse()
        {
            string ellipseDescription = "Ellipse black 12 22 31 42";
            ShapeFactory shapeFactory = new ShapeFactory();
            Shape ellipse = shapeFactory.CreateShape( ellipseDescription );
            Ellipse ellipseExample = new Ellipse( new Point( 12.0, 22.0 ), 31.0, 42.0 );
            Assert.IsTrue( AreSameEllipse( ( Ellipse ) ellipse, ellipseExample ) );
        }

        [TestMethod]
        public void CreateShapeTest_CreateEllipseWithIncorrectParams()
        {
            string ellipseDescription = "Ellipse  12 22 31 42";
            ShapeFactory shapeFactory = new ShapeFactory();
            Assert.ThrowsException<ArgumentException>( () => shapeFactory.CreateShape( ellipseDescription ) );
            ellipseDescription = "Ellipse advdav 12 22 31 42";
            shapeFactory = new ShapeFactory();
            Assert.ThrowsException<ArgumentException>( () => shapeFactory.CreateShape( ellipseDescription ) );
            ellipseDescription = "Ellipse black w 22 31 42";
            shapeFactory = new ShapeFactory();
            Assert.ThrowsException<FormatException>( () => shapeFactory.CreateShape( ellipseDescription ) );
        }

        [TestMethod]
        public void CreateShapeTest_CreateRegularPolygon()
        {
            string regularPolygonDescription = "RegularPolygon black 12 22 31 42";
            ShapeFactory shapeFactory = new ShapeFactory();
            Shape regularPolygon = shapeFactory.CreateShape( regularPolygonDescription );
            RegularPolygon regularPolygonExample = new RegularPolygon( new Point( 12.0, 22.0 ), 31, 42.0 );
            Assert.IsTrue( AreSameRegularPolygon( ( RegularPolygon ) regularPolygon, regularPolygonExample ) );
        }

        [TestMethod]
        public void CreateShapeTest_CreateRegularPolygonWithIncorrectParams()
        {
            string ellipseDescription = "RegularPolygon  12 22 31 42";
            ShapeFactory shapeFactory = new ShapeFactory();
            Assert.ThrowsException<ArgumentException>( () => shapeFactory.CreateShape( ellipseDescription ) );
            ellipseDescription = "RegularPolygon advdav 12 22 31 42";
            shapeFactory = new ShapeFactory();
            Assert.ThrowsException<ArgumentException>( () => shapeFactory.CreateShape( ellipseDescription ) );
            ellipseDescription = "RegularPolygon black w 22 31 42";
            shapeFactory = new ShapeFactory();
            Assert.ThrowsException<FormatException>( () => shapeFactory.CreateShape( ellipseDescription ) );
        }

        private bool AreSameTriangles( Triangle triangle1, Triangle triangle2 )
        {
            return triangle1.GetColor() == triangle2.GetColor()
                && triangle1.GetVertex1().X == triangle2.GetVertex1().X
                && triangle1.GetVertex1().Y == triangle2.GetVertex1().Y
                && triangle1.GetVertex2().X == triangle2.GetVertex2().X
                && triangle1.GetVertex2().Y == triangle2.GetVertex2().Y
                && triangle1.GetVertex3().X == triangle2.GetVertex3().X
                && triangle1.GetVertex3().Y == triangle2.GetVertex3().Y;
        }

        private bool AreSameRectangle( Rectangle rectangle1, Rectangle rectangle2 )
        {
            return rectangle1.GetColor() == rectangle2.GetColor()
                && rectangle1.GetLeftTop().X == rectangle2.GetLeftTop().X
                && rectangle1.GetLeftTop().Y == rectangle2.GetLeftTop().Y
                && rectangle1.GetRightBottom().X == rectangle2.GetRightBottom().X
                && rectangle1.GetRightBottom().Y == rectangle2.GetRightBottom().Y;
        }

        private bool AreSameEllipse( Ellipse ellipse1, Ellipse ellipse2 )
        {
            return ellipse1.GetColor() == ellipse1.GetColor()
                && ellipse1.GetCenter().X == ellipse1.GetCenter().X
                && ellipse1.GetCenter().Y == ellipse1.GetCenter().Y
                && ellipse1.GetHorizontalRadius() == ellipse1.GetHorizontalRadius()
                && ellipse1.GetVerticalRadius() == ellipse1.GetVerticalRadius();
        }

        private bool AreSameRegularPolygon( RegularPolygon regularPolygon1, RegularPolygon regularPolygon2 )
        {
            return regularPolygon1.GetColor() == regularPolygon2.GetColor()
                && regularPolygon1.GetCenter().X == regularPolygon2.GetCenter().X
                && regularPolygon1.GetCenter().Y == regularPolygon2.GetCenter().Y
                && regularPolygon1.GetVertexCount() == regularPolygon2.GetVertexCount()
                && regularPolygon1.GetRadius() == regularPolygon2.GetRadius();
        }
    }
}
