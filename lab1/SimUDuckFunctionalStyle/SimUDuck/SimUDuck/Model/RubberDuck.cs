using System;
using SimUDuck.Behavior;

namespace SimUDuck.Model
{
    class RubberDuck : Duck
    {
        public RubberDuck()
            :base(FlyBehavior.FlyNoWay, DanceBehavior.DanceNoWay, QuackBehavior.Squeack)
        {
        }

        public override void Display()
        {
            Console.WriteLine( "I'm rubber duck" );
        }
    }
}
