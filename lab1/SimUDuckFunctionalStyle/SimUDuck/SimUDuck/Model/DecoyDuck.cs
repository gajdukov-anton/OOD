using SimUDuck.Action;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
