using Redactor.Document;
using System.Collections.Generic;

namespace Redactor.Document.Command
{
    public class InsertImageCommand : ICommand
    {
        private List<DocumentItem> _items;
        private IImage _image;
        private int? _position;

        public InsertImageCommand(List<DocumentItem> items, IImage image, int? position)
        {
            _items = items;
            _image = image;
            _position = position;
        }

        public void Dispose()
        {
            _image.Dispose();
        }

        public void Execute()
        {
            if ( !_position.HasValue || _position > _items.Count )
            {
                _items.Add( new DocumentItem( _image ) );
            }
            else if ( _position >= 0 )
            {
                _items.Insert( ( int ) _position, new DocumentItem( _image ) );
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
