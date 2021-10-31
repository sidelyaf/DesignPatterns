using System;

namespace AdapterAndFacadePatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            #region AdapterPattern
            //TurkeyAdapter
            MallardDuck mallardDuck = new MallardDuck();
            WildTurkey wildTurkey = new WildTurkey();

            IDuck turkeyAdapter = new TurkeyAdapter(wildTurkey);

            Console.WriteLine("The Turkey says ");
            wildTurkey.Gobble();
            wildTurkey.Fly();

            Console.WriteLine();
            Console.WriteLine("The Duck says ");
            TestDuck(mallardDuck);

            Console.WriteLine("\nThe TurkeyAdapter says...");
            TestDuck(turkeyAdapter);
            #endregion

            #region Facade Pattern
            //HomeTheaterFacade example
            Amplifier amp = new Amplifier("Top-O-Line Amplifier");
            Tuner tuner = new Tuner("Top-O-Line AM/FM Tuner", amp);
            DvdPlayer dvd = new DvdPlayer("Top-O-Line DVD Player", amp);
            CdPlayer cd = new CdPlayer("Top-O-Line CD Player", amp);
            Projector projector = new Projector("Top-O-Line Projector", dvd);
            TheaterLights lights = new TheaterLights("Theater Ceiling Lights");
            Screen screen = new Screen("Theater Screen");
            PopcornPopper popper = new PopcornPopper("Popcorn Popper");

            HomeTheaterFacade homeTheater = new HomeTheaterFacade(amp, tuner, dvd, cd,
                projector, screen, lights, popper);

            homeTheater.WatchMovie("Raiders of the Lost Ark");
            homeTheater.EndMovie();
            #endregion

            Console.ReadLine();
        }

        /// <summary>
        /// AdapterPattern
        /// </summary>
        /// <param name="duck"></param>
        static void TestDuck(IDuck duck)
        {
            duck.Quack();
            duck.Fly();
        }
    }
}
