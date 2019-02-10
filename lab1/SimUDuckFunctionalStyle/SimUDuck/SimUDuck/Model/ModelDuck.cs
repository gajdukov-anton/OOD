using System;
using SimUDuck.Action;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
