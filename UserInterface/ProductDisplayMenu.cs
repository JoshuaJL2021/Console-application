using System;
using BusinessLogic;
using Models;
using System.Collections.Generic;

namespace UserInterface
{
    public class ProductMenuDisplay : IMenu
    {
        private InterfaceBL parameterInter;
        public ProductMenuDisplay(BL parameterobj)
        {
            parameterInter = parameterobj;
        }
        public void Menu()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("##################################################################################\n");
            Console.WriteLine("\tWelcome to the " + SingletonUser.currentstore._name + " products menu");
            Console.WriteLine("\tBelow is a list of products");
            Console.WriteLine("---------------------------------------------------------------------\n");
            Console.WriteLine("\tList of Products in " + SingletonUser.currentstore._name);
            StoreFront test = parameterInter.GetStoreByID(SingletonUser.currentstore.Id);
            Console.ForegroundColor = ConsoleColor.White;
            foreach (LineItems rest in parameterInter.GetInventory(SingletonUser.currentstore.Id))
            {
                Console.WriteLine("====================");
                Console.WriteLine("\t" + rest);
                Console.WriteLine("====================");
            }
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("\t[2] - Begin to Place an Order");
            Console.WriteLine("\t[1] - Back to store select");
            Console.WriteLine("\t[0] - exit");
            Console.ForegroundColor = ConsoleColor.DarkYellow;

            Console.WriteLine("\n##################################################################################\n");


        }

        public MenuType YourChoice()
        {
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "2":
                    return MenuType.ProductBuyMenu;
                case "1":
                    return MenuType.StoreMenu;
                case "0":
                    return MenuType.MainMenu;
                default:
                    Console.WriteLine("Please input a valid response!");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return MenuType.ProductDisplayMenu;
            }
        }
    }
}