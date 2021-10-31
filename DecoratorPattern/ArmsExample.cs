using System;
using System.Collections.Generic;
using System.Text;

namespace DecoratorPattern
{
    // Component
    public abstract class Arms
    {
        public string Name;
        public abstract void Fire();
    }

    // ConcreteComponent
    public class Artillery
        : Arms
    {
        protected double _barrel;
        protected double _range;

        public Artillery(double barrel, double range, string name)
        {
            _barrel = barrel;
            _range = range;
            Name = name;
        }

        public override void Fire()
        {
            Console.WriteLine("{0} sınıfından olan topçu, {1} mm namlusundan {2} mesafeye ateşleme yaptı", Name, _barrel.ToString(), _range.ToString());
        }
    }

    // Decorator
    public abstract class ArmsDecorator
        : Arms
    {
        protected Arms _arms;
        public ArmsDecorator(Arms arms)
        {
            _arms = arms;
        }
        public override void Fire()
        {
            if (_arms != null)
                _arms.Fire();
        }
    }

    // ConcreteDecorator
    public class ArtilleryDecorator
         : ArmsDecorator
    {
        public ArtilleryDecorator(Arms arms)
            : base(arms)
        {
        }

        public void Defense()
        {
            Console.WriteLine("\t{0} Savunma Modu!", base._arms.Name);
        }
        public void Easy()
        {
            Console.WriteLine("\t{0} Atış serbest modu!", _arms.Name);
        }
        public override void Fire()
        {
            base.Fire();
        }
    }
}
