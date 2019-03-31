using Redactor.Document.Command;

namespace Redactor.Document
{
    public interface IParagraph
    {
        string GetText();
        void SetText( string text, IMainHistoryCommands history );
    }
}
