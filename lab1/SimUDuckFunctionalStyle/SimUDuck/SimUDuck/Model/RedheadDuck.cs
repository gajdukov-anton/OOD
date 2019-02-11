using System;
using SimUDuck.Behavior;

namespace SimUDuck.Model
{
    class RedheadDuck : Duck
    {
        public RedheadDuck()
            :base(FlyBehavior.FlyWithWings(), DanceBehavior.DanceMinuet, QuackBehavior.Quack)
        {
        }

        public override void Display()
        {
            Console.WriteLine( "I'm redhead duck" );
        }
    }
}
