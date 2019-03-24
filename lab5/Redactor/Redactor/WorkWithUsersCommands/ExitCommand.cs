using Redactor.Utils;
using System.IO;

namespace Redactor.WorkWithUsersCommands
{
    public class ExitCommand : WorkWithUsersCommand
    {
        private Menu _menu;

        public ExitCommand(Menu menu)
        {
            _menu = menu;
        }
        public void Execute( string commandData, TextWriter textWriter )
        {
            _menu.Exit();
        }
    }
}
