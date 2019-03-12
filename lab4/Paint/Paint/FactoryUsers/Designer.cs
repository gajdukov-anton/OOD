using Paint.Factory;
using System;
using System.IO;

namespace Paint.FactoryUsers
{
    public class Designer : IDesigner
    {
        private ShapeFactory _shapeFactory;
        private const string SUCCESSFULLY_ADDED = "Shape was successfuly added";
        private const string INCORRECT_NUMBER = "Incorrect value of number";
        private const string EXIT_COMMAND = "exit";

        public Designer()
        {
            _shapeFactory = new ShapeFactory();
        }

        public PictureDraft CreateDraft( TextWriter textWriter, TextReader textReader )
        {
            PictureDraft draft = new PictureDraft();
            for (; ; )
            {
                string command = textReader.ReadLine();
                if ( command == null ||command.ToLower() == EXIT_COMMAND )
                {
                    break;
                }
                string answer = AddShapeToDraft( command, draft );
                textWriter.WriteLine( answer );
            }
            return draft;
        }

        private string AddShapeToDraft( string shapeDescription, PictureDraft draft )
        {
            try
            {
                draft.AddShape( _shapeFactory.CreateShape( shapeDescription ) );
                return SUCCESSFULLY_ADDED;
            }
            catch ( ArgumentException exception )
            {
                return exception.Message;
            }
            catch ( FormatException )
            {
                return INCORRECT_NUMBER;
            }
        }
    }
}
