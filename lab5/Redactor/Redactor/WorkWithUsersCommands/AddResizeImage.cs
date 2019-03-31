using Redactor.Document;
using System;
using System.IO;

namespace Redactor.WorkWithUsersCommands
{
    class AddResizeImage : WorkWithUsersCommand
    {
        private IDocument _document;

        public AddResizeImage( IDocument document )
        {
            _document = document;
        }

        public void Execute( string commandData, TextWriter textWriter )
        {
            string [] commandArrData = commandData.Split( new char [] { ' ' }, StringSplitOptions.RemoveEmptyEntries );
            if ( commandArrData.Length < 4 )
            {
                textWriter.WriteLine( Constants.INVALID_AMOUNT_PARAMETRS_FOR_RESIZE_IMAGE );
                return;
            }
            int? index = commandArrData [ 1 ].ToLower() == "end" ? null : ( int? ) Convert.ToInt32( commandArrData [ 1 ] );
            if ( index.HasValue && index >= _document.GetItemsCount() || _document.GetItemsCount() == 0)
            {
                textWriter.WriteLine( Constants.INDEX_OUT_OF_RANGE_ERROR );
                return;
            }
            if ( _document.GetItem( index.HasValue ? ( int ) index : 0 ).Image == null )
            {
                textWriter.WriteLine( Constants.IT_IS_NOT_IMAGE );
                return;
            }
            var item = _document.GetItem( index.HasValue ? ( int ) index : 0 );
            item.Image.Resize( Convert.ToInt32( commandArrData [ 2 ] ), Convert.ToInt32( commandArrData [ 3 ] ), _document.GetHistory() );
        }
    }
}
