using Redactor.Document;
using System;
using System.IO;

namespace Redactor.WorkWithUsersCommands
{
    public class AddImageCommand : WorkWithUsersCommand
    {
        private IDocument _document;

        public AddImageCommand( IDocument document )
        {
            _document = document;
        }

        public void Execute( string commandData, TextWriter textWriter )
        {
            string [] commandArrData = commandData.Split( new char [] { ' ' }, StringSplitOptions.RemoveEmptyEntries );
            if ( commandArrData.Length < 5 )
            {
                textWriter.WriteLine( Constants.INVALID_AMOUNT_PARAMETRS_FOR_INSERT_IMAGE );
                return;
            }
            FileInfo fileInf = new FileInfo( commandArrData [ 4 ] );
            if (!fileInf.Exists)
            {
                textWriter.WriteLine( Constants.FILE_IS_NOT_EXIST );
                return;
            }
            int? position = commandArrData [ 1 ].ToLower() == "end" ? null : ( int? ) Convert.ToInt32( commandArrData [ 1 ] );
            if ( position.HasValue && position > _document.GetItemsCount() )
            {
                textWriter.WriteLine( Constants.INDEX_OUT_OF_RANGE_ERROR );
                return;
            }
            _document.InsertImage( commandArrData [ 4 ], Convert.ToInt32( commandArrData [ 2 ] ), Convert.ToInt32( commandArrData [ 3 ] ), position );

        }
    }
}
