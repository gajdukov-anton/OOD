using Redactor.Document.Command;

namespace Redactor.Document
{
    class Paragraph : IParagraph
    {
        private StringRepresentation _stringRepresentation = new StringRepresentation();

        public Paragraph( string text )
        {
            _stringRepresentation.Value = text;
        }
        public string GetText()
        {
            return _stringRepresentation.Value;
        }

        public void SetText( string text, IMainHistoryCommands history )
        {
            history.AddAndExecuteCommand( new ReplaceTextCommand( _stringRepresentation, text ) );
        }
    }
}
