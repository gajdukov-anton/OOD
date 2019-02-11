using System;

namespace SimUDuck.Behavior
{
    class FlyBehavior
    {
        public static Action FlyWithWings()
        {
            int count = 0;
            void Action()
            {
                count++;
                Console.WriteLine( $"I'm flying with wings!!  {count}" );
            }

            return Action;
        }

        public static void FlyNoWay()
        {
        }
    }
}
