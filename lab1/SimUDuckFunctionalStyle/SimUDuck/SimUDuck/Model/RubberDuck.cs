using System;
using SimUDuck.Action;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
