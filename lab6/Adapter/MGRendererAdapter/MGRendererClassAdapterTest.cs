using System;
using System.IO;
using Adapter.Application;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdapterUnitTest
{
    [TestClass]
    public class MGRendererClassAdapterTest
    {
        [TestMethod]
        public void BeginEndDrowTest()
        {
            StringWriter stringWriter = new StringWriter();
            StringWriter resultStringWriter = new StringWriter();
            using ( var adapter = new MGREndererClassAdapter( stringWriter ) )
            {
                adapter.BeginDraw();
            }
            resultStringWriter.WriteLine( "<draw>" );
            resultStringWriter.WriteLine( "</draw>" );
            Assert.AreEqual( resultStringWriter.ToString(), stringWriter.ToString() );
        }

        [TestMethod]
        public void MoveToTest()
        {
            StringWriter stringWriter = new StringWriter();
            StringWriter resultStringWriter = new StringWriter();
            using ( var adapter = new MGREndererClassAdapter( stringWriter ) )
            {
                adapter.BeginDraw();
                adapter.MoveTo( 12, 19 );
                Assert.AreEqual( 12, adapter.LatsPoint.X );
                Assert.AreEqual( 19, adapter.LatsPoint.Y );
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
            using ( var adapter = new MGREndererClassAdapter( stringWriter ) )
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
            using ( var adapter = new MGREndererClassAdapter( stringWriter ) )
            {
                adapter.BeginDraw();
                adapter.SetColor( 0xADFF2F );
                adapter.MoveTo( 5, 5 );
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
