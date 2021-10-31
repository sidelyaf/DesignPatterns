using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethodPattern
{
    public class CaffeinBeverage
    {
    }

    public abstract class CaffeinBeverageWithHook
    {
        public void PrepareRecipe()
        {
            BoilWater();
            Brew();
            PourInCup();
            if (CustomerWantCondiments())
            {
                AddCondiment();
            }
            else Console.WriteLine("Nothing added");
           
        }

        public abstract void Brew();
        public abstract void AddCondiment();

        public void BoilWater()
        {
            Console.WriteLine("Boiling water");
        }

        public void PourInCup()
        {
            Console.WriteLine("Pouring in cup");
        }

        public virtual bool CustomerWantCondiments() { return true; }
    }

    public class CoffeeWithHook : CaffeinBeverageWithHook
    {
        public override void AddCondiment()
        {
            Console.WriteLine("Adding sugar and milk");
        }

        public override void Brew()
        {
            Console.WriteLine("Dripping coffee through filter");
        }

        public override bool CustomerWantCondiments()
        {
            return GetUserInput().ToLower() == "y" ? true : false;
        }

        private string GetUserInput()
        {
            string answer = "";
            Console.WriteLine("Would you like milk and sugar with your coffee (y/n)?");

            
            answer = Console.ReadLine();
            if (string.IsNullOrEmpty(answer.Trim()) || answer.Trim().ToLower() != "y")
            {
                return "n";
            }

            return answer;

        }
    }

    public class TeaWithHook : CaffeinBeverageWithHook
    {
        public override void AddCondiment()
        {
            Console.WriteLine("Adding lemon");
        }

        public override void Brew()
        {
            Console.WriteLine("Stepping the tea");
        }

        public override bool CustomerWantCondiments()
        {
            return GetUserInput().ToLower() == "y" ? true : false;
        }

        private string GetUserInput()
        {
            string answer = "";
            Console.WriteLine("Would you like lemon with your tea (y/n)?");


            answer = Console.ReadLine();
            if (string.IsNullOrEmpty(answer.Trim()) || answer.Trim().ToLower() != "y")
            {
                return "n";
            }

            return answer;

        }
    }
}
