using Redactor.Document.Command;
using Redactor.Utils;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Redactor.Document
{
    class CustomImage : IImage, IResizable
    {
        public ImageResolution ImageResolution { get; set; }
        public Image Image { get; set; }
        private ImageFunctions _imageFunctions = new ImageFunctions();
        private readonly string _name;
        private string _path;

        public CustomImage( int height, int width, string path )
        {
            ImageResolution = new ImageResolution( this );
            ImageResolution.Height = height;
            ImageResolution.Width = width;
            _name = CreateName();
            Image = Image.FromFile( path );
            Image = _imageFunctions.ResizeImg( Image, width, height );
            if ( !Directory.Exists( $"{Directory.GetCurrentDirectory()}\\images\\" ) )
            {
                Directory.CreateDirectory( $"{Directory.GetCurrentDirectory()}\\images\\" );
            }
            _path = $"{Directory.GetCurrentDirectory()}\\images\\{_name}.png";
            Image.Save( _path, ImageFormat.Png );
        }

        public void Dispose()
        {
            FileInfo fileInf = new FileInfo( _path );
            if ( fileInf.Exists )
            {
                fileInf.Delete();
            }
        }

        public int GetHeight()
        {
            return ImageResolution.Height;
        }

        public string GetPath()
        {
            return _path;
        }

        public int GetWidth()
        {
            return ImageResolution.Width;
        }

        public void Resize( int width, int height, IMainHistoryCommands history )
        {
            history.AddAndExecuteCommand( new ResizeImageCommand( this, width, height ) );
        }

        public void SaveChanges()
        {
            FileInfo fileInf = new FileInfo( _path );
            if ( fileInf.Exists )
            {
                fileInf.Delete();
            }
            Image.Save( _path, ImageFormat.Png );
        }

        private string CreateName()
        {
            return DateTime.UtcNow.Millisecond.ToString();
        }
    }
}
