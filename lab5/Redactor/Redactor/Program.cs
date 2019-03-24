using System;

namespace Redactor
{
    class Program
    {
        static void Main( string [] args )
        {
            Client client = new Client( Console.Out, Console.In );
            client.StartRedactor();
        }
    }
}
