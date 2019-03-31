namespace Redactor.Document
{
    public class ImageResolution
    {
        public int Width { get; set; }
        public int Height { get; set; }
        private IResizable _image;

        public ImageResolution(IResizable image)
        {
            _image = image;
        }
    }
}
