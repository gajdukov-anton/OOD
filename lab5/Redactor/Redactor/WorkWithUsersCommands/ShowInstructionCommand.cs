using Redactor.Utils;
using System.IO;

namespace Redactor.WorkWithUsersCommands
{
    public class ShowInstructionCommand : WorkWithUsersCommand
    {
        Menu _menu;

        public ShowInstructionCommand( Menu document )
        {
            _menu = document;
        }

        public void Execute( string commandData, TextWriter textWriter )
        {
            _menu.ShowInstructions();
        }
    }
}
