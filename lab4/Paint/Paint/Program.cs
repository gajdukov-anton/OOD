using Paint.UI;
using Paint.FactoryUsers;
using System;

namespace Paint
{
    class Program
    {
        static void Main( string [] args )
        {
            Designer designer = new Designer();
            Painter painter = new Painter( Console.Out );
            Client client = new Client();
            using ( Canvas canvas = new Canvas( Console.Out ) )
            { 
                client.CreatePictureDraft( designer, Console.In, Console.Out );
                client.CreatePicture( painter, canvas );
            }
        }
    }
}
