using System;
using System.Collections.Generic;

namespace IteratorAndCompositePattern
{
    public class IteratorPattern
    {
    }

    public interface Iterator
    {
        bool HasNext();
        object Next();
    }

    public interface Menu
    {
        Iterator CreateIterator();
    }

    public class MenuItem
    {
        string name;
        string description;
        bool vegetarian;
        double price;

        public MenuItem(string name, string description, bool vegetarian, double price)
        {
            this.name = name;
            this.description = description;
            this.vegetarian = vegetarian;
            this.price = price;
        }

        public string getName()
        {
            return name;
        }

        public string getDescription()
        {
            return description;
        }

        public double getPrice()
        {
            return price;
        }

        public bool IsVegetarian()
        {
            return vegetarian;
        }
        public string tostring()
        {
            return (name + ", $" + price + "\n   " + description);
        }
    }

    public class PancakeHouseMenuIterator : Iterator
    {
        List<MenuItem> _items;
        int position;
        public PancakeHouseMenuIterator(List<MenuItem> items)
        {
            _items = items;
        }
        public bool HasNext()
        {
            return position > 0 ? true : false;
        }

        public object Next()
        {
            MenuItem menuItem = _items[position];
            position = position + 1;
            return menuItem;
        }

        public void Remove()
        {
            if (position <= 0)
            {
                throw new NullReferenceException
                ("You can’t Remove an item until you’ve done at least one Next()");
            }
            if (_items[position - 1] != null)
            {
                for (int i = position - 1; i < (_items.Count - 1); i++)
                {
                    _items[i] = _items[i + 1];
                }
                _items[_items.Count - 1] = null;
            }
        }
    }

    public class DinerMenuIterator : Iterator
    {
        MenuItem[] items;
        int position = 0;
        public DinerMenuIterator(MenuItem[] items)
        {
            this.items = items;
        }
        public Object Next()
        {
            MenuItem menuItem = items[position];
            position = position + 1;
            return menuItem;
        }
        public bool HasNext()
        {
            if (position >= items.Length || items[position] == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }

    public class PancakeHouseMenu : Menu
    {
        List<MenuItem> menuItems;
        public PancakeHouseMenu()
        {
            menuItems = new List<MenuItem>();

            AddItem("K&B's Pancake Breakfast",
                "Pancakes with scrambled eggs, and toast",
                true,
                2.99);

            AddItem("Regular Pancake Breakfast",
                "Pancakes with fried eggs, sausage",
                false,
                2.99);

            AddItem("Blueberry Pancakes",
                "Pancakes made with fresh blueberries, and blueberry syrup",
                true,
                3.49);

            AddItem("Waffles",
                "Waffles, with your choice of blueberries or strawberries",
                true,
                3.59);
        }

        public void AddItem(string name, string description, bool vegetarian, double price)
        {
            MenuItem menuItem = new MenuItem(name, description, vegetarian, price);
            menuItems.Add(menuItem);
        }

        public List<MenuItem> GetMenuItems()
        {
            return menuItems;
        }

        public Iterator CreateIterator()
        {
            return new PancakeHouseMenuIterator(menuItems);
        }
    }

    public class DinerMenu : Menu
    {

        static int MAX_ITEMS = 6;
        int numberOfItems = 0;
        MenuItem[] menuItems;

        public DinerMenu()
        {
            menuItems = new MenuItem[MAX_ITEMS];

            AddItem("Vegetarian BLT",
                "(Fakin') Bacon with lettuce & tomato on whole wheat", true, 2.99);
            AddItem("BLT",
                "Bacon with lettuce & tomato on whole wheat", false, 2.99);
            AddItem("Soup of the day",
                "Soup of the day, with a side of potato salad", false, 3.29);
            AddItem("Hotdog",
                "A hot dog, with saurkraut, relish, onions, topped with cheese",
                false, 3.05);
            AddItem("Steamed Veggies and Brown Rice",
                "Steamed vegetables over brown rice", true, 3.99);
            AddItem("Pasta",
                "Spaghetti with Marinara Sauce, and a slice of sourdough bread",
                true, 3.89);
        }

        public void AddItem(String name, String description,
                             bool vegetarian, double price)
        {
            MenuItem menuItem = new MenuItem(name, description, vegetarian, price);
            if (numberOfItems >= MAX_ITEMS)
            {
                Console.WriteLine("Sorry, menu is full!  Can't add item to menu");
            }
            else
            {
                menuItems[numberOfItems] = menuItem;
                numberOfItems = numberOfItems + 1;
            }
        }

        public MenuItem[] GetMenuItems()
        {
            return menuItems;
        }

        public Iterator CreateIterator()
        {
            return new DinerMenuIterator(menuItems);
        }
    }

    public class Waitress
    {
        List<Menu> menus;


        public Waitress(List<Menu> menus)
        {
            this.menus = menus;
        }

        public void PrintMenu()
        {
            foreach (var item in menus)
            {
                Iterator menuIterator = item.CreateIterator();

                Console.WriteLine("MENU\n----\n");
                while (menuIterator.HasNext())
                {
                    menuIterator.Next();
                    PrintMenu(item.CreateIterator());
                }
            } 
        }

        void PrintMenu(Iterator iterator)
        {
            while (iterator.HasNext())
            {
                MenuItem menuItem = (MenuItem)iterator.Next();
                Console.WriteLine(menuItem.getName() + ", ");
                Console.WriteLine(menuItem.getPrice() + " -- ");
                Console.WriteLine(menuItem.getDescription());
            }
        }
    }

}
