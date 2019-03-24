using Redactor.Command;

namespace Redactor.Utils
{
    public interface IHistory
    {
        bool CanUndo();
        bool CanRedo();
        void Undo();
        void Redo();
        void AddAndExecuteCommand( ICommand command );
    }
}
