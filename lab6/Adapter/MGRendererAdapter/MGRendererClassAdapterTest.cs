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
        public void BeginDrawTest()
        {
            StringWriter stringWriter = new StringWriter();
            StringWriter resultStringWriter = new StringWriter();
            using ( var adapterOne = new MGREndererClassAdapter( stringWriter ) )
            {
                adapterOne.BeginDraw();
            }
            resultStringWriter.WriteLine( "<draw>" );
            resultStringWriter.WriteLine( "</draw>" );
            Assert.AreEqual( resultStringWriter.ToString(), stringWriter.ToString() );
            var adapterTwo = new MGREndererClassAdapter( stringWriter );
            adapterTwo.BeginDraw();
            Assert.ThrowsException<Exception>( () => adapterTwo.BeginDraw() );
        }

        [TestMethod]
        public void EndDrawTest()
        {
            StringWriter stringWriter = new StringWriter();
            StringWriter resultStringWriter = new StringWriter();
            using ( var adapterOne = new MGREndererClassAdapter( stringWriter ) )
            {
                adapterOne.BeginDraw();
            }
            resultStringWriter.WriteLine( "<draw>" );
            resultStringWriter.WriteLine( "</draw>" );
            Assert.AreEqual( resultStringWriter.ToString(), stringWriter.ToString() );
            var adapterTwo = new MGREndererClassAdapter( stringWriter );
            adapterTwo.BeginDraw();
            adapterTwo.EndDraw();
            Assert.ThrowsException<Exception>( () => adapterTwo.EndDraw() );
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
            }
            resultStringWriter.WriteLine( "<draw>" );
            resultStringWriter.WriteLine( "</draw>" );
            Assert.AreEqual( resultStringWriter.ToString(), stringWriter.ToString() );
        }

        [TestMethod]
        public void LineToWithoutBeginDrawTest()
        {
            StringWriter stringWriter = new StringWriter();
            var renderer = new MGREndererClassAdapter( stringWriter );
            var adapter = new MGRendererAdapter( renderer );
            Assert.ThrowsException<Exception>( () => adapter.LineTo( 0 , 0) );
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
