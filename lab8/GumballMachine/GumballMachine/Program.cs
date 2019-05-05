using System;

namespace GumballMachine
{
    class Program
    {
        static void Main( string [] args )
        {
            MultiGumballMachine.GumballMachine gumballMachine = new MultiGumballMachine.GumballMachine( 2, Console.Out );
            gumballMachine.InsertQuarter();
            gumballMachine.InsertQuarter();
            gumballMachine.InsertQuarter();
            gumballMachine.TurnCrank();
            gumballMachine.TurnCrank();
            gumballMachine.EjectQuarter();

            Console.WriteLine( "---------------" );

            NaiveGumballMachine.GumballMachine naiveGumballMachine = new NaiveGumballMachine.GumballMachine( 2, Console.Out );
            naiveGumballMachine.InsertQuarter();
            naiveGumballMachine.InsertQuarter();
            naiveGumballMachine.InsertQuarter();
            naiveGumballMachine.TurnCrank();
            naiveGumballMachine.TurnCrank();
            naiveGumballMachine.EjectQuarter();
        }
    }
}
