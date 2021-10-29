using System;
using System.Collections.Generic;
using BusinessLogic;
using Models;

namespace UserInterface
{
    public class AddLineItem : IMenu
    {
        private static LineItems items = new LineItems();
        private InterfaceBL parameterInter;

        public AddLineItem(InterfaceBL parameterobj)
        {
            parameterInter = parameterobj;
        }

        public void Menu()
        {
            Console.WriteLine("Adding a new LineItem");

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(SingletonUser.currentstore);
            Console.WriteLine(items._product);
            Console.WriteLine(items._quantity);

            Console.WriteLine("[4] - Add LineItem");
            Console.WriteLine("[3] - Input value for products name");
            Console.WriteLine("[2] - Input value for products quantity");
            Console.WriteLine("[1] - select store");
            Console.WriteLine("[0] - Go Back");

        }

        public MenuType YourChoice()
        {
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "4":
                    //Add implementation to talk to the repository method to add a restaurant
                    parameterInter.AddStock(SingletonUser.currentstore, items._product, items._quantity);

                    return MenuType.MainMenu;
                case "3":
                    List<Products> listOfRestaurants = parameterInter.GetAllProductsBL();

                    foreach (Products rest in listOfRestaurants)
                    {
                        Console.WriteLine("====================");
                        Console.WriteLine(rest);
                        Console.WriteLine("====================");
                    }
                    Console.WriteLine("Type in the product Id u want");
                    int num = Convert.ToInt32(Console.ReadLine());
                    try
                    {
                        items._product = parameterInter.GetProduct(num);
                    }
                    catch (System.Exception)
                    {

                        throw;
                    }
                    return MenuType.AddLineItem;
                case "2":
                    Console.WriteLine("Type in the value for the quantity");
                    items._quantity = Convert.ToInt32(Console.ReadLine());
                    return MenuType.AddLineItem;
                case "1":

                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    List<StoreFront> listofstores = parameterInter.GetAllStoreFrontsBL();

                    foreach (StoreFront rest in listofstores)
                    {
                        Console.WriteLine("====================");
                        Console.WriteLine(rest);
                        Console.WriteLine("====================");
                    }


                    Console.WriteLine("Enter store  you want to enter");
                    int number = Convert.ToInt32(Console.ReadLine());

                    try
                    {

                        SingletonUser.currentstore = parameterInter.GetStoreByID(number);
                        Console.WriteLine("Welcome to " + SingletonUser.currentstore + "\n enter to continue");
                        Console.ReadLine();
                    }
                    catch (System.Exception)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        SingletonUser.currentstore = null;
                        Console.WriteLine("Store was unfortunately not found please enter name as shown in list above");
                        Console.WriteLine("You will be sent to Store display again ");
                        Console.WriteLine("Press Enter to continue");
                        Console.ReadLine();
                    }
                    return MenuType.AddLineItem;
                case "0":
                    return MenuType.MainMenu;
                default:
                    Console.WriteLine("Please input a valid response!");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return MenuType.AddLineItem;
            }
        }
    }
}