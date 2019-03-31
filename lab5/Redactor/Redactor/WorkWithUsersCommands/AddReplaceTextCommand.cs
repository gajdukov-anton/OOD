using Redactor.Document;
using System;
using System.IO;

namespace Redactor.WorkWithUsersCommands
{
    public class AddReplaceTextCommand : WorkWithUsersCommand
    {
        private IDocument _document;

        public AddReplaceTextCommand( IDocument document )
        {
            _document = document;
        }

        public void Execute( string commandData, TextWriter textWriter )
        {
            string [] commandArrData = commandData.Split( new char [] { ' ' }, StringSplitOptions.RemoveEmptyEntries );
            if ( commandArrData.Length < 3 )
            {
                textWriter.WriteLine( Constants.INVALID_AMOUNT_PARAMETRS_FOR_REPLACE_TEXT );
                return;
            }
            int? index = commandArrData [ 1 ].ToLower() == "end" ? null : ( int? ) Convert.ToInt32( commandArrData [ 1 ] );
            if ( index.HasValue && index >= _document.GetItemsCount() )
            {
                textWriter.WriteLine( Constants.INDEX_OUT_OF_RANGE_ERROR );
                return;
            }
            if ( _document.GetItem( ( int ) index ).Paragraph == null )
            {
                textWriter.WriteLine( Constants.IT_IS_NOT_PARAGRAPH );
                return;
            }
            string text = GetTextFormStr( commandData, new string [] { commandArrData [ 0 ], commandArrData [ 1 ] } );
            var item = _document.GetItem( ( int ) index );
            item.Paragraph.SetText( text, _document.GetHistory() );
        }

        private string GetTextFormStr( string str, string [] commandWords )
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
