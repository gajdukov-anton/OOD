using Redactor.Document;

namespace Redactor.Document.Command
{
    public class ReplaceTextCommand : ICommand
    {
        private string _newText = "";
        private string _previousText = "";
        private StringRepresentation _stringRepresentation;

        public ReplaceTextCommand(StringRepresentation stringRepresentation,  string text)
        {
            _stringRepresentation = stringRepresentation;
            _newText = text;
        }

        public void Dispose()
        {
        }

        public void Execute()
        {   
            _previousText = _stringRepresentation.Value;
            _stringRepresentation.Value = _newText;
        }

        public void Unexecute()
        {
            _stringRepresentation.Value = _previousText;
        }
    }
}
