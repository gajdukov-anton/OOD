using Microsoft.VisualStudio.TestTools.UnitTesting;
using Paint.Shapes;
using System.IO;
using Paint.UI;

namespace PaintUnitTest
{
    [TestClass]
    public class RegularPolygonUnitTest
    {
        [TestMethod]
        public void CreateRegularPolygonTest()
        {
            StringWriter stringWriter = new StringWriter();
            Canvas canvas = new Canvas( stringWriter );
            Point center = new Point( 1.0, 1.0 );
            RegularPolygon regularPolygon = new RegularPolygon( center, 2, 1 );
            regularPolygon.Draw( canvas );
            string result = 
                "Line\r\n"
                + "From x: 2 y: 1\r\n"
                + "To x: 0 y: 1\r\n"
                + "Line\r\n"
                + "From x: 0 y: 1\r\n"
                + "To x: 2 y: 1\r\n";
            Assert.AreEqual( result, stringWriter.ToString() );
            Assert.AreEqual( center, regularPolygon.GetCenter() );
            Assert.AreEqual( 2, regularPolygon.GetVertexCount() );
            Assert.AreEqual( 1, regularPolygon.GetRadius() );
        }
    }
}
