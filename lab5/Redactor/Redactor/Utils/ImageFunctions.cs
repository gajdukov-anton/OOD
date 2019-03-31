using System.Drawing;
using System.Drawing.Drawing2D;

namespace Redactor.Utils
{
    public class ImageFunctions
    {
        public ImageFunctions()
        {

        }
        public Image ResizeImg( Image image, int newWidth, int newHeight )
        {
            Image result = new Bitmap( newWidth, newHeight );
            using ( Graphics g = Graphics.FromImage( result ) )
            {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage( image, 0, 0, newWidth, newHeight );
                g.Dispose();
                image.Dispose();
            }
            return result;
        }
    }
}
