using System;

namespace TemplateMethodPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            // Tea and Coffee
            TeaWithHook teaWithHook = new TeaWithHook();
            CoffeeWithHook coffeeWithHook = new CoffeeWithHook();

            //tea meaking
            Console.WriteLine("Making tea");
            teaWithHook.PrepareRecipe();

            Console.WriteLine("========================");

            //Coffee making
            Console.WriteLine("Making coffee");
            coffeeWithHook.PrepareRecipe();

            Console.ReadLine();
        }
    }
}
