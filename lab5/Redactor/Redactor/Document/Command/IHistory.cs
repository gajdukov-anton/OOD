namespace Redactor.Document.Command
{
    public interface IHistory : IMainHistoryCommands
    {
        bool CanUndo();
        bool CanRedo();
        void Undo();
        void Redo();
    }
}
