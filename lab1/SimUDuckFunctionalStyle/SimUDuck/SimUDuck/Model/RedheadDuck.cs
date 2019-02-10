using System;
using SimUDuck.Action;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimUDuck.Model
{
    class RedheadDuck : Duck
    {
        public RedheadDuck()
            :base(FlyBehavior.FlyWithWings, DanceBehavior.DanceMinuet, QuackBehavior.Quack)
        {
        }

        public override void Display()
        {
            Console.WriteLine( "I'm redhead duck" );
        }
    }
}
