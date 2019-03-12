using Microsoft.VisualStudio.TestTools.UnitTesting;
using Paint.Shapes;
using Paint.UI;
using System.IO;

namespace PaintUnitTest
{
    [TestClass]
    public class TriangleUnitTest
    {
        [TestMethod]
        public void CreateTriangleTest()
        {
            StringWriter stringWriter = new StringWriter();
            Point vertex1 = new Point( 12.0, 22.0 );
            Point vertex2 = new Point( 31.0, 42.0 );
            Point vertex3 = new Point( 57.0, 55.0 );
            Triangle triangle = new Triangle(vertex1, vertex2, vertex3);
            Canvas canvas = new Canvas( stringWriter );
            triangle.Draw( canvas );
            string result = 
                "Line\r\n"
                + "From x: 12 y: 22\r\n"
                + "To x: 31 y: 42\r\n"
                + "Line\r\n"
                + "From x: 31 y: 42\r\n"
                + "To x: 57 y: 55\r\n"
                + "Line\r\n"
                + "From x: 57 y: 55\r\n"
                + "To x: 12 y: 22\r\n";
            string str = stringWriter.ToString();
            Assert.AreEqual( result, str );
            Assert.AreEqual( vertex1, triangle.GetVertex1() );
            Assert.AreEqual( vertex2, triangle.GetVertex2() );
            Assert.AreEqual( vertex3, triangle.GetVertex3() );
        }
    }
}
