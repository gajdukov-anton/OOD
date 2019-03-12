using Paint.UI;
using System;
using System.IO;

namespace Paint.FactoryUsers
{
    public class Painter : IPainter
    {
        private TextWriter _textWriter;

        public Painter( TextWriter textWriter )
        {
            _textWriter = textWriter;
        }

        public void DrawPicture( PictureDraft draft, ICanvas canvas )
        {
            try
            {
                for ( int i = 0; i < draft.GetShapeCount(); i++ )
                {
                    draft.GetShape( i ).Draw( canvas );
                }
            }
            catch ( IndexOutOfRangeException exception )
            {
                _textWriter.WriteLine( exception.Message );
            }
        }
    }
}