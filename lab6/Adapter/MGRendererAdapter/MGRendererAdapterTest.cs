using System.IO;
using Adapter.ModernGraphicsLib;
using Adapter.Application;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdapterUnitTest
{
    [TestClass]
    public class MGRendererAdapterTest
    {
        [TestMethod]
        public void MoveToTest()
        {
            StringWriter stringWriter = new StringWriter();
            StringWriter resultStringWriter = new StringWriter();
            var renderer = new ModernGraphicsRenderer( stringWriter );
            using ( var adapter = new MGRendererAdapter( renderer ) )
            {
                adapter.BeginDraw();
                adapter.MoveTo( 0, 0 );
            }
            resultStringWriter.WriteLine( "<draw>" );
            resultStringWriter.WriteLine( "</draw>" );
            Assert.AreEqual( resultStringWriter.ToString(), stringWriter.ToString() );
        }

        [TestMethod]
        public void LineToWithDefaultColorTest()
        {
            StringWriter stringWriter = new StringWriter();
            StringWriter resultStringWriter = new StringWriter();
            var renderer = new ModernGraphicsRenderer( stringWriter );
            using ( var adapter = new MGRendererAdapter( renderer ) )
            {
                adapter.BeginDraw();
                adapter.MoveTo( 5, 5 );
                adapter.LineTo( 10, 10 );
            }
            resultStringWriter.WriteLine( "<draw>" );
            resultStringWriter.WriteLine( "<line fromX=5 fromY=5 toX=10 toY=10>" );
            resultStringWriter.WriteLine( "  <color r=\"0\" g=\"0\" b=\"0\" a=\"0\" />" );
            resultStringWriter.WriteLine( "</line>" );
            resultStringWriter.WriteLine( "</draw>" );
            Assert.AreEqual( resultStringWriter.ToString(), stringWriter.ToString() );
        }

        [TestMethod]
        public void LineToWithColorTest()
        {
            StringWriter stringWriter = new StringWriter();
            StringWriter resultStringWriter = new StringWriter();
            var renderer = new ModernGraphicsRenderer( stringWriter );
            using ( var adapter = new MGRendererAdapter( renderer ) )
            {
                adapter.BeginDraw();
                adapter.MoveTo( 5, 5 );
                adapter.SetColor( 0xADFF2F );
                adapter.LineTo( 10, 10 );
            }
            resultStringWriter.WriteLine( "<draw>" );
            resultStringWriter.WriteLine( "<line fromX=5 fromY=5 toX=10 toY=10>" );
            resultStringWriter.WriteLine( "  <color r=\"173\" g=\"255\" b=\"47\" a=\"0\" />" );
            resultStringWriter.WriteLine( "</line>" );
            resultStringWriter.WriteLine( "</draw>" );
            Assert.AreEqual( resultStringWriter.ToString(), stringWriter.ToString() );
        }
    }
}
