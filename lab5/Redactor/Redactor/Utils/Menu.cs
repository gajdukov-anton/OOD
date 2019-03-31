using Redactor.WorkWithUsersCommands;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Redactor.Document.Command;

namespace Redactor.Utils
{
    public class Menu
    {
        private List<Item> _items;
        private bool _exit = false;
        private TextWriter _textWriter;
        private TextReader _textReader;

        public Menu( TextWriter textWriter, TextReader textReader )
        {
            _textReader = textReader;
            _textWriter = textWriter;
            _items = new List<Item>();
        }

        public void AddItem( string shortcut, string description, WorkWithUsersCommand command )
        {
            _items.Add( new Item( shortcut, description, command ) );
        }

        public void Run()
        {
            while ( !_exit )
            {
                string command = _textReader.ReadLine();
                if ( command == null )
                {
                    break;
                }
                ExecuteCommand( command );
            }
        }

        public void ShowInstructions()
        {
            _textWriter.WriteLine( "Commands list:" );
            foreach ( var command in _items )
            {
                _textWriter.WriteLine( $" {command.Shortcut}: {command.Description}" );
            }
        }

        public void Exit()
        {
            _exit = true;
        }

        public void ExecuteCommand( string commandStrData )
        {
            string [] commandArrData = commandStrData.Split( new char [] { ' ' }, StringSplitOptions.RemoveEmptyEntries );
            if (commandArrData.Count() == 0)
            {
                _textWriter.WriteLine( Constants.UNRKNOW_COMMAND );
                return;
            }
            var item = from it in _items
                       where it.Shortcut.ToLower() == commandArrData [ 0 ].ToLower()
                       select it;
            if ( item.Count() != 0 )
            {
                item.First().Command.Execute( commandStrData, _textWriter );
            }
            else
            {
                _textWriter.WriteLine( Constants.UNRKNOW_COMMAND );
            }
        }
    }
}