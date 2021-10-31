using System;

namespace FactoryPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            /// TODO: Çalışıyor ama ingradients in içerikleri daha fazla doldurulabilir.
            PizzaStore pizzaStore = new NYPizzaStore(new NYPizzaIngradientFactory());
            pizzaStore.OrderPizza(PizzaType.Cheese);
            pizzaStore.OrderPizza(PizzaType.Pepperoni);
            Console.ReadLine();
        }
    }
}
