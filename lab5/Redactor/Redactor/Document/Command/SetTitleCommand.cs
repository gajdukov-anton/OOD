using Redactor.Document;

namespace Redactor.Document.Command
{
    public class SetTitleCommand : ICommand
    {
        private string _newTitleValue;
        private string _previousTitleValue;
        private StringRepresentation _title;

        public SetTitleCommand(string newTitleValue, StringRepresentation title)
        {
            _newTitleValue = newTitleValue;
            _title = title; 
        }

        public void Dispose()
        {
        }

        public void Execute()
        {
            _previousTitleValue = _title.Value;
            _title.Value = _newTitleValue;
        }

        public void Unexecute()
        {
            _title.Value = _previousTitleValue;
        }
    }
}
