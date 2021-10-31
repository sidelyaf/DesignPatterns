using System;

namespace DecoratorPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            /// TODO: Burada Beverage örneği yapılacak!!!!

            #region Arms example
            // Bileşen örneklenir
            Artillery azman = new Artillery(125, 40, "Fırtına A1");
            //azman.Fire();

            // Decorator nesnesi örneklenir
            ArtilleryDecorator azmanDekorator = new ArtilleryDecorator(azman);
            // Decorator nesnesi üzerinden o anki asıl Component için(Artillery sınıfı) ek fonksiyonellikler çağırılır.
            //azmanDekorator.Defense();
            //azmanDekorator.Fire();
            //azmanDekorator.Easy();
            //azmanDekorator.Fire();
            #endregion

            #region Starbuzz example
            // TODO: Description da bir sıkıntı var.

            Beverage beverage = new Expresso();
            beverage = new Mocha(beverage);
            beverage = new Whip(beverage);
            beverage = new Soy(beverage);
            beverage = new Mocha(beverage);

            beverage = new HouseBlend();
            beverage = new Soy(beverage);

            beverage = new DarkRoust();
            beverage = new Mocha(beverage);

            Console.WriteLine($"{beverage.GetDescription()} $ {beverage.Cost()}");

            #endregion

            Console.ReadLine();
        }

        //Component
        abstract class Beverage
        {
            public string description = "Unknown Beverage";

            public abstract double Cost();

            public string GetDescription()
            {
                return description;
            }
        }
        //Decorator
        abstract class CondementDecorator : Beverage
        {
            public abstract string GetDescription();
        }

        class Expresso : Beverage
        {
            public Expresso()
            {
                description = "Expresso";
            }
            public override double Cost()
            {
                return 2.00;
            }
        }

        class HouseBlend : Beverage
        {
            public HouseBlend()
            {
                description = "HouseBlend";
            }
            public override double Cost()
            {
                return 2.45;
            }
        }

        class DarkRoust : Beverage
        {
            public DarkRoust()
            {
                description = "DarkRoust";
            }
            public override double Cost()
            {
                return 2.85;
            }
        }

        class Decaf : Beverage
        {
            public Decaf()
            {
                description = "Decaf";
            }
            public override double Cost()
            {
                return 2.25;
            }
        }

        class Mocha : CondementDecorator
        {
            Beverage _beverage;
            double cost;
            public Mocha(Beverage bev)
            {
                _beverage = bev;
                cost = 0.20;
            }
            public override double Cost()
            {
                return _beverage.Cost() + cost;
            }

            public override string GetDescription()
            {
                return $"{ _beverage.GetDescription() } , Mocka";
            }
        }

        class Whip : CondementDecorator
        {
            Beverage _beverage;
            double cost;
            public Whip(Beverage bev)
            {
                _beverage = bev;
                cost = 0.30;
            }
            public override double Cost()
            {
                return _beverage.Cost() + cost;
            }

            public override string GetDescription()
            {
                return $"{ _beverage.GetDescription() } , Whip";
            }
        }

        class Soy : CondementDecorator
        {
            Beverage _beverage;
            double cost;
            public Soy(Beverage bev)
            {
                _beverage = bev;
                cost = 0.35;
            }
            public override double Cost()
            {
                return _beverage.Cost() + cost;
            }

            public override string GetDescription()
            {
                return $"{ _beverage.GetDescription() } , Soy";
            }
        }

    }
}
