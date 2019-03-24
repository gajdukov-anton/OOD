using Redactor.Document;
using System.Collections.Generic;
using System.IO;

namespace Redactor.Utils
{
    public class DocumentItemSaver
    {
        private StreamWriter _streamWriter;
        public DocumentItemSaver()
        {
        }

        public void Save( List<DocumentItem> documentItems, StreamWriter streamWriter )
        {
            _streamWriter = streamWriter;
            foreach(var item in documentItems)
            {
                if (item.Image != null)
                {
                    SaveImage( item.Image );
                }
                else
                {
                    SaveParagraph( item.Paragraph );
                }
            }
        }

        private void SaveImage( IImage image )
        {

        }

        private void SaveParagraph( IParagraph paragraph )
        {
            _streamWriter.WriteLine( "<p>" );
            _streamWriter.WriteLine( $"  {paragraph.GetText()}" );
            _streamWriter.WriteLine( "</p>" );
        }
    }
}
