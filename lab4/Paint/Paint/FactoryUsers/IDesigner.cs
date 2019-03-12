using System.IO;

namespace Paint.FactoryUsers
{
    public interface IDesigner
    {
        PictureDraft CreateDraft( TextWriter textWriter, TextReader textReader );
    }
}
