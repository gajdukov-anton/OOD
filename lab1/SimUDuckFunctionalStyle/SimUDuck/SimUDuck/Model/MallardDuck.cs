﻿using System;
using SimUDuck.Behavior;

namespace SimUDuck.Model
{
    class MallardDuck : Duck
    {
        public MallardDuck()
            :base(FlyBehavior.FlyWithWingsAction(), DanceBehavior.DanceWaltz, QuackBehavior.Quack)
        { 
        }

        public override void Display()
        {
            Console.WriteLine( "I'm mallard duck" );
        }
    }
}
