using Redactor.Document;
using System;
using System.IO;

namespace Redactor.WorkWithUsersCommands
{
    public class AddUndoCommand : WorkWithUsersCommand
    {
        private IDocument _document;

        public AddUndoCommand( IDocument document )
        {
            _document = document;
        }

        public void Execute( string commandData, TextWriter textWriter )
        {
            if ( _document.CanUndo() )
            {
                _document.Undo();
            }
            else
            {
                textWriter.WriteLine( Constants.IMPOSSIBLE_TO_UNDO );
            }

        }
    }
}
