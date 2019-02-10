using System;
using SimUDuck.Action;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimUDuck.Model
{
    class MallardDuck : Duck
    {
        public MallardDuck()
            :base(FlyBehavior.FlyWithWings, DanceBehavior.DanceWaltz, QuackBehavior.Quack)
        { 
        }

        public override void Display()
        {
            Console.WriteLine( "I'm mallard duck" );
        }
    }
}
