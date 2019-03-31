using System;

namespace Redactor.Document.Command
{
    public interface ICommand : IDisposable
    {
        void Execute();
        void Unexecute();
    }
}
