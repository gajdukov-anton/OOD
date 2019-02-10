using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimUDuck.Model
{
    class Duck
    {
        public delegate void FlyHandler();
        public delegate void DanceHandler();
        public delegate void QuackHandler();
        private FlyHandler m_fly;
        private DanceHandler m_dance;
        private QuackHandler m_quack;

        public Duck( FlyHandler flyHandler, DanceHandler danceHandler, QuackHandler quackHandler )
        {
            m_fly = flyHandler;
            m_dance = danceHandler;
            m_quack = quackHandler;
        }

        public void Quack()
        {
            m_quack();
        }

        public void Swim()
        {
            Console.WriteLine( "I'm swimming" );
        }

        public void Fly()
        {
            m_fly();
        }

        public void SetFlyBehavior( FlyHandler flyHandler )
        {
            m_fly = flyHandler;
        }

        public void SetDanceBehavior( DanceHandler danceHandler )
        {
            m_dance = danceHandler;
        }

        public void Dance()
        {
            m_dance();
        }

        public virtual void Display()
        {
        }
    }
}
