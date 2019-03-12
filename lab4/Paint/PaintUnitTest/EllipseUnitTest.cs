using Microsoft.VisualStudio.TestTools.UnitTesting;
using Paint.Shapes;
using System.IO;
using Paint.UI;

namespace PaintUnitTest
{
    [TestClass]
    public class EllipseUnitTest
    {
        [TestMethod]
        public void CreateEllipse()
        {

            StringWriter stringWriter = new StringWriter();
            Canvas canvas = new Canvas( stringWriter );
            Point center = new Point( 12.0, 22.0 );
            Ellipse ellipse = new Ellipse( center, 12, 12 );
            center.X = 0;
            center.Y = 0;
            ellipse.Draw( canvas );
            string result = 
               "Ellipse\r\n"
               + "Left: 12\r\n"
               + "Top: 22\r\n"
               + "Width: 24\r\n"
               + "Height: 24\r\n";
            center.X = 12.0;
            center.Y = 22.0;
            Assert.AreEqual( result, stringWriter.ToString() );
            Assert.AreEqual( center, ellipse.GetCenter() );
            Assert.AreEqual( 12, ellipse.GetHorizontalRadius() );
            Assert.AreEqual( 12, ellipse.GetVerticalRadius() );
        }
    }
}
