using Redactor.Document;

namespace Redactor.Command
{
    public class SetTitleCommand : ICommand
    {
        private string _newTitleValue;
        private string _previousTitleValue;
        private Title _title;

        public SetTitleCommand(string newTitleValue, Title title)
        {
            _newTitleValue = newTitleValue;
            _title = title; 
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
