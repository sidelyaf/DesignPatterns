using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryPattern
{
    //Creator classes
    public abstract class PizzaStore
    {
        //IPizzaIngradientFactory _pizzaIngradientFactory;
        //public PizzaStore(IPizzaIngradientFactory pizzaIngradientFactory)
        //{
        //    this._pizzaIngradientFactory = pizzaIngradientFactory;
        //}
        public abstract Pizza CreatePizza(PizzaType pizzaType);

        public Pizza OrderPizza(PizzaType pizzaType)
        {
            Pizza pizza = CreatePizza(pizzaType);
            pizza.PreparePizza();
            pizza.BakePizza();
            pizza.CutPizza();
            pizza.BoxPizza();

            return pizza;

        }
    }

    public class NYPizzaStore : PizzaStore
    {
        NYPizzaIngradientFactory _NYPizzaIngradientFactory;
        public NYPizzaStore(NYPizzaIngradientFactory NYPizzaIngradientFactory)
        {
            this._NYPizzaIngradientFactory = NYPizzaIngradientFactory;
        }
        public override Pizza CreatePizza(PizzaType item)
        {
            switch (item)
            {
                case PizzaType.Cheese:
                    return new NYStyleCheesePizza(_NYPizzaIngradientFactory);
                case PizzaType.Veggie:
                    return new NYStyleVeggiePizza(_NYPizzaIngradientFactory);
                case PizzaType.Clam:
                    return new NYStyleClamPizza(_NYPizzaIngradientFactory);
                case PizzaType.Pepperoni:
                    return new NYStylePepperoniPizza(_NYPizzaIngradientFactory);
                default:
                    return null;
            }
        }
    }

    public class ChicagoPizzaStore : PizzaStore
    {
        ChicagoIngradientFactory _chicagoIngradientFactory;
        public ChicagoPizzaStore(ChicagoIngradientFactory chicagoIngradientFactory)
        {
            this._chicagoIngradientFactory = chicagoIngradientFactory;
        }
        public override Pizza CreatePizza(PizzaType item)
        {
            switch (item)
            {
                case PizzaType.Cheese:
                    return new ChicagoStyleCheesePizza(_chicagoIngradientFactory);
                case PizzaType.Veggie:
                    return new ChicagoStyleVeggiePizza(_chicagoIngradientFactory);
                case PizzaType.Clam:
                    return new ChicagoStyleClamPizza(_chicagoIngradientFactory);
                case PizzaType.Pepperoni:
                    return new ChicagoStylePepperoniPizza(_chicagoIngradientFactory);
                default:
                    return null;
            }
        }
    }

    public enum PizzaType
    {
        Cheese,
        Veggie,
        Clam,
        Pepperoni
    }
}
