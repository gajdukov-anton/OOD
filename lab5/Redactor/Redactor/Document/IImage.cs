using Redactor.Document.Command;
using System;

namespace Redactor.Document
{
    public interface IImage : IDisposable
    {
        string GetPath();
        int GetWidth();
        int GetHeight();
        void Resize( int width, int height, IMainHistoryCommands history );
    }
}
