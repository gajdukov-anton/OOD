using Redactor.Document;

namespace Redactor.Command
{
    public class ReplaceTextCommand : ICommand
    {
        private string _newText = "";
        private string _previousText = "";
        private DocumentItem _documentItem;

        public ReplaceTextCommand(DocumentItem documentItem,  string text)
        {
            _documentItem = documentItem;
            _newText = text;
        }

        public void Execute()
        {
            IParagraph paragraph = _documentItem.Paragraph;
            _previousText = paragraph.GetText();
            paragraph.SetText( _newText );
        }

        public void Unexecute()
        {
            IParagraph paragraph = _documentItem.Paragraph;
            paragraph.SetText( _previousText );
        }
    }
}
