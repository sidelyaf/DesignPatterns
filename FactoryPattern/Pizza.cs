using System;

namespace FactoryPattern
{
    // Product classes
    public abstract class Pizza
    {
        public string Name { get; set; }
        public abstract void PreparePizza();
        public void BakePizza()
        {
            Console.WriteLine("Bake for 25 minutes at 350");
        }
        public void CutPizza()
        {
            Console.WriteLine("Cutting the pizza into diagonal slices");
        }
        public void BoxPizza()
        {
            Console.WriteLine("Place pizza in official PizzaStore box");
        }
    }

    public class NYStyleCheesePizza : Pizza
    {
        IPizzaIngradientFactory _pizzaIngradientFactory;
        public NYStyleCheesePizza(IPizzaIngradientFactory pizzaIngradientFactory)
        {
            this._pizzaIngradientFactory = pizzaIngradientFactory;
        }

        public override void PreparePizza()
        {
            Console.WriteLine("Ny style Cheese pizza is preparing...");
            var dough = _pizzaIngradientFactory.CreateDough();
            var cheese = _pizzaIngradientFactory.CreateCheese();
            var clam = _pizzaIngradientFactory.CreateClam();
            var pepperoni = _pizzaIngradientFactory.CreatePepperoni();
            var souce = _pizzaIngradientFactory.CreateSouce();
            var veggies = _pizzaIngradientFactory.CreateVeggies();
        }
    }

    public class NYStyleVeggiePizza : Pizza
    {
        IPizzaIngradientFactory _pizzaIngradientFactory;
        public NYStyleVeggiePizza(IPizzaIngradientFactory pizzaIngradientFactory)
        {
            this._pizzaIngradientFactory = pizzaIngradientFactory;
        }

        public override void PreparePizza()
        {
            Console.WriteLine("Ny style veggies pizza is preparing...");
            var dough = _pizzaIngradientFactory.CreateDough();
            var cheese = _pizzaIngradientFactory.CreateCheese();
            var clam = _pizzaIngradientFactory.CreateClam();
            var pepperoni = _pizzaIngradientFactory.CreatePepperoni();
            var souce = _pizzaIngradientFactory.CreateSouce();
            var veggies = _pizzaIngradientFactory.CreateVeggies();
        }
    }

    public class NYStyleClamPizza : Pizza
    {
        IPizzaIngradientFactory _pizzaIngradientFactory;
        public NYStyleClamPizza(IPizzaIngradientFactory pizzaIngradientFactory)
        {
            this._pizzaIngradientFactory = pizzaIngradientFactory;
        }

        public override void PreparePizza()
        {
            Console.WriteLine("Ny style clam pizza is preparing...");
            var dough = _pizzaIngradientFactory.CreateDough();
            var cheese = _pizzaIngradientFactory.CreateCheese();
            var clam = _pizzaIngradientFactory.CreateClam();
            var pepperoni = _pizzaIngradientFactory.CreatePepperoni();
            var souce = _pizzaIngradientFactory.CreateSouce();
            var veggies = _pizzaIngradientFactory.CreateVeggies();
        }
    }

    public class NYStylePepperoniPizza : Pizza
    {
        IPizzaIngradientFactory _pizzaIngradientFactory;
        public NYStylePepperoniPizza(IPizzaIngradientFactory pizzaIngradientFactory)
        {
            this._pizzaIngradientFactory = pizzaIngradientFactory;
        }

        public override void PreparePizza()
        {
            Console.WriteLine("Ny style pepperoni pizza is preparing...");
            var dough = _pizzaIngradientFactory.CreateDough();
            var cheese = _pizzaIngradientFactory.CreateCheese();
            var clam = _pizzaIngradientFactory.CreateClam();
            var pepperoni = _pizzaIngradientFactory.CreatePepperoni();
            var souce = _pizzaIngradientFactory.CreateSouce();
            var veggies = _pizzaIngradientFactory.CreateVeggies();
        }
    }

    public class ChicagoStyleCheesePizza : Pizza
    {
        IPizzaIngradientFactory _pizzaIngradientFactory;
        public ChicagoStyleCheesePizza(IPizzaIngradientFactory pizzaIngradientFactory)
        {
            this._pizzaIngradientFactory = pizzaIngradientFactory;
        }

        public override void PreparePizza()
        {
            Console.WriteLine("Chicago style cheese pizza is preparing...");
            var dough = _pizzaIngradientFactory.CreateDough();
            var cheese = _pizzaIngradientFactory.CreateCheese();
            var clam = _pizzaIngradientFactory.CreateClam();
            var pepperoni = _pizzaIngradientFactory.CreatePepperoni();
            var souce = _pizzaIngradientFactory.CreateSouce();
            var veggies = _pizzaIngradientFactory.CreateVeggies();
        }
    }

    public class ChicagoStyleVeggiePizza : Pizza
    {
        IPizzaIngradientFactory _pizzaIngradientFactory;
        public ChicagoStyleVeggiePizza(IPizzaIngradientFactory pizzaIngradientFactory)
        {
            this._pizzaIngradientFactory = pizzaIngradientFactory;
        }

        public override void PreparePizza()
        {
            Console.WriteLine("Chicago style veggie pizza is preparing...");
            var dough = _pizzaIngradientFactory.CreateDough();
            var cheese = _pizzaIngradientFactory.CreateCheese();
            var clam = _pizzaIngradientFactory.CreateClam();
            var pepperoni = _pizzaIngradientFactory.CreatePepperoni();
            var souce = _pizzaIngradientFactory.CreateSouce();
            var veggies = _pizzaIngradientFactory.CreateVeggies();
        }
    }

    public class ChicagoStyleClamPizza : Pizza
    {
        IPizzaIngradientFactory _pizzaIngradientFactory;
        public ChicagoStyleClamPizza(IPizzaIngradientFactory pizzaIngradientFactory)
        {
            this._pizzaIngradientFactory = pizzaIngradientFactory;
        }

        public override void PreparePizza()
        {
            Console.WriteLine("Chicago style clam pizza is preparing...");
            var dough = _pizzaIngradientFactory.CreateDough();
            var cheese = _pizzaIngradientFactory.CreateCheese();
            var clam = _pizzaIngradientFactory.CreateClam();
            var pepperoni = _pizzaIngradientFactory.CreatePepperoni();
            var souce = _pizzaIngradientFactory.CreateSouce();
            var veggies = _pizzaIngradientFactory.CreateVeggies();
        }
    }

    public class ChicagoStylePepperoniPizza : Pizza
    {
        IPizzaIngradientFactory _pizzaIngradientFactory;
        public ChicagoStylePepperoniPizza(IPizzaIngradientFactory pizzaIngradientFactory)
        {
            this._pizzaIngradientFactory = pizzaIngradientFactory;
        }

        public override void PreparePizza()
        {
            Console.WriteLine("Chicago style pepperoni pizza is preparing...");
            var dough = _pizzaIngradientFactory.CreateDough();
            var cheese = _pizzaIngradientFactory.CreateCheese();
            var clam = _pizzaIngradientFactory.CreateClam();
            var pepperoni = _pizzaIngradientFactory.CreatePepperoni();
            var souce = _pizzaIngradientFactory.CreateSouce();
            var veggies = _pizzaIngradientFactory.CreateVeggies();
        }
    }
}
