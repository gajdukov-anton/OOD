using SimUDuck.Behavior;
using System;

namespace SimUDuck.Model
{
    class DecoyDuck : Duck
    {
        public DecoyDuck()
            : base( FlyBehavior.FlyNoWay, DanceBehavior.DanceNoWay, QuackBehavior.Mute )
        {
        }

        public override void Display()
        {
            Console.WriteLine( "I'm decoy duck" );
        }

    }
}
