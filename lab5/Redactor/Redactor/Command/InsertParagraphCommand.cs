using Redactor.Document;
using System.Collections.Generic;

namespace Redactor.Command
{
    public class InsertParagraphCommand : ICommand
    {
        private List<DocumentItem> _items;
        private IParagraph _paragraph;
        private int? _position;

        public InsertParagraphCommand( List<DocumentItem> items, IParagraph paragraph, int? position )
        {
            _items = items;
            _paragraph = paragraph;
            _position = position;
        }
        public void Execute()
        {
            if ( !_position.HasValue || _position > _items.Count )
            {
                _items.Add( new DocumentItem( _paragraph ) );
            }
            else if ( _position >= 0 )
            {
                _items.Insert( ( int ) _position, new DocumentItem( _paragraph ) );
            }
        }

        public void Unexecute()
        {
            if ( !_position.HasValue )
            {
                _items.RemoveAt( _items.Count - 1 );
            }
            else
            {
                _items.RemoveAt( ( int ) _position );
            }
        }
    }
}
