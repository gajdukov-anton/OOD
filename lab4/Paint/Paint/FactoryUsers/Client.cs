using Paint.UI;
using System.IO;

namespace Paint.FactoryUsers
{
    public class Client
    {
        private PictureDraft _pictureDraft;

        public Client()
        {
        }

        public void CreatePictureDraft( IDesigner designer, TextReader textReader, TextWriter textWriter )
        {
            _pictureDraft = designer.CreateDraft( textWriter, textReader );
        }

        public void CreatePicture(IPainter painter, ICanvas canvas)
        {
            painter.DrawPicture( _pictureDraft, canvas );
        }
    }
}
