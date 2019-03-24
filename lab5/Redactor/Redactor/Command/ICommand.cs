namespace Redactor.Command
{
    public interface ICommand
    {
        void Execute();
        void Unexecute();
    }
}
