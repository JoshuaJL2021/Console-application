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
            Console.WriteLine(items.ProductEstablish);
            Console.WriteLine("\tAmmount of Item : " + items.Quantity);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n##################################################################################\n");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("\t[4] - Add LineItem/Stock");
            Console.WriteLine("\t[3] - Input value for products name");
            Console.WriteLine("\t[2] - Input value for products quantity");
            Console.WriteLine("\t[1] - select store");
            Console.WriteLine("\t[0] - Go Back");
             Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n##################################################################################\n");

        }

        public MenuType YourChoice()
        {
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "4":
                    //Add implementation to talk to the repository method to add a restaurant
                    parameterInter.AddStock(SingletonUser.currentstore, items.ProductEstablish, items.Quantity);
                    Console.WriteLine("\t Product Added to store");
                    Console.WriteLine("\tPress enter to continue");
                    Console.ReadLine();
                    items = new LineItems();
                    SingletonUser.currentstore = null;
                    

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
                    Console.WriteLine("\n##################################################################################\n");
                    Console.WriteLine("\tType in the product Id u want");
                    int num = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("\n##################################################################################\n");
                    try
                    {
                        items.ProductEstablish = parameterInter.GetProduct(num);
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
                    items.Quantity = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("\n##################################################################################\n");

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
                    Console.WriteLine("\n##################################################################################\n");
                    Console.WriteLine("\tEnter store you want to enter");
                    int number = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("\n##################################################################################\n");

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
                        Console.WriteLine("\tStore was unfortunately not found please enter name as shown in list above");
                        Console.WriteLine("\tYou will be sent to Store display again ");
                        Console.WriteLine("\tPress Enter to continue");
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