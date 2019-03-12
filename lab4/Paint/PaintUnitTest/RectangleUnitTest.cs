using Microsoft.VisualStudio.TestTools.UnitTesting;
using Paint.Shapes;
using System.IO;
using Paint.UI;

namespace PaintUnitTest
{
    [TestClass]
    public class RectangleUnitTest
    {
        [TestMethod]
        public void CreateRectangle()
        {
            StringWriter stringWriter = new StringWriter();
            Canvas canvas = new Canvas( stringWriter );
            Point leftTop = new Point( 12.0, 22.0 );
            Point rightBottom = new Point( 31.0, 42.0 );
            Rectangle rectangle = new Rectangle( leftTop, rightBottom );
            rectangle.Draw( canvas );
            string result =
               "Line\r\n"
               + "From x: 12 y: 22\r\n"
               + "To x: 31 y: 22\r\n"
               + "Line\r\n"
               + "From x: 31 y: 22\r\n"
               + "To x: 31 y: 42\r\n"
               + "Line\r\n"
               + "From x: 31 y: 42\r\n"
               + "To x: 12 y: 42\r\n"
               + "Line\r\n"
               + "From x: 12 y: 42\r\n"
               + "To x: 12 y: 22\r\n";
            Assert.AreEqual( result, stringWriter.ToString() );
            Assert.AreEqual( leftTop, rectangle.GetLeftTop() );
            Assert.AreEqual( rightBottom, rectangle.GetRightBottom() );
        }
    }
}
