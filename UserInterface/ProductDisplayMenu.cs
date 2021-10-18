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
           
            Console.WriteLine("Welcome to the " + StoreFront.SelectedStore + " products menu");
            Console.WriteLine("below is a list of products");

            Console.WriteLine("\n\n List of Products");
            List<Products> listOfProduct = _restBL.GetAllProductsBL();

            foreach (Products rest in listOfProduct)
            {
                Console.WriteLine("====================");
                Console.WriteLine(rest);
                Console.WriteLine("====================");
            }
            
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