namespace Redactor.Document.Command
{
    public interface IMainHistoryCommands
    {
        void AddAndExecuteCommand( ICommand command );
    }
}
