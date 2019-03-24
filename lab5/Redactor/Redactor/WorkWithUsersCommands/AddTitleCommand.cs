using Redactor.Document;
using System;
using System.IO;

namespace Redactor.WorkWithUsersCommands
{
    class AddTitleCommand : WorkWithUsersCommand
    {
        IDocument _document;

        public AddTitleCommand( IDocument document )
        {
            _document = document;
        }

        public void Execute( string commandData, TextWriter textWriter )
        {
            string [] commandArrData = commandData.Split( new char [] { ' ' }, StringSplitOptions.RemoveEmptyEntries );
            if ( commandArrData.Length < 2 )
            {
                textWriter.WriteLine( Constants.INVALID_AMOUNT_PARAMETRS_FOR_SET_TITLE );
                return;
            }
            string text = commandData.Remove(0, commandArrData[0].Length);
            _document.SetTitle( text );
        }
    }
}
