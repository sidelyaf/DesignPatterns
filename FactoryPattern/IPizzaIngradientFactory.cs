using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryPattern
{
    public interface IPizzaIngradientFactory
    {
        IDough CreateDough();
        ISouce CreateSouce();
        ICheese CreateCheese();
        Veggies[] CreateVeggies();
        IPepperoni CreatePepperoni();
        IClam CreateClam();
    }

    public class NYPizzaIngradientFactory : IPizzaIngradientFactory
    {
        public ICheese CreateCheese()
        {
            return new ReggianoCheese();
        }

        public IClam CreateClam()
        {
            return new FreshClams();
        }

        public IDough CreateDough()
        {
           return new ThinCrustDough();
        }

        public IPepperoni CreatePepperoni()
        {
            return new SlicedPepperoni();
        }

        public ISouce CreateSouce()
        {
            return new MarinaraSauce();
        }

        public Veggies[] CreateVeggies()
        {
            return new Veggies[] { new Garlic(), new Onion(), new MushRooms(), new RedPepper() };
        }
    }

    public class ChicagoIngradientFactory : IPizzaIngradientFactory
    {
        public ICheese CreateCheese()
        {
            return new MozarellaCheese();
        }

        public IClam CreateClam()
        {
            return new FrozenClams();
        }

        public IDough CreateDough()
        {
            return new ThickCrustDough();
        }

        public IPepperoni CreatePepperoni()
        {
            return new SlicedPepperoni();
        }

        public ISouce CreateSouce()
        {
            return new PlumTomatoSauce();
        }

        public Veggies[] CreateVeggies()
        {
            return new Veggies[] { new Garlic(), new Onion(), new MushRooms(), new RedPepper() };
        }
    }
}
