using Redactor.Document;
using System.Collections.Generic;

namespace Redactor.Document.Command
{
    public class DeleteItemCommand : ICommand
    {
        private List<DocumentItem> _documentItems;
        private int _index;
        private DocumentItem _documentItem;

        public DeleteItemCommand(List<DocumentItem> documentItems, int index)
        {
            _documentItems = documentItems;
            _index = index;
        }

        public void Dispose()
        {
            if (_documentItem.Image != null)
            {
                _documentItem.Image.Dispose();
            }
        }

        public void Execute()
        {
            _documentItem = _documentItems [ _index ];
            _documentItems.RemoveAt( _index );
        }

        public void Unexecute()
        {
            _documentItems.Insert( _index, _documentItem );
        }
    }
}
