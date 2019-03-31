using System.Collections.Generic;

namespace Redactor.Utils
{
    public class StringFunctions
    {
        private readonly Dictionary<string, string> specSymbols = new Dictionary<string, string>()
        {
            { "<", "&lt;"},
            { ">", "&gt;"},
            { "\"", "&quot;"},
            { "'", "&#039;"},
            {"&", "&amp;" }
        };

        public string EncodeHtmlSymbols( string text )
        {
            string result = "";
            foreach ( var symbol in text )
            {
                result += specSymbols.ContainsKey( symbol.ToString() ) ? specSymbols [ symbol.ToString() ] : symbol.ToString();
            }
            return result;
        }
    }
}
