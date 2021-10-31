using System;
using System.Collections.Generic;
using System.Text;

namespace AdapterAndFacadePatterns
{
    public class AdapterPattern
    {
    }

    public interface IDuck
    {
        void Quack();
        void Fly();
    }

    public interface ITurkey
    {
        void Gobble();
        void Fly();
    }

    public class MallardDuck : IDuck
    {
        public void Fly()
        {
            Console.WriteLine("I am flying");
        }

        public void Quack()
        {
            Console.WriteLine("Quacking");
        }
    }

    public class WildTurkey : ITurkey
    {
        public void Fly()
        {
            Console.WriteLine("I am flying short distance");
        }

        public void Gobble()
        {
            Console.WriteLine("Gobble gobble");
        }
    }

    public class TurkeyAdapter : IDuck
    {
        ITurkey _turkey;
        public TurkeyAdapter(ITurkey turkey)
        {
            _turkey = turkey;
        }
        public void Fly()
        {
            for (int i = 0; i < 5; i++)
            {
                _turkey.Fly();
            }
        }

        public void Quack()
        {
            _turkey.Gobble();
        }
    }

    public class DuckAdapter : ITurkey
    {
        IDuck _duck;
        public DuckAdapter(IDuck duck)
        {
            _duck = duck;
        }

        public void Fly()
        {
            for (int i = 0; i < 5; i++)
            {
                _duck.Fly();
            }
        }

        public void Gobble()
        {
            _duck.Quack();
        }
    }
}
