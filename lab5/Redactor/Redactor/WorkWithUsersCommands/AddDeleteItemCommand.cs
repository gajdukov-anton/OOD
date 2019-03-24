using Redactor.Document;
using System;
using System.IO;

namespace Redactor.WorkWithUsersCommands
{
    public class AddDeleteItemCommand : WorkWithUsersCommand
    {
        private IDocument _document;

        public AddDeleteItemCommand(IDocument document)
        {
            _document = document; 
        }

        public void Execute( string commandData, TextWriter textWriter )
        {
            string [] commandArrData = commandData.Split( new char [] { ' ' }, StringSplitOptions.RemoveEmptyEntries );
            if ( commandArrData.Length < 2 )
            {
                textWriter.WriteLine( Constants.INVALID_AMOUNT_PARAMETRS_FOR_DELETE_ITEM);
                return;
            }
            int? index = commandArrData [ 1 ].ToLower() == "end" ? null : ( int? ) Convert.ToInt32( commandArrData [ 1 ] );
            if (index >= _document.GetItemsCount())
            {
                textWriter.WriteLine( Constants.INDEX_OUT_OF_RANGE_ERROR );
                return;
            }
            _document.DeleteItem( ( int ) index );
        }
    }
}
