using Redactor.Document;
using System;
using System.IO;

namespace Redactor.WorkWithUsersCommands
{
    class SaveCommand : WorkWithUsersCommand
    {
        private IDocument _document;

        public SaveCommand(IDocument document )
        {
            _document = document;
        }

        public void Execute( string commandData, TextWriter textWriter )
        {
            string [] commandArrData = commandData.Split( new char [] { ' ' }, StringSplitOptions.RemoveEmptyEntries );
            if ( commandArrData.Length < 2 )
            {
                textWriter.WriteLine( Constants.INVALID_AMOUNT_PARAMETRS_FOR_SAVE );
                return;
            }
            string path = GetPathFormStr( commandData, new string [] { commandArrData [ 0 ] } );
            _document.Save( path );
        }

        private string GetPathFormStr( string str, string [] commandWords )
        {
            string result = str;
            int counter = 0;
            for ( int i = 0; i < commandWords.Length; i++ )
            {
                for ( int j = counter; j < result.Length; j++ )
                {
                    counter++;
                    if ( commandWords [ i ] [ commandWords [ i ].Length - 1 ] == str [ j ] )
                    {
                        break;
                    }
                }
            }
            return result.Remove( 0, counter + 1 );
        }
    }
}
