using System;
using BusinessLogic;
using System.Collections.Generic;
using Models;

namespace UserInterface
{
    public class ProductBuyMenu : IMenu
    {
        private BL _restBL;
        public ProductBuyMenu(BL p_restBL)
        {
            _restBL = p_restBL;
        }
        public void Menu()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Welcome to the order menu");
            Console.WriteLine("What would you like to buy");

             Console.WriteLine("\n\n List of Products you can purchase");
            List<Products> listOfProduct = _restBL.GetAllProductsBL();

            Console.ForegroundColor = ConsoleColor.White;
            foreach (Products rest in listOfProduct)
            {
                Console.WriteLine("====================");
                Console.WriteLine(rest);
                Console.WriteLine("====================");
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("[3] - Confirm Purchase");
            Console.WriteLine("[2] - texas (goes to products display");
            Console.WriteLine("[1] - canada (goes to order history");
            Console.WriteLine("[0] - exit");
      
        }

        public MenuType YourChoice()
        {
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "2":
                    return MenuType.ProductDisplayMenu;
                case "1":
                    return MenuType.MainMenu;
                case "0":
                    return MenuType.LoginMenu;
                default:
                    Console.WriteLine("Please input a valid response!");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return MenuType.MainMenu;
            }
        }
    }
}