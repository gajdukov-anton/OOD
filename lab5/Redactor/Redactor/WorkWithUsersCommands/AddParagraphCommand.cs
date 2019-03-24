using Redactor.Document;
using System;
using System.IO;

namespace Redactor.WorkWithUsersCommands
{
    class AddParagraphCommand : WorkWithUsersCommand
    {
        IDocument _document;

        public AddParagraphCommand( IDocument document )
        {
            _document = document;
        }

        public void Execute( string commandData, TextWriter textWriter )
        {
            string [] commandArrData = commandData.Split( new char [] { ' ' }, StringSplitOptions.RemoveEmptyEntries );
            if ( commandArrData.Length < 3 )
            {
                textWriter.WriteLine( Constants.INVALID_AMOUNT_PARAMETRS_FOR_INSERT_PARAGRAPH );
                return;
            }
            int? position = commandArrData [ 1 ].ToLower() == "end" ? null : ( int? ) Convert.ToInt32( commandArrData [ 1 ] );
            if (position.HasValue && position > _document.GetItemsCount())
            {
                textWriter.WriteLine( Constants.INDEX_OUT_OF_RANGE_ERROR );
                return;
            }

            string text = GetTextFormStr( commandData, new string [] { commandArrData [ 0 ], commandArrData [ 1 ] } );
            _document.InsertParagraph( text, position );
        }

        private string GetTextFormStr(string str, string[] commandWords)
        {
            string result = str;
            int counter = 0;
            for (int i = 0; i < commandWords.Length; i++ )
            {
                for (int j = counter; j < result.Length; j++ )
                {
                    counter++;   
                    if (commandWords[i][commandWords[i].Length - 1] == str[j])
                    {
                        break;
                    }
                }
            }
            return result.Remove( 0, counter + 1 );
        }
    }
}
