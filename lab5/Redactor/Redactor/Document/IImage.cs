using System.IO;

namespace Redactor.Document
{
    public interface IImage
    {
        Path GetPath();
        int GetWidth();
        int GetHeight();
        void Resize( int width, int height );
    }
}
