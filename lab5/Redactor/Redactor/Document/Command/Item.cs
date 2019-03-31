using Redactor.WorkWithUsersCommands;

namespace Redactor.Document.Command
{
    public class Item
    {
        public string Shortcut { get; } 
        public string Description { get; }
        public WorkWithUsersCommand Command { get; }

        public Item(string shortcut, string description, WorkWithUsersCommand command )
        {
            Shortcut = shortcut;
            Description = description;
            Command = command;
        }
    }
}
