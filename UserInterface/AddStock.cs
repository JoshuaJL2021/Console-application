using System;
using System.Collections.Generic;
using BusinessLogic;
using Models;

namespace UserInterface
{
    public class AddStock : IMenu
    {
        private static LineItems items = new LineItems();
        private InterfaceBL parameterInter;
         
        public AddStock(InterfaceBL parameterobj)
        {
            parameterInter = parameterobj;
        }

        public void Menu()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("##################################################################################\n");

            Console.WriteLine("Adding a new LineItem");
            Console.WriteLine("---------------------------------------------------------------------\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(SingletonUser.currentstore);
            Console.WriteLine(items._product);
            Console.WriteLine("Ammount of Item : "+items._quantity);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n##################################################################################\n");

            Console.WriteLine("[4] - Add LineItem/Stock");
            Console.WriteLine("[3] - Input value for products name");
            Console.WriteLine("[2] - Input value for products quantity");
            Console.WriteLine("[1] - select store");
            Console.WriteLine("[0] - Go Back");
            Console.WriteLine("\n##################################################################################\n");

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
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("\n##################################################################################\n");
                    Console.WriteLine("---------------------------------------------------------------------\n");
                    List<Products> listOfRestaurants = parameterInter.GetAllProductsBL();
                    Console.ForegroundColor = ConsoleColor.White;
                    foreach (Products rest in listOfRestaurants)
                    {
                        Console.WriteLine("====================");
                        Console.WriteLine(rest);
                        Console.WriteLine("====================");
                    }
                    Console.WriteLine("\tType in the product Id u want");
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
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("\n##################################################################################\n");

                    Console.WriteLine("\tType in the value for the quantity");
                    items._quantity = Convert.ToInt32(Console.ReadLine());
                    return MenuType.AddLineItem;
                case "1":

                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("\n##################################################################################\n");
                    Console.WriteLine("---------------------------------------------------------------------\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    List<StoreFront> listofstores = parameterInter.GetAllStoreFrontsBL();

                    foreach (StoreFront rest in listofstores)
                    {
                        Console.WriteLine("====================");
                        Console.WriteLine(rest);
                        Console.WriteLine("====================");
                    }

                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("\tEnter store you want to enter");
                    int number = Convert.ToInt32(Console.ReadLine());

                    try
                    {

                        SingletonUser.currentstore = parameterInter.GetStoreByID(number);
                        Console.WriteLine("\tWelcome to " + SingletonUser.currentstore + "\t press enter to continue");
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