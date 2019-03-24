using Redactor.Document;
using System;
using System.IO;

namespace Redactor.WorkWithUsersCommands
{
    public class AddRedoCommand : WorkWithUsersCommand
    {
        private IDocument _document;

        public AddRedoCommand(IDocument document)
        {
            _document = document;
        }

        public void Execute( string commandData, TextWriter textWriter )
        {
            if (_document.CanRedo())
            {
                _document.Redo();
            }
            else
            {
                textWriter.WriteLine( Constants.IMPOSSIBLE_TO_REDO );
            }
        }
    }
}
