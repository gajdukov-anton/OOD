﻿using System.Collections.Generic;

namespace Redactor.Document.Command
{
    public class History : IHistory
    {
        private List<ICommand> _commands;
        private List<ICommand> _cancelledCommands;

        public History()
        {
            _commands = new List<ICommand>();
            _cancelledCommands = new List<ICommand>();
        }

        public void AddAndExecuteCommand( ICommand command )
        {
            ClearCancelledCommands();
            AddCommands( command );
            command.Execute();
        }

        public bool CanRedo()
        {
            return _cancelledCommands.Count > 0;
        }

        public bool CanUndo()
        {
            return _commands.Count > 0;
        }

        public void Redo()
        {
            if (CanRedo())
            {
                _cancelledCommands [ _cancelledCommands.Count - 1 ].Execute();
                _commands.Add( _cancelledCommands [ _cancelledCommands.Count - 1 ] );
                _cancelledCommands.RemoveAt( _cancelledCommands.Count - 1 );
            }
        }

        public void Undo()
        {
            if ( CanUndo() )
            {
                _commands [ _commands.Count - 1 ].Unexecute();
                _cancelledCommands.Add( _commands [ _commands.Count - 1 ] );
                _commands.RemoveAt( _commands.Count - 1 );
            }
        }

        private void ClearCancelledCommands()
        { 
            while (_cancelledCommands.Count > 0)
            {
                _cancelledCommands [ _cancelledCommands.Count - 1 ].Dispose();
                _cancelledCommands.RemoveAt( _cancelledCommands.Count - 1 );
            }
        }

        private void AddCommands( ICommand command )
        {
            _commands.Add( command );
            if ( _commands.Count > 10 )
            {
                RemoveCommand( 0 );
            }
        }

        private void RemoveCommand(int index)
        {
            _commands [ index ].Dispose();
            _commands.RemoveAt( index );
        }
    }
}
