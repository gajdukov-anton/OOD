using Adapter.Application;
using System;

namespace Adapter
{
    class Program
    {
        static void Main( string [] args )
        {
            Console.WriteLine( "Should we use new API (y)?" );
            string userInput = Console.ReadLine();
            if ( userInput != null && userInput.ToLower() == "y" )
            {
                App.PaintPictureOnModernGraphicsRenderer();
                Console.WriteLine();
                App.PaintPictureOnModernGraphicsRenderer( true );
            }
            else
            {
                App.PaintPictureOnCanvas();
            }
        }
    }
}
