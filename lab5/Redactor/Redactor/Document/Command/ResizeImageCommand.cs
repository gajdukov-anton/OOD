using Redactor.Document;
using Redactor.Utils;
using System.Drawing;

namespace Redactor.Document.Command
{
    class ResizeImageCommand : ICommand
    {
        private ImageFunctions _imageFunctions = new ImageFunctions();
        private IResizable _customImage;
        private Image _newImage;
        private Image _prevImage;
        private int _newWidth;
        private int _newHeight;
        private int _prevWidth;
        private int _prevHeight;

        public ResizeImageCommand( IResizable customImage, int width, int height )
        {
            _customImage = customImage;
            _newImage = _imageFunctions.ResizeImg( Image.FromFile( customImage.GetPath() ), width, height);
            _newWidth = width;
            _newHeight = height;
            _prevImage = customImage.Image;
            _prevHeight = customImage.ImageResolution.Height;
            _prevWidth = customImage.ImageResolution.Width;
        }

        public void Dispose()
        {
        }

        public void Execute()
        {
            _customImage.Image = _newImage;
            _customImage.ImageResolution.Width = _newWidth;
            _customImage.ImageResolution.Height = _newHeight;
            _customImage.SaveChanges();
        }

        public void Unexecute()
        {
            _customImage.Image = _prevImage;
            _customImage.ImageResolution.Width = _prevWidth;
            _customImage.ImageResolution.Height = _prevHeight;
            _customImage.SaveChanges();
        }
    }

}
