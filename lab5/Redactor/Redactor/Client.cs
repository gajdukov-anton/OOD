using Redactor.WorkWithUsersCommands;
using Redactor.Document;
using Redactor.Utils;
using System.IO;

namespace Redactor
{
    public class Client
    {
        private IDocument _document;
        private Menu _menu;
        private TextReader _textReader;
        private TextWriter _textWriter;

        public Client( TextWriter textWriter, TextReader textReader )
        {
            _document = new Document.Document();
            _menu = new Menu( textWriter, textReader );
            _textReader = textReader;
            _textWriter = textWriter;
            _menu.AddItem( Constants.INSERT_PARAGRAPH_COMMAND_NAME, Constants.INSERT_PARAGRAPH_COMMAND_DESCRIPTION, new AddParagraphCommand( _document ) );
            _menu.AddItem( Constants.SET_TITLE_COMMAND_NAME, Constants.SET_TITLE_COMMAND_DESCRIPTION, new AddTitleCommand( _document ) );
            _menu.AddItem( Constants.LIST_COMMAND_NAME, Constants.LIST_COMMAND_DESCRIPTION, new GetListCommand( _document ) );
            _menu.AddItem( Constants.HELP_COMMAND_NAME, Constants.HELP_COMMAND_DESCRIPTION, new ShowInstructionCommand( _menu ) );
            _menu.AddItem( Constants.EXIT_COMMAND_NAME, Constants.EXIT_COMMAND_DESCRIPTION, new ExitCommand( _menu ) );
            _menu.AddItem( Constants.REPLACE_TEXT_COMMAND_NAME, Constants.REPLACE_TEXT_COMMAND_DESCRIPTION, new AddReplaceTextCommand( _document ) );
            _menu.AddItem( Constants.UNDO_COMMAND_NAME, Constants.UNDO_COMMAND_DESCRIPTION, new AddUndoCommand( _document ) );
            _menu.AddItem( Constants.REDO_COMMAND_NAME, Constants.REDO_COMMAND_DESCRIPTION, new AddRedoCommand( _document ) );
            _menu.AddItem( Constants.DELETE_ITEM_COMMAND_NAME, Constants.DELETE_ITEM_COMMAND_DESCRIPTION, new AddDeleteItemCommand( _document ) );
            _menu.AddItem( Constants.SAVE_COMMAND_NAME, Constants.SAVE_COMMAND_DESCRIPTION, new SaveCommand( _document ) );
        }

        public void StartRedactor()
        {
            _menu.Run();
        }

        public IDocument GetDocument()
        {
            return _document;
        }

        public Menu GetMenu()
        {
            return _menu;
        }
    }
}
