using System.IO;

namespace Redactor.WorkWithUsersCommands
{
    public interface WorkWithUsersCommand
    {
        void Execute(string commandData, TextWriter textWriter );
    }
}
