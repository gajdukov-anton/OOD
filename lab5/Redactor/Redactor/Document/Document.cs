using Redactor.Document.Command;
using Redactor.Utils;
using System;
using System.Collections.Generic;
using System.IO;

namespace Redactor.Document
{
    public class Document : IDocument
    {
        private List<DocumentItem> _items;
        private StringRepresentation _title;
        private IHistory _history;

        public Document()
        {
            _items = new List<DocumentItem>();
            _history = new History();
            _title = new StringRepresentation();
        }

        public bool CanRedo()
        {
            return _history.CanRedo();
        }

        public bool CanUndo()
        {
            return _history.CanUndo();
        }

        public void DeleteItem( int index )
        {
            _history.AddAndExecuteCommand( new DeleteItemCommand( _items, index ) );
        }

        public IHistory GetHistory()
        {
            return _history;
        }

        public DocumentItem GetItem( int index )
        {
            return index >= _items.Count || index < 0 ? throw new IndexOutOfRangeException() : _items [ index ];
        }

        public int GetItemsCount()
        {
            return _items.Count;
        }

        public StringRepresentation GetTitle()
        {
            return _title;
        }

        public IImage InsertImage( string path, int width, int height, int? position = null )
        {
            IImage image = new CustomImage( height, width, path );
            _history.AddAndExecuteCommand( new InsertImageCommand( _items, image, position ) );
            return image;
        }

        public IParagraph InsertParagraph( string text, int? position = null )
        {
            IParagraph paragraph = new Paragraph( text );
            _history.AddAndExecuteCommand( new InsertParagraphCommand( _items, paragraph, position ) );
            return paragraph;
        }

        public void Redo()
        {
            _history.Redo();
        }

        public void Save( string path )
        {
            StreamWriter streamWriter = new StreamWriter( path );
            DocumentItemSaver saver = new DocumentItemSaver();
            streamWriter.WriteLine( "<html>" );
            streamWriter.WriteLine( "<head>" );
            streamWriter.WriteLine( $"  <title>{GetTitle().Value}</title>" );
            streamWriter.WriteLine( "</head>" );
            streamWriter.WriteLine( "<body>" );
            saver.Save( _items, streamWriter );
            streamWriter.WriteLine( "</body>" );
            streamWriter.WriteLine( "</html>" );
            streamWriter.Close();
        }

        public void SetTitle( string title )
        {
            _history.AddAndExecuteCommand( new SetTitleCommand( title, _title ) );
        }

        public void Undo()
        {
            _history.Undo();
        }
    }
}
