using System;
using SimUDuck.Behavior;

namespace SimUDuck.Model
{
    class ModelDuck : Duck
    {
        public ModelDuck()
            :base(FlyBehavior.FlyNoWay, DanceBehavior.DanceNoWay, QuackBehavior.Quack)
        {
        }

        public override void Display()
        {
            Console.WriteLine( "I'm model duck" );
        }
    }
}
