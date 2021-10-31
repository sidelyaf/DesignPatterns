using System;

namespace SingletonPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // Singleton class
            Singleton singleton = Singleton.GetInstance();
            singleton.SimpleMethod();
            singleton.SimpleMethod();

            // SingletonEager class
            SingletonEager singletonEager = SingletonEager.GetInstance();
            singletonEager.SimpleMethod();


            // SingletonEager class
            SingletonDoubleCheck singletonDoubleCheck = SingletonDoubleCheck.GetInstance();
            singletonDoubleCheck.SimpleMethod();

            Console.ReadLine();
        }


    }

    //Eğer bir class sealed tanımlanırsa bu class alt class'lara kalıtım veremez.
    sealed class Singleton
    {
        private static Singleton singleton = null;
        private static int counter = 0;
        private Singleton()
        {
            counter++;
            Console.WriteLine($"counter : {counter}");
        }

        //Lazy loading 
        public static Singleton GetInstance()
        {
            if (singleton == null)
            {
                singleton = new Singleton();
            }
            return singleton; 
        }

        public void SimpleMethod()
        {
            Console.WriteLine("Singleton SimpleMethod is executed.");
        }
    }

    class SingletonEager
    {
        private static SingletonEager singleton = new SingletonEager();
        private SingletonEager() { }

        //Eager loading 
        public static SingletonEager GetInstance()
        {
            return singleton;
        }

        public void SimpleMethod()
        {
            Console.WriteLine("Singleton eagerly loading SimpleMethod is executed.");
        }
    }

    class SingletonDoubleCheck
    {
        //The volatile keyword ensures that multiple threads handle the uniqueInstance 
        // variable correctly when it is being initialized to the Singleton instance.
        private volatile static SingletonDoubleCheck uniqueInstance;
        private SingletonDoubleCheck() { }
        private static readonly object _lock = new object(); 

        //lock  With double-checked locking, we first check to see if an instance is created, and if not, THEN we
        // synchronize.
        public static SingletonDoubleCheck GetInstance()
        {
            if (uniqueInstance == null)
            {
                lock (_lock)
                {
                    if (uniqueInstance==null)
                    {
                        uniqueInstance = new SingletonDoubleCheck();
                    }
                }
            }
            return uniqueInstance;
        }

        public void SimpleMethod()
        {
            Console.WriteLine("Singleton lock loading SimpleMethod is executed.");
        }
    }
}
