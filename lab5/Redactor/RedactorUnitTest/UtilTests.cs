using Microsoft.VisualStudio.TestTools.UnitTesting;
using Redactor.Utils;

namespace RedactorUnitTest
{
    [TestClass]
    public class UtilTests
    {
        [TestMethod]
        public void EncodeHtmlSymbolsTest()
        {
            string str = "<p> &lol \" \'";
            string result = "&lt;p&gt; &amp;lol &quot; &#039;";
            StringFunctions stringFunctions = new StringFunctions();
            Assert.AreEqual( result, stringFunctions.EncodeHtmlSymbols( str ) );
        }
    }
}
