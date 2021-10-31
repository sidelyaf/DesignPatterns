using System;
using System.Text;

namespace StatePattern
{
    public interface State
    {
        void insertQuarter();
        void ejectQuarter();
        void turnCrank();
        void dispense();
        void refill();
    }
    public class NoQuarterState : State
    {
        GumballMachine gumballMachine;
        public NoQuarterState(GumballMachine gumballMachine)
        {
            this.gumballMachine = gumballMachine;
        }

        public void insertQuarter()
        {
            Console.WriteLine("You inserted a quarter");
            gumballMachine.setState(gumballMachine.getHasQuarterState());
        }

        public void ejectQuarter()
        {
            Console.WriteLine("You haven't inserted a quarter");
        }

        public void turnCrank()
        {
            Console.WriteLine("You turned, but there's no quarter");
        }
        public void dispense()
        {
            Console.WriteLine("You need to pay first");
        }

        public void refill() { }

        public String toString()
        {
            return "waiting for quarter";
        }
    }

    public class GumballMachine
    {

        State soldOutState;
        State noQuarterState;
        State hasQuarterState;
        State soldState;

        State state;
        int count = 0;

        public GumballMachine(int numberGumballs)
        {
            soldOutState = new SoldOutState(this);
            noQuarterState = new NoQuarterState(this);
            hasQuarterState = new HasQuarterState(this);
            soldState = new SoldState(this);

            this.count = numberGumballs;
            if (numberGumballs > 0)
            {
                state = noQuarterState;
            }
            else
            {
                state = soldOutState;
            }
        }

        public void insertQuarter()
        {
            state.insertQuarter();
        }

        public void ejectQuarter()
        {
            state.ejectQuarter();
        }

        public void turnCrank()
        {
            state.turnCrank();
            state.dispense();
        }

        public void releaseBall()
        {
            Console.WriteLine("A gumball comes rolling out the slot...");
            if (count != 0)
            {
                count = count - 1;
            }
        }

        public int getCount()
        {
            return count;
        }

        public void refill(int count)
        {
            this.count += count;
            Console.WriteLine("The gumball machine was just refilled; it's new count is: " + this.count);
            state.refill();
        }
        public void setState(State state)
        {
            this.state = state;
        }
        public State getState()
        {
            return state;
        }

        public State getSoldOutState()
        {
            return soldOutState;
        }

        public State getNoQuarterState()
        {
            return noQuarterState;
        }

        public State getHasQuarterState()
        {
            return hasQuarterState;
        }

        public State getSoldState()
        {
            return soldState;
        }

        public String toString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("\nMighty Gumball, Inc.");
            result.Append("\nJava-enabled Standing Gumball Model #2004");
            result.Append("\nInventory: " + count + " gumball");
            if (count != 1)
            {
                result.Append("s");
            }
            result.Append("\n");
            result.Append("Machine is " + state + "\n");
            return result.ToString();
        }
    }

    public class SoldState : State
    {
        private GumballMachine gumballMachine;

        public SoldState(GumballMachine gumballMachine)
        {
            this.gumballMachine = gumballMachine;
        }

        public void insertQuarter()
        {
            Console.WriteLine("Please wait, we're already giving you a gumball");
        }

        public void ejectQuarter()
        {
            Console.WriteLine("Sorry, you already turned the crank");
        }

        public void turnCrank()
        {
            Console.WriteLine("Turning twice doesn't get you another gumball!");
        }

        public void dispense()
        {
            gumballMachine.releaseBall();
            if (gumballMachine.getCount() > 0)
            {
                gumballMachine.setState(gumballMachine.getNoQuarterState());
            }
            else
            {
                Console.WriteLine("Oops, out of gumballs!");
                gumballMachine.setState(gumballMachine.getSoldOutState());
            }
        }

        public void refill() { }

        public String toString()
        {
            return "dispensing a gumball";
        }
    }

    public class HasQuarterState : State
    {
        private GumballMachine gumballMachine;

        public HasQuarterState(GumballMachine gumballMachine)
        {
            this.gumballMachine = gumballMachine;
        }

        public void insertQuarter()
        {
            Console.WriteLine("You can't insert another quarter");
        }

        public void ejectQuarter()
        {
            Console.WriteLine("Quarter returned");
            gumballMachine.setState(gumballMachine.getNoQuarterState());
        }

        public void turnCrank()
        {
            Console.WriteLine("You turned...");
            gumballMachine.setState(gumballMachine.getSoldState());
        }

        public void dispense()
        {
            Console.WriteLine("No gumball dispensed");
        }

        public void refill() { }

        public String toString()
        {
            return "waiting for turn of crank";
        }
    }

    public class SoldOutState : State
    {
        private GumballMachine gumballMachine;

        public SoldOutState(GumballMachine gumballMachine)
        {
            this.gumballMachine = gumballMachine;
        }



        public void insertQuarter()
        {
            Console.WriteLine("You can't insert a quarter, the machine is sold out");
        }

        public void ejectQuarter()
        {
            Console.WriteLine("You can't eject, you haven't inserted a quarter yet");
        }

        public void turnCrank()
        {
            Console.WriteLine("You turned, but there are no gumballs");
        }

        public void dispense()
        {
            Console.WriteLine("No gumball dispensed");
        }

        public void refill()
        {
            gumballMachine.setState(gumballMachine.getNoQuarterState());
        }

        public String toString()
        {
            return "sold out";
        }
    }
}
