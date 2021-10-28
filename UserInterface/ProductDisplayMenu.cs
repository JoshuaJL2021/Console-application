using System;
using BusinessLogic;
using Models;
using System.Collections.Generic;

namespace UserInterface
{
    public class ProductMenuDisplay : IMenu
    {
        private InterfaceBL _restBL;
        public ProductMenuDisplay(BL p_restBL)
        {
            _restBL = p_restBL;
        }
        public void Menu()
        {
           Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Welcome to the " + SingletonUser.currentstore._name + " products menu");
            Console.WriteLine("below is a list of products");

            Console.WriteLine("\n\nList of Products in " + SingletonUser.currentstore._name);
            StoreFront test=_restBL.GetStoreByID(SingletonUser.currentstore.Id);
            Console.ForegroundColor = ConsoleColor.White;
            foreach (LineItems rest in _restBL.GetInventory(SingletonUser.currentstore.Id))
            {
                Console.WriteLine("====================");
                Console.WriteLine(rest._product);
                Console.WriteLine("====================");
            } 
            
            Console.WriteLine("[2] - Begin to Place an Order");
            Console.WriteLine("[1] - Back to store select");
            Console.WriteLine("[0] - exit");
            
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
                    return MenuType.MainMenu;
            }
        }
    }
}