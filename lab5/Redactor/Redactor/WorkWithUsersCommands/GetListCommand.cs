using Redactor.Document;
using System.IO;

namespace Redactor.WorkWithUsersCommands
{
    class GetListCommand : WorkWithUsersCommand
    {
        IDocument _document;

        public GetListCommand( IDocument document )
        {
            _document = document;
        }

        public void Execute( string commandData, TextWriter textWriter )
        {
            textWriter.WriteLine( $"Title: {_document.GetTitle().Value}" );
            for (int i = 0; i < _document.GetItemsCount(); i++ )
            {
                if (_document.GetItem(i).Paragraph != null)
                {
                    textWriter.WriteLine( $"{i}. Paragraph: {_document.GetItem( i ).Paragraph.GetText()}" );
                }
                else
                {
                    textWriter.WriteLine( $"{i}. Image: {_document.GetItem( i ).Image.GetWidth()}x{_document.GetItem( i ).Image.GetHeight()} {_document.GetItem( i ).Image.GetPath().ToString()}" );
                }
            }
        }
    }
}
