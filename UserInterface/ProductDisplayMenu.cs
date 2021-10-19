using System;
using BusinessLogic;
using Models;
using System.Collections.Generic;

namespace UserInterface
{
    public class ProductMenuDisplay : IMenu
    {
        private BL _restBL;
        public ProductMenuDisplay(BL p_restBL)
        {
            _restBL = p_restBL;
        }
        public void Menu()
        {
           Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Welcome to the " + StoreFront.selectedStore + " products menu");
            Console.WriteLine("below is a list of products");

            Console.WriteLine("\n\nList of Products in " + StoreFront.selectedStore);
            StoreFront test=_restBL.GetStore(StoreFront.selectedStore);
            Console.ForegroundColor = ConsoleColor.White;
            foreach (Products rest in _restBL.ShowProducts(test))
            {
                Console.WriteLine("====================");
                Console.WriteLine(rest);
                Console.WriteLine("====================");
            } 
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n [0] - exit");
            Console.WriteLine("\n [1] - Back to store select");
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