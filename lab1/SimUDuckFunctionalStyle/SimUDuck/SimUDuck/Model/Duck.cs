using System;

namespace SimUDuck.Model
{
    class Duck
    {
        /*public delegate void Action FlyHandler();
        public delegate void DanceHandler();
        public delegate void QuackHandler();*/
        private Action m_fly;
        private Action m_dance;
        private Action m_quack;

        public Duck( Action flyHandler, Action danceHandler, Action quackHandler )
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

        public void SetFlyBehavior( Action flyHandler )
        {
            m_fly = flyHandler;
        }

        public void SetDanceBehavior( Action danceHandler )
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
