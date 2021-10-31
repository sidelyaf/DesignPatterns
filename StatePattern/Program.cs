using System;

namespace StatePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            GumballMachine gumballMachine = new GumballMachine(2);

            Console.WriteLine(gumballMachine);

            gumballMachine.insertQuarter();
            gumballMachine.turnCrank();

            Console.WriteLine(gumballMachine);

            gumballMachine.insertQuarter();
            gumballMachine.turnCrank();
            gumballMachine.insertQuarter();
            gumballMachine.turnCrank();

            gumballMachine.refill(5);
            gumballMachine.insertQuarter();
            gumballMachine.turnCrank();

            Console.WriteLine(gumballMachine);

            Console.ReadLine();
        }
    }
}
