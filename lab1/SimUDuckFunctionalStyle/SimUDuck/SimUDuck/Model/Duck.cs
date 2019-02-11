using System;

namespace SimUDuck.Model
{
    abstract class Duck
    {
        protected Action m_fly;
        protected Action m_dance;
        protected Action m_quack;

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

        public void Dance()
        {
            m_dance();
        }

        public abstract void Display();
    }
}
