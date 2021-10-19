using System;
using BusinessLogic;
using Models;
using System.Collections.Generic;

namespace UserInterface
{
    public class StoreMenu : IMenu
    {
        private BL _restBL;
        public StoreMenu(BL p_restBL)
        {
            _restBL = p_restBL;
        }
        public void Menu()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Welcome to the store select menu " + Customer.Displayname );
            Console.WriteLine("Please select the store");

            Console.WriteLine("\n\n List of StoreFronts");
            List<StoreFront> listOfStoreFront = _restBL.GetAllStoreFrontsBL();
            Console.ForegroundColor = ConsoleColor.White;
            foreach (StoreFront rest in listOfStoreFront)
            {
                Console.WriteLine("====================");
                Console.WriteLine(rest);
                Console.WriteLine("====================");
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("[2] - Select the store (goes to products display");
            Console.WriteLine("[1] - canada (goes to login");
            Console.WriteLine("[0] - exit");
      
        }

        public MenuType YourChoice()
        {
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "2":
                Console.WriteLine("Enter store you want to enter");
                string storename=Console.ReadLine();
                StoreFront.SelectedStore=storename;
                Console.WriteLine("Enter store address you want to enter");
                string storeaddress=Console.ReadLine();
                StoreFront.SelectedAddress=storeaddress;
 Console.Clear();
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
