using Paint.UI;

namespace Paint.FactoryUsers
{
    public interface IPainter
    {
        void DrawPicture( PictureDraft draft, ICanvas canvas );
    }
}
