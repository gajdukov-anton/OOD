using System.Drawing;

namespace Redactor.Document
{
    public interface IResizable
    {
        Image Image { get; set; }
        ImageResolution ImageResolution { get; set; }
        string GetPath();
        void SaveChanges();
    }
}
