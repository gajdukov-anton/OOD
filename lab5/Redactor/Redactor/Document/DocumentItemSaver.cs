using Redactor.Document;
using System.Collections.Generic;
using Redactor.Utils;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
namespace Redactor.Utils
{
    public class DocumentItemSaver
    {
        private StreamWriter _streamWriter;
        private StringFunctions _stringFunctions;

        public DocumentItemSaver()
        {
            _stringFunctions = new StringFunctions();
        }

        public void Save( List<DocumentItem> documentItems, StreamWriter streamWriter )
        {
            _streamWriter = streamWriter;
            foreach ( var item in documentItems )
            {
                if ( item.Image != null )
                {
                    SaveImage( item.Image );
                }
                else
                {
                    SaveParagraph( item.Paragraph );
                }
            }
        }

        private void SaveImage( IImage imageForSave )
        {
            _streamWriter.WriteLine( $"<img src=\"{imageForSave.GetPath()}\" width=\"{imageForSave.GetWidth()}\" height=\"{imageForSave.GetHeight()}\">" );
        }

        private void SaveParagraph( IParagraph paragraph )
        {
            _streamWriter.WriteLine( "<p>" );
            _streamWriter.WriteLine( $"  {_stringFunctions.EncodeHtmlSymbols( paragraph.GetText())}" );
            _streamWriter.WriteLine( "</p>" );
        }
    }
}
