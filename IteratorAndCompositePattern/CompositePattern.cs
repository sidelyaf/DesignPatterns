using System;
using System.Collections;
using System.Collections.Generic;

namespace IteratorAndCompositePattern
{
    public class CompositePattern
    {
    }

    public class MenuNew : MenuComponent
    {
        List<MenuComponent> menuComponents = new List<MenuComponent>();
        string name;
        string description;
        Iterator iterator = null;
        public MenuNew(string name, string description)
        {
            this.name = name;
            this.description = description;
        }
        public override void Add(MenuComponent menuComponent)
        {
            menuComponents.Add(menuComponent);
        }
        public override void Remove(MenuComponent menuComponent)
        {
            menuComponents.Remove(menuComponent);
        }
        public override MenuComponent GetChild(int i)
        {
            return menuComponents[i];
        }
        public override string GetName()
        {
            return name;
        }
        public override string GetDescription()
        {
            return description;
        }
        public override void Print()
        {
            Console.WriteLine("\n" + GetName());
            Console.WriteLine(", " + GetDescription());
            Console.WriteLine("---------------------");

            foreach (var item in menuComponents)
            {
                Iterator iterator = item.CreateIterator();
                while (iterator.HasNext())
                {
                    MenuComponent menuComponent = (MenuComponent)iterator.Next();
                    menuComponent.Print();
                }
            }
        }

        /// <summary>
        /// TODO: Burada bir sıkıntı var doğru iterator ı göndermek gerekiyor. nullreferance hatası var.
        /// </summary>
        /// <returns></returns>
        public override Iterator CreateIterator()
        {
            if (iterator == null)
            {
                iterator = new CompositeIterator(iterator);
                
            }
            return iterator;
        }
    }

    public class NullIterator : Iterator
    {
        public object Next()
        {
            return null;
        }
        public bool HasNext()
        {
            return false;
        }
        public void Remove()
        {
            throw new NotSupportedException();
        }
    }
    public class CompositeIterator : Iterator
    {
        Stack stack = new Stack();
        public CompositeIterator(Iterator iterator)
        {
            stack.Push(iterator);
        }
        public object Next()
        {
            if (HasNext())
            {
                Iterator iterator = (Iterator)stack.Peek();
                MenuComponent component = (MenuComponent)iterator.Next();
                if (component.GetType() == typeof(MenuNew))
                {
                    stack.Push(component.CreateIterator());
                }
                return component;
            }
            else
            {
                return null;
            }
        }
        public bool HasNext()
        {
            if (stack.Count == 0)
            {
                return false;
            }
            else
            {
                Iterator iterator = (Iterator)stack.Peek();
                if (!iterator.HasNext())
                {
                    stack.Pop();
                    return HasNext();
                }
                else
                {
                    return true;
                }
            }
        }
        public void Remove()
        {
            throw new NotSupportedException();
        }
    }

    //public class CompositeIterator : Iterator
    //    {
    //        List<MenuComponent> items;
    //        int position = 0;
    //        public CompositeIterator(List<MenuComponent> items)
    //        {
    //            this.items = items;
    //        }
    //        public object Next()
    //        {
    //            MenuComponent menuItem = items[position];
    //            position = position + 1;
    //            return menuItem;
    //        }
    //        public bool HasNext()
    //        {
    //            if (position >= items.Count || items[position] == null)
    //            {
    //                return false;
    //            }
    //            else
    //            {
    //                return true;
    //            }
    //        }
    //    }
    public class MenuItemNew : MenuComponent
    {
        string name;
        string description;
        bool vegetarian;
        double price;
        public MenuItemNew(string name, string description, bool vegetarian, double price)
        {
            this.name = name;
            this.description = description;
            this.vegetarian = vegetarian;
            this.price = price;
        }
        public override string GetName()
        {
            return name;
        }
        public override string GetDescription()
        {
            return description;
        }
        public override double GetPrice()
        {
            return price;
        }
        public override bool IsVegetarian()
        {
            return vegetarian;
        }
        public override void Print()
        {
            Console.WriteLine("" + GetName());
            if (IsVegetarian())
            {
                Console.WriteLine("(v)");
            }
            Console.WriteLine(", " + GetPrice());
            Console.WriteLine(" -- " + GetDescription());
        }

        public override Iterator CreateIterator()
        {
            return new NullIterator();
        }
    }
    public abstract class MenuComponent
    {
        public virtual void Add(MenuComponent menuComponent)
        {
            throw new NotSupportedException();
        }
        public virtual void Remove(MenuComponent menuComponent)
        {
            throw new NotSupportedException();
        }
        public virtual MenuComponent GetChild(int i)
        {
            throw new NotSupportedException();
        }
        public virtual string GetName()
        {
            throw new NotSupportedException();
        }
        public virtual string GetDescription()
        {
            throw new NotSupportedException();
        }
        public virtual double GetPrice()
        {
            throw new NotSupportedException();
        }
        public virtual bool IsVegetarian()
        {
            throw new NotSupportedException();
        }
        public virtual void Print()
        {
            throw new NotSupportedException();
        }
        public abstract Iterator CreateIterator();
    }

    public class WaitressNew
    {
        MenuComponent allMenus;
        public WaitressNew(MenuComponent allMenus)
        {
            this.allMenus = allMenus;
        }
        public void PrintMenu()
        {
            allMenus.Print();
        }
        public void PrintVegetarianMenu()
        {
            Iterator iterator = allMenus.CreateIterator();
            Console.WriteLine("\nVEGETARIAN MENU\n----");
            while (iterator.HasNext())
            {
                MenuComponent menuComponent = (MenuComponent)iterator.Next();
                try
                {
                    if (menuComponent.IsVegetarian())
                    {
                        menuComponent.Print();
                    }
                }
                catch (NotSupportedException e) { }
            }
        }
    }
}
