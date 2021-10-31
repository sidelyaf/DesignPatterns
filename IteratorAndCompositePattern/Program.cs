using System;
using System.Collections.Generic;

namespace IteratorAndCompositePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            #region Iterator Pattern
            PancakeHouseMenu pancakeHouseMenu = new PancakeHouseMenu();
            DinerMenu dinerMenu = new DinerMenu();
            List<Menu> menus = new List<Menu>();
            menus.Add(pancakeHouseMenu);
            menus.Add(dinerMenu);
            Waitress waitress = new Waitress(menus);
            waitress.PrintMenu();
            #endregion

            #region Composite Pattern
            MenuComponent pancakeHouseMenuC = new MenuNew("PANCAKE HOUSE MENU", "Breakfast");
            MenuComponent dinerMenuC =new MenuNew("DINER MENU", "Lunch");
            MenuComponent cafeMenu =new MenuNew("CAFE MENU", "Dinner");
            MenuComponent dessertMenu = new MenuNew("DESSERT MENU", "Dessert of course!");
            MenuComponent allMenus = new MenuNew("ALL MENUS", "All menus combined");
            allMenus.Add(pancakeHouseMenuC);
            allMenus.Add(dinerMenuC);
            allMenus.Add(cafeMenu);
            // add menu items here
            dinerMenuC.Add(new MenuItemNew("Pasta",
            "Spaghetti with Marinara Sauce, and a slice of sourdough bread",
            true,
            3.89));
            dinerMenuC.Add(dessertMenu);
            dessertMenu.Add(new MenuItemNew(
"Apple Pie",
            "Apple pie with a flakey crust, topped with vanilla icecream",
            true,
            1.59));
            // add more menu items here
            WaitressNew waitressC = new WaitressNew(allMenus);
            waitressC.PrintMenu();
            #endregion

            Console.ReadLine();
        }
    }
}
